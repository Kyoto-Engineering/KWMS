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
        public string submittedBy, fullName;
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
                string cb2 = "Update WorkOrder Set WorkOrder.ReceiveStatus='ReceiveDone' where WorkOrder.WorkOrderNo='" + cmbPurchaseOrderNo.Text + "'";
                cmd = new SqlCommand(cb2);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully Done ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            

        }
        private void SaveRSTatus()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb2 = "Update OrderListProduct set ProductStatus='Received' where Sl='" + cmbProductId.Text + "' and ImportOrderNo='"+cmbPurchaseOrderNo.Text+"'";
                cmd = new SqlCommand(cb2);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
               // MessageBox.Show("Successfully Received", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
               // Reset3();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void Reset()
        {
            cmbPurchaseOrderNo.SelectedIndexChanged -= cmbWorkOrderNo_SelectedIndexChanged;
            cmbPurchaseOrderNo.Items.Clear();
            cmbPurchaseOrderNo.SelectedIndex = -1;
            cmbPurchaseOrderNo.SelectedIndexChanged += cmbWorkOrderNo_SelectedIndexChanged;
            cmbProductId.SelectedIndexChanged -= cmbProductId_SelectedIndexChanged;
            cmbProductId.Items.Clear();
            cmbProductId.SelectedIndex = -1;
            cmbProductId.SelectedIndexChanged += cmbProductId_SelectedIndexChanged;
            receiveDate.Text = DateTime.Today.ToString();
            receiveQuantityTextBox.Text = "";
            receivePriceTextBox.Text = "";
        }

        private void ManualComplete()
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
                cmbProductId.Items.Clear();
                receiveQuantityTextBox.Clear();
                receivePriceTextBox.Clear();
                receiveDate.Value=DateTime.Now;
                try
                {
                    con = new SqlConnection(cs.DBConn);

                    con.Open();
                    cmd = con.CreateCommand();

                    cmd.CommandText = "SELECT OrderListProduct.Sl from OrderListProduct WHERE ProductStatus !='Received' and  OrderListProduct.ImportOrderNo = '" + cmbPurchaseOrderNo.Text + "'";
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        cmbPurchaseOrderNo.Text = rdr.GetInt32(0).ToString().Trim();
                    }
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    cmbPurchaseOrderNo.Text = cmbPurchaseOrderNo.Text.Trim();
                    cmbProductId.Items.Clear();
                    cmbProductId.Text = "";
                    cmbProductId.Enabled = true;
                    cmbProductId.Focus();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select distinct RTRIM(OrderListProduct.Sl) from OrderListProduct  Where OrderListProduct.ProductStatus !='Received' and OrderListProduct.ImportOrderNo= '" + cmbPurchaseOrderNo.Text + "' ";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        cmbProductId.Items.Add(rdr[0]);
                    }
                    con.Close();

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
        }
        private void receiveOrderButton_Click(object sender, EventArgs e)
        {
            if (cmbProductId.Text == "")
            {
                MessageBox.Show("Please select Product Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProductId.Focus();
                return;
            }
            if (cmbPurchaseOrderNo.Text == "")
            {
                MessageBox.Show("Please select PurchaseOrderNo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbPurchaseOrderNo.Focus();
                return;
            }

            if (receiveQuantityTextBox.Text == "")
            {
                MessageBox.Show("Please enter receive Amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                receiveQuantityTextBox.Focus();
                return;
            }
            if (receivePriceTextBox.Text == "")
            {
                MessageBox.Show("Please enter receive price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                receivePriceTextBox.Focus();
                return;
            }

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cty4 = "select Name from Registration where UserId='" + submittedBy + "'";
                cmd = new SqlCommand(cty4);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    fullName = (rdr.GetString(0));
                }


                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cd = "Update OrderListProduct Set ReceiveQuantity=@d3,ReceivePrice=@d4,ReceiveDateTime=@d5,ReceiveBy=@d8 Where ImportOrderNo='" + cmbPurchaseOrderNo.Text + "'and Sl='" + cmbProductId.Text + "'";
                cmd = new SqlCommand(cd);
                cmd.Connection = con; 
                cmd.Parameters.AddWithValue("@d3", receiveQuantityTextBox.Text);
                cmd.Parameters.AddWithValue("@d4", receivePriceTextBox.Text);
                cmd.Parameters.AddWithValue("@d5", Convert.ToDateTime(receiveDate.Value, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                cmd.Parameters.AddWithValue("@d8", fullName);
                cmd.ExecuteReader();
                con.Close();

              
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "insert Into MasterStocks(Sl,ImportOrderNo,MQuantity,CurrentQuantity,UnitPrice,COGSPerUnit) VALUES (@cd1,@cd2,@cd3,@cd3,@cd4,@cd5)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@cd1", cmbProductId.Text);
                    cmd.Parameters.AddWithValue("@cd2", cmbPurchaseOrderNo.Text);
                    cmd.Parameters.AddWithValue("@cd3", receiveQuantityTextBox.Text);
                    cmd.Parameters.AddWithValue("@cd4", receivePriceTextBox.Text);
                    cmd.Parameters.AddWithValue("@cd5", txtCOGSUnitPrice.Text);
                    affectedRows2 = (int) cmd.ExecuteScalar();
                    con.Close();
                    MessageBox.Show("Successfully Received", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SaveRSTatus();
                   ManualComplete();
                    
               
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

        public void PopulatePurchaseOrderNo()
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
                    cmbPurchaseOrderNo.Items.Add(rdr[0]);
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
            //PopulateProductIdCombo();
            PopulatePurchaseOrderNo();
            cmbPurchaseOrderNo.Focus();
        }

        private void cmbWorkOrderNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbProductId.Focus();
            try
            {
                con = new SqlConnection(cs.DBConn);

                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "SELECT OrderListProduct.Sl from OrderListProduct WHERE ProductStatus !='Received' and  OrderListProduct.ImportOrderNo = '" + cmbPurchaseOrderNo.Text + "'";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    cmbPurchaseOrderNo.Text = rdr.GetInt32(0).ToString().Trim();
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                cmbPurchaseOrderNo.Text = cmbPurchaseOrderNo.Text.Trim();
                cmbProductId.Items.Clear();
                cmbProductId.Text = "";
                cmbProductId.Enabled = true;
                cmbProductId.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(OrderListProduct.Sl) from OrderListProduct  Where OrderListProduct.ProductStatus !='Received' and OrderListProduct.ImportOrderNo= '" + cmbPurchaseOrderNo.Text + "' ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbProductId.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbProductId_SelectedIndexChanged(object sender, EventArgs e)
        {
            receiveDate.Focus();
        }

        //private void Reset3()
        //{
        //    cmbPurchaseOrderNo.SelectedIndex = -1;
        //    cmbProductId.SelectedIndex = -1;
        //    receiveDate.Text = DateTime.Today.ToString();
        //}
        private void SaveSTatus()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb2 = "Update ImportOrder set ReceiveStatus='ReceiveComplete' where ImportOrderNo='" + cmbPurchaseOrderNo.Text + "'";
                cmd = new SqlCommand(cb2);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully Done", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Reset3();
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
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
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
            receiveQuantityTextBox.Focus();
        }

        private void receiveQuantityTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                receivePriceTextBox.Focus();
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
            
            
            
            //if (e.KeyCode == Keys.Enter)
            //{
            //    receiveOrderButton_Click(this, new EventArgs());
            //}
        }
    }
}
