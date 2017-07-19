using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

using WarehouseManagementSystem.DbGateway;
using WarehouseManagementSystem.LoginUI;
using ZXing;
using ZXing.Common;

namespace WarehouseManagementSystem.UI
{
    public partial class ReturnApproval : Form
    {
        private SqlCommand cmd;
        ConnectionString Cs=new ConnectionString();
        private SqlConnection con;
        private SqlDataReader rdr;
        private string impOd;
        private DataGridViewRow dr;
        private int checkvalue,smId,available;
        private int SupplierId;
        private int Sio,OI,RRid;
        public string ShID;
        private string shipmentOrderNo,clientId,quotationId,brandCode;
        public Nullable<Int64> brandid;
        private Dictionary<int,string> orderList=new Dictionary<int, string>();
        private Dictionary<int, int> productList = new Dictionary<int, int>();

        public ReturnApproval()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           string[] splitterArray= comboBox1.Text.Split('-');
            RRid = Convert.ToInt32(splitterArray[3]);
            var x = from entry in orderList
                where entry.Value == comboBox1.Text
                select entry.Key;
            OI=x.FirstOrDefault();
            string qry="SELECT  ProductQuotation.Sl, OutProduct.OutQty FROM  OutTable INNER JOIN OutProduct ON OutTable.OutId = OutProduct.OutId INNER JOIN DeliveryProduct ON OutProduct.DeliveryProductId = DeliveryProduct.DeliveryProductId INNER JOIN ProductQuotation ON DeliveryProduct.PQId = ProductQuotation.PQId where OutTable.OutId="+OI;
            con = new SqlConnection(Cs.DBConn);
            cmd.CommandText = qry;
            cmd.Connection = con;
            con.Open();
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int SI = rdr.GetInt32(0);
                int Qty = rdr.GetInt32(1);
                productList.Add(SI,Qty);
            }
            con.Close();
        }




        private void ReturnRequest_Load(object sender, EventArgs e)
        {
            ComboLoad();


        }

        private void ComboLoad()
        {
            con = new SqlConnection(Cs.DBConn);
            string qry =
                "SELECT OutTable.OutId, ('RR' +'-'+CONVERT(varchar(12), Delivery.SClientId)+'-'+CONVERT(varchar(12),ReturnRequest.SlOfClient)+'-'+CONVERT(varchar(12),ReturnRequest.RRid )) as ref FROM ReturnRequest INNER JOIN OutTable ON ReturnRequest.OutId = OutTable.OutId INNER JOIN Delivery ON OutTable.DeliveryId = Delivery.DeliveryId where ReturnRequest.RRid not in (SELECT  RRId from ReturnApproval)";
            cmd = new SqlCommand(qry, con);
            con.Open();
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int OutId = rdr.GetInt32(0);
                string reff =rdr.GetString(1);
                orderList.Add(OutId,reff);
            }
            con.Close();
            foreach (KeyValuePair<int,string> refPair in orderList)
            {
                comboBox1.Items.Add(refPair.Value);
            }
        }

        private void ClearselectedProduct()
        {
            impOd = null;
            orderList.Clear();
            comboBox1.Items.Clear();
            productList.Clear();
 
        }


        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(comboBox1.Text))
            {
          
                    button1.Enabled = false;
                    con = new SqlConnection(Cs.DBConn);
                    string q1 =
                    "INSERT INTO ReturnApproval(RRId, EntryDate, UserId) VALUES  (" + OI + ",@d1," + LoginForm.uId2 + ")";
                SqlTransaction trnas;
                con.Open();
                trnas = con.BeginTransaction();
                    cmd = new SqlCommand(q1, con);
                    cmd.Parameters.AddWithValue("@d1", DateTime.UtcNow.ToLocalTime());
                cmd.Transaction = trnas;
                   
                try
                {
                    cmd.ExecuteNonQuery();
                    string query ="UPDATE MasterStocks1 SET MQuantity = MQuantity + @d3 WHERE (Sl = @d2)";
                    cmd = new SqlCommand(query, con);
                    foreach (KeyValuePair<int,int> prdct in productList)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@d2", prdct.Key);
                        cmd.Parameters.AddWithValue("@d3", prdct.Value);
                        cmd.ExecuteNonQuery();
                    }
                    cmd.Transaction.Commit();
                    MessageBox.Show("Delivery Order Done");
                    ClearselectedProduct();
                    ComboLoad();
                    button1.Enabled = true;
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show(ex.Message,"Error But We Are Roll Backing");
                    cmd.Transaction.Rollback();
                }
                    
                con.Close();


              

            }
            else
            {
                MessageBox.Show("Select Delivery Order");
            }
        }
        }
    }
