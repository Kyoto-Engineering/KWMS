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
    public partial class frmWorkOrder : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        ConnectionString cs = new ConnectionString();
        SqlDataReader rdr;
        public string submittedBy, fullName;
        public frmWorkOrder()
        {
            InitializeComponent();
        }

        private void ManualComplete()
        {
            DialogResult dialogResult = MessageBox.Show("Are you Surely want To Complete or Done this Order ", "Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                try
                {
                    SaveSTatus();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //else if (dialogResult == DialogResult.No)
            //{

            //}
        }
        private void submitButton_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("Please add Product Item to Chart for Order", "Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProductId.Focus();
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

                for (int i = 0; i <= listView1.Items.Count - 1; i++)
                {
                    con = new SqlConnection(cs.DBConn);

                    string cd = "insert Into OrderListProduct(ImportOrderNo,OrderDates,Sl,ItemCode,OrderAmount,OrderPrice,OrderBy,ProductStatus) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)";
                    cmd = new SqlCommand(cd);
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("d1", cmbWorkOrderNo.Text);
                    cmd.Parameters.AddWithValue("d2", System.DateTime.UtcNow.ToLocalTime());
                    cmd.Parameters.AddWithValue("d3", listView1.Items[i].SubItems[1].Text);
                    cmd.Parameters.AddWithValue("d4", listView1.Items[i].SubItems[2].Text);
                    cmd.Parameters.AddWithValue("d5", listView1.Items[i].SubItems[3].Text);
                    cmd.Parameters.AddWithValue("d6", listView1.Items[i].SubItems[4].Text);
                    cmd.Parameters.AddWithValue("d7", fullName);
                    cmd.Parameters.AddWithValue("d8", "NotReceived");
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                MessageBox.Show("Successfully Submitted.", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listView1.Items.Clear();
                ManualComplete();
                submitButton.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(Sl) as ProductId,RTRIM(ProductGenericDescription),RTRIM(ItemDescription),RTRIM(ItemCode) from ProductListSummary  order by Sl desc", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1],rdr[2],rdr[3]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillWOrderCombo()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(ImportOrder.ImportOrderNo) from ImportOrder where ImportOrder.OrderStatus!='OrderComplete' order by ImportOrderNo";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbWorkOrderNo.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmWorkOrder_Load(object sender, EventArgs e)
        {
            cmbWorkOrderNo.Focus();
            FillWOrderCombo();
        
            GetData();
            submittedBy = LoginForm.uId2.ToString();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                txtProductId.Text = dr.Cells[0].Value.ToString();
                txtItemCode.Text = dr.Cells[3].Value.ToString();
                label7.Text = label1.Text;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void button1_Click(object sender, EventArgs e)
        {


            if (txtProductId.Text == "")
            {
                MessageBox.Show("You must select a  product first.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProductId.Focus();
                return;
            }
            if (txtItemCode.Text == "")
            {
                MessageBox.Show("Please select Item Code", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtItemCode.Focus();
                return;
            }
            if (txtOrderAmount.Text == "")
            {
                MessageBox.Show("Please enter Order Quantity.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOrderAmount.Focus();
                return;
            }
            if (txtOrderPrice.Text == "")
            {
                MessageBox.Show("Please enter Order Price.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOrderPrice.Focus();
                return;
            }

           


            try
            {
             
                if (listView1.Items.Count == 0)
                {
                    ListViewItem lst = new ListViewItem();
                    //lst.SubItems.Add(cmbWorkOrderNo.Text);
                    lst.SubItems.Add(txtProductId.Text);
                    lst.SubItems.Add(txtItemCode.Text);
                    lst.SubItems.Add(txtOrderAmount.Text);
                    lst.SubItems.Add(txtOrderPrice.Text);
                    listView1.Items.Add(lst);
                    //cmbWorkOrderNo.SelectedIndex = -1;
                    txtProductId.Text = "";
                    txtItemCode.Text = "";
                    txtOrderAmount.Text = "";
                    txtOrderPrice.Text = "";
                    return;
                }

                ListViewItem lst1 = new ListViewItem();
               
                //lst1.SubItems.Add(cmbWorkOrderNo.Text);
                lst1.SubItems.Add(txtProductId.Text);
                lst1.SubItems.Add(txtItemCode.Text);
                lst1.SubItems.Add(txtOrderAmount.Text);
                lst1.SubItems.Add(txtOrderPrice.Text);
                listView1.Items.Add(lst1);
                //cmbWorkOrderNo.SelectedIndex = -1;
                txtProductId.Text = "";
                txtItemCode.Text = "";
                txtOrderAmount.Text = "";
                txtOrderPrice.Text = "";
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtProduct_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String sql = "SELECT ProductListSummary.Sl,ProductListSummary.ProductGenericDescription,ProductListSummary.ItemDescription,ProductListSummary.ItemCode from ProductListSummary where ItemCode like '" + txtProduct.Text + "%'order by ProductListSummary.Sl desc";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1],rdr[2],rdr[3]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaveSTatus()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb2 = "Update ImportOrder set OrderStatus='OrderComplete' where ImportOrderNo='" + cmbWorkOrderNo.Text + "'";
                cmd = new SqlCommand(cb2);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Succesfully Done", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbWorkOrderNo.SelectedIndex = -1;
                FillWOrderCombo();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
            
        
        private void button2_Click(object sender, EventArgs e)
        {
            //SaveSTatus();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
           //this.Hide();
           // frmWorkOrder  fwo=new frmWorkOrder();
           // fwo.Show();
        }

        private void txtOrderAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtOrderPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {

            for (int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                if (listView1.Items[i].Selected)
                {
                    listView1.Items[i].Remove();
                }
            }


            //if (listView1.SelectedItems != null)
            //{
            //    var confirmation = MessageBox.Show(
            //        "Voulez vous vraiment supprimer les stagiaires séléctionnés?",
            //        "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question
            //    );

            //    if (confirmation == DialogResult.Yes)
            //    {
            //        for (int i = 0; i < listView1.Items.Count; i++)
            //        {
            //            if (listView1.Items[i].Selected)
            //            {
            //                listView1.Items[i].Remove();
            //                i--;
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("aucin stagiaire selectionnes", "erreur",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void productNameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String sql = "SELECT ProductListSummary.Sl,ProductListSummary.ProductGenericDescription,ProductListSummary.ItemDescription,ProductListSummary.ItemCode from ProductListSummary where ProductGenericDescription like '" + productNameTextBox.Text + "%'order by ProductListSummary.Sl desc";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1],rdr[2],rdr[3]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void itemDescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String sql = "SELECT ProductListSummary.Sl,ProductListSummary.ProductGenericDescription,ProductListSummary.ItemDescription,ProductListSummary.ItemCode from ProductListSummary where ItemDescription like '" + itemDescriptionTextBox.Text + "%'order by ProductListSummary.Sl desc";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1],rdr[2],rdr[3]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void cmbWorkOrderNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtProductId.Focus();
        }

        private void txtProductId_KeyDown(object sender, KeyEventArgs e)
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
                txtOrderAmount.Focus();
                e.Handled = true;
            }
        }

        private void txtOrderAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtOrderPrice.Focus();
                e.Handled = true;
            }
        }

        private void txtOrderPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
                e.Handled = true;
            }
        }
    }
}
