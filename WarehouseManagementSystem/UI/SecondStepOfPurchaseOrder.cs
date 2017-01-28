using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarehouseManagementSystem.UI
{
    public partial class SecondStepOfPurchaseOrder : Form
    {
        public SecondStepOfPurchaseOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPurchaseOrder.Text == "")
            {
                MessageBox.Show("Please Type Correct Import  Order.", "error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtPurchaseOrder.Focus();
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
                this.Hide();
                OrderWorkOrder frm1 = new OrderWorkOrder();
                frm1.purchaseOrderNoTextBox.Text = txtPurchaseOrder.Text;
                frm1.importOrderDate.Text = txtOrderDate.Text;
                frm1.lcNumberTextBox.Text = txtLCNumber.Text;
                frm1.lcDate.Text = txtLCDate.Text;
                frm1.invoiceNumberTextBox.Text = txtInvoiceNumber.Text;
                frm1.invoiceDate.Text = txtInvoiceDate.Text;
                frm1.packingListNoTextBox.Text = txtPackingListNo.Text;
                frm1.Show();
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
            txtPurchaseOrder.Focus();
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
    }
}
