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
    public partial class SecondStepOfPurchaseOrder : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;

        ConnectionString cs=new ConnectionString();

        public SecondStepOfPurchaseOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtImportOrder.Text == "")
            {
                MessageBox.Show("Please Type Correct Import  Order.", "error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtImportOrder.Focus();
                return;
            }
            if (txtInvoiceNumber.Text == "")
            {
                MessageBox.Show("Please Type Correct Invoice Number.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInvoiceNumber.Focus();
                return;
            }
            if (txtPackingListNo.Text == "")
            {
                MessageBox.Show("Please Type Correct Packing List Number.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPackingListNo.Focus();
                return;
            }
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select ImportOrderNo from ImportOrder where ImportOrderNo='" + txtImportOrder.Text + "'";
                cmd = new SqlCommand(ct, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("This ImportOrder No Already Exists in the  List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtImportOrder.Text = "";
                    txtImportOrder.Focus();


                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }



                this.Hide();
                OrderWorkOrder frm1 = new OrderWorkOrder();
                frm1.txtImportOrderNo.Text = txtImportOrder.Text;
                frm1.importOrderDate.Text = txtOrderDate.Text;
                frm1.lcNumberTextBox.Text = txtLCNumber.Text;
                frm1.lcDate.Text = txtLCDate.Text;
                frm1.invoiceNumberTextBox.Text = txtInvoiceNumber.Text;
                frm1.invoiceDate.Text = txtInvoiceDate.Text;
                frm1.packingListNoTextBox.Text = txtPackingListNo.Text;
                frm1.Show();
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void SecondStepOfPurchaseOrder_Load(object sender, EventArgs e)
        {
            txtImportOrder.Focus();
        }

        private void txtPurchaseOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtOrderDate.Focus();
                e.Handled = true;
            }
        }

        private void txtOrderDate_ValueChanged(object sender, EventArgs e)
        {
            txtLCNumber.Focus();
        }

        private void txtLCNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLCDate.Focus();
                e.Handled = true;
            }
        }

        private void txtLCDate_ValueChanged(object sender, EventArgs e)
        {
            txtInvoiceNumber.Focus();
        }

        private void txtInvoiceNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtInvoiceDate.Focus();
                e.Handled = true;
            }
        }

        private void txtInvoiceDate_ValueChanged(object sender, EventArgs e)
        {
            txtPackingListNo.Focus();
        }

        private void txtPackingListNo_KeyDown(object sender, KeyEventArgs e)
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
