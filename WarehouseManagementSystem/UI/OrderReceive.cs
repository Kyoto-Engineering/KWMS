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
    public partial class OrderReceive : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public int affectedRows1, affectedRows2, productId;
        public string submittedBy, fullName, iOId;
        public OrderReceive()
        {
            InitializeComponent();
        }


        private void ChangeStatusr()
        {
            DialogResult dialogResult = MessageBox.Show("Is Your Product Receiving Finished?.", "Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb2 = "Update WorkOrder Set WorkOrder.ReceiveStatus='ReceiveDone' where WorkOrder.WorkOrderNo='" + cmbImportOrderNo.Text + "'";
                cmd = new SqlCommand(cb2);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully Done ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            

        }
        private void UpdateProductStatus()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb2 = "Update OrderListProduct set ProductStatus='Received' where Sl='" + txtProductId.Text + "' and IOId='" + iOId + "'";
                cmd = new SqlCommand(cb2);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Reset1()
        {
            txtProductId.Clear();
            receiveDate.Text = DateTime.Today.ToString();
            txtReceiveQuantity.Clear();
            txtReceiveUnitPrice.Clear();
            txtCOGSUnitPrice.Clear();
        }
        private void Reset()
        {
            Reset1();
            cmbImportOrderNo.SelectedIndexChanged -= cmbWorkOrderNo_SelectedIndexChanged;
            cmbImportOrderNo.Items.Clear();
            cmbImportOrderNo.SelectedIndex = -1;
            cmbImportOrderNo.SelectedIndexChanged += cmbWorkOrderNo_SelectedIndexChanged;
           
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
        private void ManualComplete()
        {

            UpdateProductStatus();
            ClearApprovedRequisition();
            DataChangedByImportOrderNumber();
            if (dataGridView1.RowCount == 1)
            {
                SaveRSTatus();
                Reset();
                PopulateImportOrderNo();
            }

        }
        private void ManualComplete2()
        {
            DialogResult dialogResult = MessageBox.Show("Is Your Receiving Completed? ", "Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                try
                {
                    SaveSTatus();
                    Reset();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                txtProductId.Clear();
                txtReceiveQuantity.Clear();
                txtReceiveUnitPrice.Clear();
                receiveDate.Value=DateTime.Now;
                
            }
        }
        private void SaveRSTatus()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb2 = "Update ImportOrder set ReceiveStatus=@d1,ReceivedCompletedByUId=@d2,ReceivedEntryDate=@d3 where ImportOrderNo='" + cmbImportOrderNo.Text + "'";
                cmd = new SqlCommand(cb2,con);
                cmd.Parameters.AddWithValue("@d1", "ReceiveComplete");
                cmd.Parameters.AddWithValue("@d2", submittedBy);
                cmd.Parameters.AddWithValue("@d3", System.DateTime.UtcNow.ToLocalTime());
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("All Requested item is covered", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbImportOrderNo.Items.Clear();
                cmbImportOrderNo.Enabled = true;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void receiveOrderButton_Click(object sender, EventArgs e)
        {
            if (txtProductId.Text == "")
            {
                MessageBox.Show("Please select Product Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProductId.Focus();
                return;
            }
            if (cmbImportOrderNo.Text == "")
            {
                MessageBox.Show("Please select PurchaseOrderNo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbImportOrderNo.Focus();
                return;
            }

            if (txtReceiveQuantity.Text == "")
            {
                MessageBox.Show("Please enter receive Amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtReceiveQuantity.Focus();
                return;
            }
            if (txtReceiveUnitPrice.Text == "")
            {
                MessageBox.Show("Please enter receive price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtReceiveUnitPrice.Focus();
                return;
            }

            try
            {
                
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cd = "Update OrderListProduct Set ReceiveQuantity=@d1,ReceivePrice=@d2,ProductStatus=@d3 Where IOId='" + iOId + "'and Sl='" + txtProductId.Text + "'";
                cmd = new SqlCommand(cd);
                cmd.Connection = con; 
                cmd.Parameters.AddWithValue("@d1", txtReceiveQuantity.Text);
                cmd.Parameters.AddWithValue("@d2", txtReceiveUnitPrice.Text);              
                cmd.Parameters.AddWithValue("@d3", "Received");
                cmd.ExecuteReader();
                con.Close();

              
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "insert Into MasterStocks(Sl,IOId,MQuantity,CurrentQuantity,UnitPrice,COGSPerUnit) VALUES (@cd1,@cd2,@cd3,@cd3,@cd4,@cd5)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@cd1", txtProductId.Text);
                    cmd.Parameters.AddWithValue("@cd2", iOId);
                    cmd.Parameters.AddWithValue("@cd3", txtReceiveQuantity.Text);
                    cmd.Parameters.AddWithValue("@cd4", txtReceiveUnitPrice.Text);
                    cmd.Parameters.AddWithValue("@cd5", txtCOGSUnitPrice.Text);
                    affectedRows2 = (int) cmd.ExecuteScalar();
                    con.Close();
                    MessageBox.Show("Successfully Received", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                    ManualComplete();
                    Reset1();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //public void PopulateProductIdCombo()
        //{
        //    try
        //    {

        //        con = new SqlConnection(cs.DBConn);
        //        con.Open();
        //        string ct = "select RTRIM(Sl) from ProductListSummary order by Sl";
        //        cmd = new SqlCommand(ct);
        //        cmd.Connection = con;
        //        rdr = cmd.ExecuteReader();

        //        while (rdr.Read())
        //        {
        //            cmbProductId.Items.Add(rdr[0]);
        //        }
        //        con.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        public void PopulateImportOrderNo()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
               // string ct = "select RTRIM(PurchaseOrderNo) from PurchaseOrder Where OrderStatus !='NewOrder'";
                string ct = "select RTRIM(ImportOrderNo) from ImportOrder Where ReceiveStatus !='ReceiveComplete' and OrderStatus !='NewOrder' ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbImportOrderNo.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void OrderReceive_Load(object sender, EventArgs e)
        {
            submittedBy = LoginForm.uId2.ToString();           
            PopulateImportOrderNo();
            cmbImportOrderNo.Focus();
        }
        private void DataChangedByImportOrderNumber()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();              
                string sql = "SELECT ImportOrder.ImportOrderNo,pp.Sl,pp.ProductGenericDescription,pp.ItemCode FROM   OrderListProduct INNER JOIN  ProductListSummary AS pp ON OrderListProduct.Sl = pp.Sl INNER JOIN ImportOrder ON OrderListProduct.IOId = ImportOrder.IOId Where OrderListProduct.ProductStatus !='Received' and OrderListProduct.IOId ='"+iOId+"'";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3]);
                }
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetIOIdByImportOrderNo()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(ImportOrder.IOId) from ImportOrder Where ImportOrder.ImportOrderNo ='"+cmbImportOrderNo.Text+"'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    iOId = (rdr.GetString(0));
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }
        private void cmbWorkOrderNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetIOIdByImportOrderNo();
            DataChangedByImportOrderNumber();

        }

        private void cmbProductId_SelectedIndexChanged(object sender, EventArgs e)
        {
            receiveDate.Focus();
        }

        
        private void SaveSTatus()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb2 = "Update ImportOrder set ReceiveStatus='ReceiveComplete' where ImportOrderNo='" + cmbImportOrderNo.Text + "'";
                cmd = new SqlCommand(cb2);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully Done", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
            
        private void doneButton_Click(object sender, EventArgs e)
        {
            SaveSTatus();
        }

        private void receivePriceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtReceiveUnitPrice.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void receiveQuantityTextBox_KeyPress(object sender, KeyPressEventArgs e)
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

        private void localStoreButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            dynamic afrm = new GridForLocalStore();
            afrm.ShowDialog();
            this.Visible = true;
           

        }

        private void receiveDate_ValueChanged(object sender, EventArgs e)
        {
            txtReceiveQuantity.Focus();
        }

        private void receiveQuantityTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtReceiveUnitPrice.Focus();
                e.Handled = true;
            }
        }

        private void receivePriceTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                receiveOrderButton.Focus();
                e.Handled = true;
            }
                                              
        }

        private void txtCOGSUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtCOGSUnitPrice.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //cmbWorkOrderNo.Enabled = false;
                DataGridViewRow dr = dataGridView1.CurrentRow;
                txtProductId.Text = dr.Cells[1].Value.ToString();
               
                g.Text = k.Text;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
