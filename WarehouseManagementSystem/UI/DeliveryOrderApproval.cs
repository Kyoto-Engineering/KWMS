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
    
    public partial class DeliveryOrderApproval : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        private DataTable dt;
        private SqlDataAdapter sda;
        ConnectionString cs=new ConnectionString();
        public string feederId, userId;
        public decimal itemQuantity1, itemQuantity2;

        public DeliveryOrderApproval()
        {
            InitializeComponent();
        }


        public void GetFeederNameCombo()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
               // string ct ="SELECT  FeederStockDetails.FeederName FROM  FeederStock INNER JOIN FeederStockDetails ON FeederStock.FeederId = FeederStockDetails.FeederId  INNER JOIN DeliveryLog ON FeederStockDetails.FeederId = DeliveryLog.FeederId INNER JOIN DeleveryOrder ON DeliveryLog.DOiD = DeleveryOrder.DOiD where DeleveryOrder.DOiD='"+deliveryOrderCombo.Text+"'";
                string ct = "SELECT FeederStockDetails.FeederName FROM  DeliveryLog INNER JOIN FeederStockDetails ON DeliveryLog.FeederId = FeederStockDetails.FeederId INNER JOIN DeleveryOrder ON DeliveryLog.DOiD = DeleveryOrder.DOiD  where  DeleveryOrder.DOiD='"+deliveryOrderCombo.Text+"' ";
                //string ct ="SELECT FeederStockDetails.FeederName FROM  DeliveryLog INNER JOIN FeederStockDetails ON DeliveryLog.FeederId = FeederStockDetails.FeederId INNER JOIN DeleveryOrder ON DeliveryLog.DOiD = DeleveryOrder.DOiD";
                cmd = new SqlCommand(ct,con);               
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
                string ct = "select DeleveryOrder.DOiD from DeleveryOrder  Except select DeliveryLog.DOiD from DeliveryLog";
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
        private void DeliveryOrderApproval_Load(object sender, EventArgs e)
        {
            userId = LoginForm.uId2.ToString();
            GetDeliveryOrderId();
            //GetFeederNameCombo();
        }

        private void GetFeederStock()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                //String sql = "SELECT RTRIM(FeederStockDetails.FeederName),RTRIM(MasterStocks.ImportOrderNo),RTRIM(Requisition.RequisitionNo),RTRIM(MasterStocks.MStockId),RTRIM(ProductListSummary.ProductGenericDescription),RTRIM(ProductListSummary.ItemCode),RTRIM(RequisitionList.Quantity),RTRIM(RequisitionList.RId)  FROM Requisition INNER JOIN FeederStockDetails ON Requisition.FeederId = FeederStockDetails.FeederId INNER JOIN Requisition AS Requisition_1 ON Requisition.ReqId = Requisition_1.ReqId INNER JOIN RequisitionList ON Requisition.ReqId = RequisitionList.ReqId AND Requisition_1.ReqId = RequisitionList.ReqId INNER JOIN  MasterStocks ON RequisitionList.MStockId = MasterStocks.MStockId INNER JOIN ProductListSummary ON MasterStocks.Sl = ProductListSummary.Sl where Requisition.RequisitionNo='" + cmbRequisitionNo.Text + "' and RequisitionList.Statuss is Null order by MasterStocks.MStockId asc";
                string sql = "SELECT RTRIM(FeederStock.RId),RTRIM(FeederStock.FeederId),RTRIM(ProductListSummary.ProductGenericDescription),RTRIM(ProductListSummary.ItemDescription),RTRIM(FeederStock.Quantity) FROM  FeederStock INNER JOIN  FeederStockDetails ON FeederStock.FeederId = FeederStockDetails.FeederId INNER JOIN  RequisitionList ON FeederStock.RId = RequisitionList.RId INNER JOIN Requisition ON RequisitionList.ReqId = Requisition.ReqId INNER JOIN  MasterStocks ON RequisitionList.MStockId = MasterStocks.MStockId INNER JOIN  ProductListSummary ON MasterStocks.Sl = ProductListSummary.Sl where FeederStock.Quantity>0 and FeederStock.FeederId='"+feederId+"'";
                cmd = new SqlCommand(sql, con);
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
        private void feederStockCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.CurrentRow;
                txtRId.Text = dr.Cells[0].Value.ToString();
                txtFeederId.Text = dr.Cells[1].Value.ToString();
                txtProductName.Text = dr.Cells[2].Value.ToString();
                txtModel.Text = dr.Cells[3].Value.ToString();
                txtQuantity.Text = dr.Cells[4].Value.ToString();               
                label6.Text = label1.Text;               

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetDeliveryOrder()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                //String sql = "SELECT RTRIM(FeederStockDetails.FeederName),RTRIM(MasterStocks.ImportOrderNo),RTRIM(Requisition.RequisitionNo),RTRIM(MasterStocks.MStockId),RTRIM(ProductListSummary.ProductGenericDescription),RTRIM(ProductListSummary.ItemCode),RTRIM(RequisitionList.Quantity),RTRIM(RequisitionList.RId)  FROM Requisition INNER JOIN FeederStockDetails ON Requisition.FeederId = FeederStockDetails.FeederId INNER JOIN Requisition AS Requisition_1 ON Requisition.ReqId = Requisition_1.ReqId INNER JOIN RequisitionList ON Requisition.ReqId = RequisitionList.ReqId AND Requisition_1.ReqId = RequisitionList.ReqId INNER JOIN  MasterStocks ON RequisitionList.MStockId = MasterStocks.MStockId INNER JOIN ProductListSummary ON MasterStocks.Sl = ProductListSummary.Sl where Requisition.RequisitionNo='" + cmbRequisitionNo.Text + "' and RequisitionList.Statuss is Null order by MasterStocks.MStockId asc";
                string sql = "SELECT ProductListSummary.ProductGenericDescription,ProductListSummary.ItemDescription, ProductQuotation.Quantity FROM   ProductQuotation INNER JOIN Quotation ON ProductQuotation.QuotationId = Quotation.QuotationId INNER JOIN  DeleveryOrder ON Quotation.QuotationId = DeleveryOrder.QuotationId INNER JOIN  ProductListSummary ON ProductQuotation.Sl = ProductListSummary.Sl where DeleveryOrder.DOiD='" + deliveryOrderCombo.Text + "'";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView2.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView2.Rows.Add(rdr[0], rdr[1], rdr[2]);
                }
                con.Close();
                GetFeederNameCombo();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void deliveryOrderCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            GetDeliveryOrder();

        }
        private void SaveDeliveryLog()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Insert into DeliveryLog(DOiD,ApprovedByUId,FeederId,ApprovedDateTime) Values(@d1,@d2,@d3,@d4)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@d1", deliveryOrderCombo.Text);
                cmd.Parameters.AddWithValue("@d2", userId);
                cmd.Parameters.AddWithValue("@d3", feederId);
                cmd.Parameters.AddWithValue("@d4", DateTime.UtcNow.ToLocalTime());
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Completed.", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ManualComplete()
        {
            DialogResult dialogResult = MessageBox.Show("Is Your Approval Completed for this Order? ", "Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SaveDeliveryLog();  
            }
            else if (dialogResult == DialogResult.No)
            {

                MessageBox.Show("Ready For Next  Order Item", "Sugession", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
        }
        private void Reset2()
        {
            txtRId.Clear();
            txtFeederId.Clear();
            txtProductName.Clear();
            txtModel.Clear();
            txtQuantity.Clear();
        }
        private void Reset1()
        {
            txtDOProductName.Clear();
            txtDOModel.Clear();
            txtDOQuantity.Clear();
        }
        public void ClearApprovedItem()
        {

            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {


                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                }

            }
            dataGridView1.Refresh();
        }
        private void buttonApprove_Click(object sender, EventArgs e)
        {
            try
            {
                  

                decimal feederquantity = Convert.ToDecimal(txtQuantity.Text);
                decimal dvQuantity = Convert.ToDecimal(txtDOQuantity.Text);
                if (txtDOModel.Text != txtModel.Text)
                {
                    MessageBox.Show("Please Select another Model", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }
                if (dvQuantity <= feederquantity)
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select Quantity from FeederStock where  FeederStock.FeederId='" + txtFeederId.Text + "' and FeederStock.RId='" + txtRId.Text + "' ";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        itemQuantity1 = (rdr.GetDecimal(0));
                    }
                    con.Close();

                    decimal ex = decimal.Parse(txtDOQuantity.Text);
                    itemQuantity2 = itemQuantity1 - ex;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb2 = "Update FeederStock set Quantity=" + itemQuantity2 + " where FeederStock.FeederId='" + txtFeederId.Text + "' and FeederStock.RId='" + txtRId.Text + "'";
                    cmd = new SqlCommand(cb2);
                    cmd.Connection = con;
                    cmd.ExecuteReader();
                    con.Close();
                    Reset1();
                    Reset2();
                    MessageBox.Show("Successfully Aprove this item", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearApprovedItem();
                    ManualComplete();                    
                }
                else
                {
                    MessageBox.Show("Please Select another item", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                    
               
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView2.CurrentRow;
                txtDOProductName.Text = dr.Cells[0].Value.ToString();
                txtDOModel.Text = dr.Cells[1].Value.ToString();
                txtDOQuantity.Text = dr.Cells[2].Value.ToString();
                label6.Text = label1.Text;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void feederStockCombo_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void feederStockCombo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select  RTRIM(FeederStockDetails.FeederId) from  FeederStockDetails where  FeederStockDetails.FeederName='" + feederStockCombo.Text + "'";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    feederId = (rdr.GetString(0));
                }
                con.Close();
                GetFeederStock();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
