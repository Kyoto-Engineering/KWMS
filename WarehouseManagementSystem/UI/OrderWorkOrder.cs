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
            purchaseOrderNoTextBox.Text = "";
            importOrderDate.Text = "";
            lcNumberTextBox.Text = "";
            lcDate.Text = "";
            invoiceNumberTextBox.Text = "";
            invoiceDate.Text = "";
            packingListNoTextBox.Text = "";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (purchaseOrderNoTextBox.Text == "")
            {
                MessageBox.Show("Please type Purchase Order", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                purchaseOrderNoTextBox.Focus();
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
                string ct = "select ImportOrderNo from ImportOrder where ImportOrderNo='" + purchaseOrderNoTextBox.Text + "'";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("This Import Order Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    purchaseOrderNoTextBox.Text = "";
                    purchaseOrderNoTextBox.Focus();


                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into ImportOrder(ImportOrderNo,OrderDate,LCNumber,LCDate,InvoiceNumber,InvoiceDate,PackingListNo,OrderStatus,ReceiveStatus) VALUES (@wOrderNo,@Od1,@lcNo,@lcDate,@invoiceNumber,@Id2,@packingListNo,'NewOrder','NewOrder')";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@wOrderNo", purchaseOrderNoTextBox.Text);
                cmd.Parameters.AddWithValue("@Od1", Convert.ToDateTime(importOrderDate.Value, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                cmd.Parameters.AddWithValue("@lcNo", lcNumberTextBox.Text);
                cmd.Parameters.AddWithValue("@lcDate", Convert.ToDateTime(lcDate.Value, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                cmd.Parameters.AddWithValue("@invoiceNumber", invoiceNumberTextBox.Text);
                cmd.Parameters.AddWithValue("@Id2", Convert.ToDateTime(invoiceDate.Value, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                cmd.Parameters.AddWithValue("@packingListNo", packingListNoTextBox.Text);
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
                GetData2();
                Reset3();
                                   this.Hide();
                SecondStepOfPurchaseOrder frm=new SecondStepOfPurchaseOrder();
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
            purchaseOrderNoTextBox.Focus();
            timer1.Interval = 500;
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            purchaseOrderNoTextBox.ReadOnly=false;
            importOrderDate.Enabled = true;
            lcNumberTextBox.ReadOnly = false;
            lcDate.Enabled = true;
            invoiceNumberTextBox.ReadOnly = false;
            invoiceDate.Enabled = true;
            packingListNoTextBox.ReadOnly = false;
            purchaseOrderNoTextBox.Focus();





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
    }
}
