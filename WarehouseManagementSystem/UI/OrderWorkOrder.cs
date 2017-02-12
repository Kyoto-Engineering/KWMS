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
    public partial class OrderWorkOrder : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        ConnectionString cs = new ConnectionString();
        SqlDataReader rdr;
        public string submittedBy, fullName;
        public OrderWorkOrder()
        {
            InitializeComponent();
        }
        private void Reset3()
        {
            txtImportOrderNo.Clear();
            importOrderDate.Value = System.DateTime.Today;
            lcNumberTextBox.Clear();
            lcDate.Value = System.DateTime.Today;
            invoiceNumberTextBox.Clear();
            invoiceDate.Value = System.DateTime.Today;
            packingListNoTextBox.Clear();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtImportOrderNo.Text == "")
            {
                MessageBox.Show("Please type Purchase Order", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtImportOrderNo.Focus();
                return;
            }
           if (invoiceNumberTextBox.Text == "")
            {
                MessageBox.Show("Please type  Invoice No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                invoiceNumberTextBox.Focus();
                return;
            }
            if (packingListNoTextBox.Text == "")
            {
                MessageBox.Show("Please type Packing List No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                packingListNoTextBox.Focus();
                return;
            }

            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select ImportOrderNo from ImportOrder where ImportOrderNo='" + txtImportOrderNo.Text + "'";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("This Import Order Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtImportOrderNo.Text = "";
                    txtImportOrderNo.Focus();


                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into ImportOrder(ImportOrderNo,OrderDate,LCNumber,LCDate,InvoiceNumber,InvoiceDate,PackingListNo,OrderStatus,ReceiveStatus,OrderByUId,OrderEntryDate) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtImportOrderNo.Text);
                cmd.Parameters.AddWithValue("@d2", Convert.ToDateTime(importOrderDate.Value, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                cmd.Parameters.AddWithValue("@d3", lcNumberTextBox.Text);
                cmd.Parameters.AddWithValue("@d4", Convert.ToDateTime(lcDate.Value, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                cmd.Parameters.AddWithValue("@d5", invoiceNumberTextBox.Text);
                cmd.Parameters.AddWithValue("@d6", Convert.ToDateTime(invoiceDate.Value, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                cmd.Parameters.AddWithValue("@d7", packingListNoTextBox.Text);
                cmd.Parameters.AddWithValue("@d8", "NewOrder");
                cmd.Parameters.AddWithValue("@d9", "NewOrder");
                cmd.Parameters.AddWithValue("@d10",submittedBy);
                cmd.Parameters.AddWithValue("@d11", System.DateTime.UtcNow.ToLocalTime());
                cmd.ExecuteReader();
                con.Close();

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
                MessageBox.Show("Successfully Submitted.", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                Reset3();
                this.Dispose();
                                   this.Hide();
                        PreviousOrderList frm = new PreviousOrderList();
                                      frm.GetData2();
                                       frm.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void GetData2()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(ImportOrderNo),RTRIM(OrderDate),RTRIM(LCNumber),RTRIM(LCDate),RTRIM(InvoiceNumber),RTRIM(InvoiceDate),RTRIM(PackingListNo) from  ImportOrder  order by ImportOrderNo desc", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                PreviousOrderList afrm=new PreviousOrderList();
                afrm.dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    afrm.dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void OrderWorkOrder_Load(object sender, EventArgs e)
        {
            submittedBy = LoginForm.uId2.ToString();
            txtImportOrderNo.Focus();
            timer1.Interval = 500;
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtImportOrderNo.ReadOnly=false;
            importOrderDate.Enabled = true;
            lcNumberTextBox.ReadOnly = false;
            lcDate.Enabled = true;
            invoiceNumberTextBox.ReadOnly = false;
            invoiceDate.Enabled = true;
            packingListNoTextBox.ReadOnly = false;
            txtImportOrderNo.Focus();





        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label8.Visible = !this.label8.Visible;
        }

        private void purchaseOrderNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                importOrderDate.Focus();
                e.Handled = true;
            }
        }

        private void importOrderDate_ValueChanged(object sender, EventArgs e)
        {
            lcNumberTextBox.Focus();
        }

        private void lcNumberTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lcDate.Focus();
                e.Handled = true;
            }
        }

        private void lcDate_ValueChanged(object sender, EventArgs e)
        {
            invoiceNumberTextBox.Focus();
        }

        private void invoiceNumberTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                invoiceDate.Focus();
                e.Handled = true;
            }
        }

        private void invoiceDate_ValueChanged(object sender, EventArgs e)
        {
            packingListNoTextBox.Focus();
        }

        private void packingListNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
       PreviousOrderList frm=new PreviousOrderList();
            frm.Show();
        }
    }
}
