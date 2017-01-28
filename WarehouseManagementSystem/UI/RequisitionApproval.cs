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
//using WarehouseManagementSystem.HiddenForm;
using WarehouseManagementSystem.LoginUI;

namespace WarehouseManagementSystem.UI
{
    public partial class RequisitionApproval : Form
    {
        private SqlConnection con;
        private SqlDataReader rdr;
        private SqlCommand cmd;
        ConnectionString cs=new ConnectionString();
        public string submittedBy, fullName, feederId, rId;
        public decimal ReqNO,mQuantity,mUpdateQuantity;
        public int requisitionListId;

        public RequisitionApproval()
        {
            InitializeComponent();
        }
        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
               // cmd = new SqlCommand("SELECT RTRIM(MasterStocks.ImportOrderNo),RTRIM(MasterStocks.MStockId),RTRIM(ProductListSummary.ProductGenericDescription),RTRIM(ProductListSummary.ItemCode),RTRIM(RequisitionList.Quantity) FROM (MasterStocks INNER JOIN RequisitionList ON MasterStocks.MStockId = RequisitionList.MStockId) INNER JOIN ProductListSummary ON MasterStocks.Sl = ProductListSummary.Sl order by MasterStocks.MStockId asc", con);
                cmd = new SqlCommand("SELECT RTRIM(MasterStocks.ImportOrderNo),RTRIM(Requisition.RequisitionNo),RTRIM(MasterStocks.MStockId),RTRIM(ProductListSummary.ProductGenericDescription),RTRIM(ProductListSummary.ItemCode),RTRIM(RequisitionList.Quantity) FROM ((Requisition INNER JOIN RequisitionList on Requisition.ReqId=RequisitionList.ReqId) INNER JOIN MasterStocks ON MasterStocks.MStockId = RequisitionList.MStockId) INNER JOIN ProductListSummary ON MasterStocks.Sl = ProductListSummary.Sl order by MasterStocks.MStockId asc", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4],rdr[5]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Reset()
        {
            cmbRequisitionNo.SelectedIndex = -1;
            txtImportOrderNo.Text = "";
            txtMasterStockProductId.Text = "";
            txtItemCode.Text = "";
            txtRequisitionAmount.Text = "";
            txtReceiveAmount.Text = "";
            cmbActionStatus.SelectedIndex = -1;
            txtFeederStockName.Clear();
        }
        private void Reset1()
        {
           
            txtImportOrderNo.Text = "";
            txtMasterStockProductId.Text = "";
            txtItemCode.Text = "";
            txtRequisitionAmount.Text = "";
            txtReceiveAmount.Text = "";
            cmbActionStatus.SelectedIndex = -1;
            label9.Visible = false;
            txtReceiveAmount.Visible = false;
        }
        public void FillRequisitionNoCombo()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Requisition.RequisitionNo) from Requisition where Requisition.RequisitionStatus!='Confirm' order by RequisitionNo";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbRequisitionNo.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RequisitionApproval_Load(object sender, EventArgs e)
        {
            cmbRequisitionNo.Focus();
            FillRequisitionNoCombo();          
            submittedBy = LoginForm.uId2.ToString();
            label9.Visible = false;
            txtReceiveAmount.Visible = false;
        }

       

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

       
        private void SaveRSTatus()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb2 = "Update Requisition set RequisitionStatus='Confirm' where RequisitionNo='" + cmbRequisitionNo.Text + "'";
                cmd = new SqlCommand(cb2);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("All Requested item is covered", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                cmbRequisitionNo.Items.Clear();
                cmbRequisitionNo.Enabled = true;
                
              
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void UpdateProductRequisitionStatus()
        {
            try
            {
                if (cmbActionStatus.Text == "Approved")
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb2 = "Update RequisitionList set Statuss='Approved' where  RequisitionList.RId='" + rId + "'";
                    cmd = new SqlCommand(cb2);
                    cmd.Connection = con;
                    cmd.ExecuteReader();
                    con.Close();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ManualComplete()
        {
            
                UpdateProductRequisitionStatus();
                ClearApprovedRequisition();
                DataChangedByRequisitionNumber();
            if (dataGridView1.RowCount == 1)
            {
                SaveRSTatus();
                Reset();
                FillRequisitionNoCombo();
            }
                        
        }
        private void submitButton_Click(object sender, EventArgs e)
        {
            if (cmbRequisitionNo.Text == "")
            {
                MessageBox.Show("Please Select Requisition  Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbRequisitionNo.Focus();
                return;
            }

            if (txtReceiveAmount.Text == "")
            {
                MessageBox.Show("Please enter receive Amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtReceiveAmount.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctr = "select CurrentQuantity from MasterStocks where ImportOrderNo='" + txtImportOrderNo.Text + "' and Sl='" + txtMasterStockProductId.Text + "'";
                cmd = new SqlCommand(ctr);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    mQuantity = (rdr.GetDecimal(0));
                }
                con.Close();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select ReqId from Requisition where RequisitionNo='" + cmbRequisitionNo.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    ReqNO = (rdr.GetDecimal(0));
                }
                con.Close();

                con=new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select RId from  RequisitionList  where  RequisitionList.ReqId='" + ReqNO + "' and  RequisitionList.MStockId='"+txtMasterStockProductId.Text+"'";
                cmd=new SqlCommand(query,con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    requisitionListId = (rdr.GetInt32(0));
                }


                mUpdateQuantity = mQuantity -decimal.Parse(txtReceiveAmount.Text);
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cdu = "Update MasterStocks Set CurrentQuantity=" + mUpdateQuantity + "  Where ImportOrderNo='" + txtImportOrderNo.Text + "' and Sl='" + txtMasterStockProductId.Text + "'";
                cmd = new SqlCommand(cdu);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cd = "insert Into FeederStock(RId,Quantity,FeederId) VALUES (@d1,@d2,@d3)";
                cmd = new SqlCommand(cd);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("d1", requisitionListId);
                cmd.Parameters.AddWithValue("d2", txtReceiveAmount.Text);
                cmd.Parameters.AddWithValue("d3", feederId);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Submit Successfully", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ManualComplete();
                Reset1();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtReceiveAmount_Validating(object sender, CancelEventArgs e)
        {
            int val1 = 0;
            int val2 = 0;
            int.TryParse(txtRequisitionAmount.Text, out val1);
            int.TryParse(txtReceiveAmount.Text, out val2);
            if (val2 > val1)
            {
                MessageBox.Show("Receive amount are more than Requested quantities or amount", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtReceiveAmount.Text = "";
                txtReceiveAmount.Focus();
                return;
            }
        }

        private void txtReceiveAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        public void ClearApprovedRequisition()
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
        private void DataChangedByRequisitionNumber()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String sql = "SELECT RTRIM(FeederStockDetails.FeederName),RTRIM(MasterStocks.ImportOrderNo),RTRIM(Requisition.RequisitionNo),RTRIM(MasterStocks.MStockId),RTRIM(ProductListSummary.ProductGenericDescription),RTRIM(ProductListSummary.ItemCode),RTRIM(RequisitionList.Quantity),RTRIM(RequisitionList.RId)  FROM Requisition INNER JOIN FeederStockDetails ON Requisition.FeederId = FeederStockDetails.FeederId INNER JOIN Requisition AS Requisition_1 ON Requisition.ReqId = Requisition_1.ReqId INNER JOIN RequisitionList ON Requisition.ReqId = RequisitionList.ReqId AND Requisition_1.ReqId = RequisitionList.ReqId INNER JOIN  MasterStocks ON RequisitionList.MStockId = MasterStocks.MStockId INNER JOIN ProductListSummary ON MasterStocks.Sl = ProductListSummary.Sl where Requisition.RequisitionNo='" + cmbRequisitionNo.Text + "' and RequisitionList.Statuss is Null order by MasterStocks.MStockId asc";
                //string sql =" SELECT RTRIM(MasterStocks.ImportOrderNo),RTRIM(Requisition.RequisitionNo),RTRIM(MasterStocks.MStockId),RTRIM(ProductListSummary.ProductGenericDescription),RTRIM(ProductListSummary.ItemCode),RTRIM(RequisitionList.Quantity) FROM ((Requisition INNER JOIN RequisitionList on Requisition.ReqId=RequisitionList.ReqId) INNER JOIN MasterStocks ON MasterStocks.MStockId = RequisitionList.MStockId) INNER JOIN ProductListSummary ON MasterStocks.Sl = ProductListSummary.Sl where Requisition.RequisitionNo='"+cmbRequisitionNo.Text+"' order by MasterStocks.MStockId asc";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4],rdr[5],rdr[6],rdr[7]);
                }
                con.Close();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbRequisitionNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtImportOrderNo.Focus();
            DataChangedByRequisitionNumber();
        }

        private void dataGridView1_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                txtFeederStockName.Text = dr.Cells[0].Value.ToString();
                txtImportOrderNo.Text = dr.Cells[1].Value.ToString();
                txtMasterStockProductId.Text = dr.Cells[3].Value.ToString();
                txtItemCode.Text = dr.Cells[5].Value.ToString();
                txtRequisitionAmount.Text = dr.Cells[6].Value.ToString();
                rId = dr.Cells[7].Value.ToString();
                label7.Text = label1.Text;
                cmbRequisitionNo.Enabled = false;
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void Windowchanged()
        {
            cmbRequisitionNo.SelectedIndex = -1;
            this.Hide();
            
            RequisitionApproval frm3 = new RequisitionApproval();
            frm3.Show();
          
        }
        private void newButton_Click(object sender, EventArgs e)
        {
            cmbRequisitionNo.SelectedIndex = -1;
            cmbRequisitionNo.Enabled = true;
        }

        private void txtImportOrderNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMasterStockProductId.Focus();
                e.Handled = true;
            }
        }

        private void txtMasterStockProductId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtItemCode.Focus();
                e.Handled = true;
            }
        }

        private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRequisitionAmount.Focus();
                e.Handled = true;
            }
        }

        private void txtRequisitionAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtReceiveAmount.Focus();
                e.Handled = true;
            }
        }

        private void txtReceiveAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbActionStatus.Focus();
                e.Handled = true;
            }
        }

        private void cmbActionStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbActionStatus.Text == "Approved")
            {
                label9.Visible = true;
                txtReceiveAmount.Visible = true;
                deniedButton.Visible = false;
                submitButton.Visible = true;
            }
            if (cmbActionStatus.Text == "Denied")
            {
                label9.Visible = false;
                txtReceiveAmount.Visible = false;
                deniedButton.Visible = true;
                submitButton.Visible = false;
            }
        }

        private void txtFeederStockName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT  RTRIM(FeederStockDetails.FeederId) from FeederStockDetails WHERE FeederStockDetails.FeederName = '" + txtFeederStockName.Text + "'";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {

                    feederId = (rdr.GetString(0));


                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.CurrentRow;
                txtFeederStockName.Text = dr.Cells[0].Value.ToString();
                txtImportOrderNo.Text = dr.Cells[1].Value.ToString();
                txtMasterStockProductId.Text = dr.Cells[3].Value.ToString();
                txtItemCode.Text = dr.Cells[5].Value.ToString();
                txtRequisitionAmount.Text = dr.Cells[6].Value.ToString();
                rId = dr.Cells[7].Value.ToString();
                label7.Text = label1.Text;
                cmbRequisitionNo.Enabled = false;
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deniedButton_Click(object sender, EventArgs e)
        {
            if (cmbActionStatus.Text == "Denied")
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb2 = "Update RequisitionList set Statuss='Denied' where  RequisitionList.RId='" + rId + "'";
                cmd = new SqlCommand(cb2);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
            }
            ClearApprovedRequisition();
            MessageBox.Show("Denied Successfully.", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Reset1();
        }
    }
}
