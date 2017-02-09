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
using WarehouseManagementSystem.LoginUI;

namespace WarehouseManagementSystem.UI
{
    public partial class DeliveryOrderUI : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        private SqlDataAdapter sda;
        ConnectionString cs=new ConnectionString();
        private DataTable dt;
        private string feederId;
        private decimal itemQuantity1, itemQuantity2;
        public string userId;        
        public static int max,i=0;
        string[] pName = new string[max];
        public DeliveryOrderUI()
        {
            InitializeComponent();
        }
        public void GetFeederNameCombo()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(FeederStockDetails.FeederName) from FeederStockDetails  order by FeederStockDetails.FeederId desc ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    feederStockCombo.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void GetDeliveryOrderId()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct ="select DeleveryOrder.DOiD from DeleveryOrder  Except select DeliveryLog.DOiD from DeliveryLog";
                //string ct = "select RTRIM(DeleveryOrder.DOiD) from DeleveryOrder  order by DeleveryOrder.DOiD desc ";
                
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    deliveryOrderCombo.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetFeederDetails()
        {
            listView2.View = View.Details;
            con = new SqlConnection(cs.DBConn);
            string query = "SELECT ProductListSummary.ProductGenericDescription,ProductListSummary.ItemDescription, ProductQuotation.Quantity FROM   ProductQuotation INNER JOIN Quotation ON ProductQuotation.QuotationId = Quotation.QuotationId INNER JOIN  DeleveryOrder ON Quotation.QuotationId = DeleveryOrder.QuotationId INNER JOIN  ProductListSummary ON ProductQuotation.Sl = ProductListSummary.Sl where DeleveryOrder.DOiD='" + deliveryOrderCombo.Text + "'";       
            sda = new SqlDataAdapter(query, con);
            dt = new DataTable();
            sda.Fill(dt);

            for (int b = 0; b < dt.Rows.Count; b++)
            {
                DataRow dr = dt.Rows[b];
                ListViewItem listitem1 = new ListViewItem(dr[0].ToString());
                listitem1.SubItems.Add(dr[1].ToString());
                listitem1.SubItems.Add(dr[2].ToString());
                listitem1.SubItems.Add(dr[3].ToString());
                listitem1.SubItems.Add(dr[4].ToString());      
                listView2.Items.Add(listitem1);
            }
        }
        private void GetDeliveryOrder()
        {
            listView1.View = View.Details;
            con = new SqlConnection(cs.DBConn);
            string qry = "SELECT RTRIM(FeederStock.RId),RTRIM(FeederStock.FeederId),RTRIM(ProductListSummary.ProductGenericDescription),RTRIM(ProductListSummary.ItemDescription),RTRIM(FeederStock.Quantity) FROM  FeederStock INNER JOIN  FeederStockDetails ON FeederStock.FeederId = FeederStockDetails.FeederId INNER JOIN  RequisitionList ON FeederStock.RId = RequisitionList.RId INNER JOIN Requisition ON RequisitionList.ReqId = Requisition.ReqId INNER JOIN  MasterStocks ON RequisitionList.MStockId = MasterStocks.MStockId INNER JOIN  ProductListSummary ON MasterStocks.Sl = ProductListSummary.Sl where FeederStock.Quantity>0 and FeederStock.FeederId='" + feederId + "'";
            sda = new SqlDataAdapter(qry, con);
            dt = new DataTable();
            sda.Fill(dt);
            max = dt.Rows.Count;
            for (int b = 0; b < dt.Rows.Count; b++)
            {
                DataRow dr = dt.Rows[b];
                ListViewItem listitem1 = new ListViewItem(dr[0].ToString());
                listitem1.SubItems.Add(dr[1].ToString());
                listitem1.SubItems.Add(dr[2].ToString());
                              
                listitem1.SubItems.Add(dr[3].ToString());
                listitem1.SubItems.Add(dr[4].ToString());  
                listView1.Items.Add(listitem1);
               
            }
           
        }

        private void DeliveryOrderUI_Load(object sender, EventArgs e)
        {
            userId = LoginForm.uId2.ToString();
           // this.listView1.CheckBoxes = true;
            GetFeederNameCombo();
            GetDeliveryOrderId();
            
        }

      


        private void ProductMatch()
        {           
           
            for (int i=0; i <= listView2.Items.Count - 1; i++)
            {
                if (listView1.FindItemWithText(listView2.Items[i].SubItems[1].Text, true, 0) == null)
                {
                    MessageBox.Show("The Order is  not  applicable for this  feeder.", "record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


            //    for (int j = 0; j < listView1.Items.Count - 1; j++)
            //    {
                   
            //        if (!listView1.Items[i].SubItems[3].Text.Contains(listView2.Items[j].SubItems[1].Text))
            //        {
            //            MessageBox.Show("The Order is  not  applicable for this  feeder.", "record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            return;
            //        }
            //    }
                
                //foreach (var item in listView1.Items[i].SubItems[3].Text)
                //{
                //    bool my = listView2.Items[1].SubItems[1].Text == listView1.Items[i].SubItems[3].Text;
                //    if (my == false)
                //    {
                //        MessageBox.Show("The Order is  not  applicable for this  feeder.", "record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        return;
                //    }
                //}
                //for (int j = 0; j < listView1.Items.Count-1; j++)
                //{




                //    bool my = listView2.Items[j].SubItems[1].Text == listView1.Items[i].SubItems[3].Text;
                //    if (my == false)
                //    {
                //        MessageBox.Show("The Order is  not  applicable for this  feeder.", "record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //           return;
                //    }                                                   
           } 
        }
        private void feederStockCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.Items.Clear();
            try
            {
                con=new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select  RTRIM(FeederStockDetails.FeederId) from  FeederStockDetails where  FeederStockDetails.FeederName='"+feederStockCombo.Text+"'";
                cmd=new SqlCommand(query,con);
                rdr=cmd.ExecuteReader();
                if (rdr.Read())
                {
                    feederId = (rdr.GetString(0));
                }
                con.Close();
                //GetFeederDetails();
                GetDeliveryOrder();
                ProductMatch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void deliveryOrderCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            GetFeederDetails();
            

        }

        private void SaveDeliveryLog()
        {
            try
            {
                con=new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Insert into DeliveryLog(DOiD,ApprovedByUId,FeederId,ApprovedDateTime) Values(@d1,@d2,@d3,@d4)";
                cmd=new SqlCommand(query,con);
                cmd.Parameters.AddWithValue("@d1", deliveryOrderCombo.Text);
                cmd.Parameters.AddWithValue("@d2", userId);
                cmd.Parameters.AddWithValue("@d3", feederId);
                cmd.Parameters.AddWithValue("@d4", DateTime.UtcNow.ToLocalTime());
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonApprove_Click(object sender, EventArgs e)
        {
            try
            {
                SaveDeliveryLog();
                for (int i = 0; i <= listView2.Items.Count - 1; i++)
                {
                    
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select Quantity from FeederStock where  FeederStock.FeederId='" + listView1.Items[i].SubItems[1].Text + "' and FeederStock.RId='" + listView1.Items[i].SubItems[0].Text + "' ";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        itemQuantity1 = (rdr.GetDecimal(0));
                    }
                    con.Close();
                    decimal ex = decimal.Parse(listView2.Items[i].SubItems[2].Text);
                    itemQuantity2 = itemQuantity1 - ex;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb2 = "Update FeederStock set Quantity=" + itemQuantity2 + " where FeederStock.FeederId='" + listView1.Items[i].SubItems[1].Text + "' and FeederStock.RId='" + listView1.Items[i].SubItems[0].Text + "'";
                    cmd = new SqlCommand(cb2);
                    cmd.Connection = con;
                    cmd.ExecuteReader();
                    con.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.DrawBackground();
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(e.Header.Tag);
                }
                catch (Exception)
                {
                }
                CheckBoxRenderer.DrawCheckBox(e.Graphics,
                    new Point(e.Bounds.Left + 4, e.Bounds.Top + 4),
                    value ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal :
                    System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(this.listView1.Columns[e.Column].Tag);
                }
                catch (Exception)
                {
                }
                this.listView1.Columns[e.Column].Tag = !value;
                foreach (ListViewItem item in this.listView1.Items)
                    item.Checked = !value;

                this.listView1.Invalidate();
            }
        }
    }
}
