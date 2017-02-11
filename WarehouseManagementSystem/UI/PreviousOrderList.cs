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
    public partial class PreviousOrderList : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        ConnectionString cs = new ConnectionString();
        SqlDataReader rdr;
        public string submittedBy, fullName;
        public PreviousOrderList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SecondStepOfPurchaseOrder mn=new SecondStepOfPurchaseOrder();
            mn.Show();
            GetData2();

            //this.Visible = false;
            //dynamic my=new OrderWorkOrder();
            //this.Visible = true;
            //my.ShowDialog();
            //GetData2();

        }
        public void GetData2()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(ImportOrderNo),RTRIM(OrderDate),RTRIM(LCNumber),RTRIM(LCDate),RTRIM(InvoiceNumber),RTRIM(InvoiceDate),RTRIM(PackingListNo) from  ImportOrder  order by ImportOrderNo desc", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4],rdr[5],rdr[6]);
                }
                con.Close();
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
                cmd = new SqlCommand("SELECT RTRIM(Sl) as ProductId,RTRIM(ItemCode) from ProductListSummary  order by Sl desc", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreviousOrderList_Load(object sender, EventArgs e)
        {
            txtImportOrder.Focus();
            GetData2();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
           
        }

        private void txtImportOrder_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String sql = "SELECT ImportOrder.ImportOrderNo,ImportOrder.OrderDate,ImportOrder.LCNumber,ImportOrder.LCDate,ImportOrder.InvoiceNumber,ImportOrder.InvoiceDate,ImportOrder.PackingListNo from ImportOrder where ImportOrder.ImportOrderNo like '" + txtImportOrder.Text + "%'order by ImportOrder.ImportOrderNo desc";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3],rdr[4],rdr[5],rdr[6]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMainUI frm = new frmMainUI();
            frm.Show();
        }

        private void PreviousOrderList_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            frmMainUI frm = new frmMainUI();
            frm.Show();
        }
    }
}
