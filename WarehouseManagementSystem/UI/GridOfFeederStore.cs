using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseManagementSystem.DbGateway;

namespace WarehouseManagementSystem.UI
{
    public partial class GridOfFeederStore : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public GridOfFeederStore()
        {
            InitializeComponent();
        }


        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(FeederStock.Sl),RTRIM(FeederStock.RequisitionNo),RTRIM(ProductListSummary.ProductGenericDescription),RTRIM(FeederStock.ItemCode),RTRIM(FeederStock.Quantity) from FeederStock order by FeederStock.Sl", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void GridOfFeederStore_Load(object sender, EventArgs e)
        {
            GetData();
        }
    }
}
