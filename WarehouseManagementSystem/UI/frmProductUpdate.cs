using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseManagementSystem.DbGateway;

namespace WarehouseManagementSystem.UI
{
    public partial class frmProductUpdate : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public frmProductUpdate()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
           // DataGridOfOverCease frm=new DataGridOfOverCease();
            SampleDataGrid frm=new SampleDataGrid();
            frm.Show();
        }

        private void Reset()
        {
            txtUProductId.Text = "";
            txtUProductName.Text = "";
            txtUItemDescription.Text = "";
            txtUItemCode.Text = "";
            txtUCountryOfOrigin.Text = "";
            txtUPrice.Text = "";
            txtUStockAmount.Text = "";
            txtUTaxToDuty.Text = "";
            txtUPictureBox.Image = Properties.Resources._12;
        }

        private void frmProductUpdate_Load(object sender, EventArgs e)
        {
            txtUProductId.Focus();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (txtUProductName.Text == "")
            {
                MessageBox.Show("Please enter  product Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUProductName.Focus();
                return;
            }
            if (txtUItemCode.Text == "")
            {
                MessageBox.Show("Please Type Item Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUItemCode.Focus();
                return;
            }
            
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "Update ProductListSummary set ProductGenericDescription=@d1,ItemDescription=@d2,ItemCode=@d3,CountryOfOrigin=@d4,Price=@d5,StockAvailability=@d6,TaxtoDuty=@d7,ProductImage=@d8 where Sl='" + txtUProductId.Text + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtUProductName.Text);
                cmd.Parameters.AddWithValue("@d2", txtUItemDescription.Text);
                cmd.Parameters.AddWithValue("@d3", txtUItemCode.Text);
                cmd.Parameters.AddWithValue("@d4", txtUCountryOfOrigin.Text);
                cmd.Parameters.AddWithValue("@d5", txtUPrice.Text);
                cmd.Parameters.AddWithValue("@d6", txtUStockAmount.Text);
                cmd.Parameters.AddWithValue("@d7", txtUTaxToDuty.Text);

                MemoryStream ms = new MemoryStream();
                Bitmap bmpImage = new Bitmap(txtUPictureBox.Image);
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data = ms.GetBuffer();
                SqlParameter p = new SqlParameter("@d8", SqlDbType.Image);
                p.Value = data;
                cmd.Parameters.Add(p);
                rdr = cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                updateButton.Enabled = false;
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void browseButton_Click(object sender, EventArgs e)
        {

            try
            {
                var _with1 = openFileDialog1;

                _with1.Filter = ("Image Files |*.png; *.bmp; *.jpg;*.jpeg; *.gif;");
                _with1.FilterIndex = 4;

                openFileDialog1.FileName = "";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtUPictureBox.Image = Image.FromFile(openFileDialog1.FileName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmNewProductEntry frm=new frmNewProductEntry();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmNewProductEntry frm=new frmNewProductEntry();
            frm.Show();
        }

        private void txtUProductId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUProductName.Focus();
                e.Handled = true;
            }
        }

        private void txtUProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUItemDescription.Focus();
                e.Handled = true;
            }
        }

        private void txtUItemDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUItemCode.Focus();
                e.Handled = true;
            }
        }

        private void txtUItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUCountryOfOrigin.Focus();
                e.Handled = true;
            }
        }

        private void txtUCountryOfOrigin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUStockAmount.Focus();
                e.Handled = true;
            }
        }

        private void txtUStockAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUTaxToDuty.Focus();
                e.Handled = true;
            }
        }

        private void txtUTaxToDuty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUPrice.Focus();
                e.Handled = true;
            }
        }

        private void txtUPrice_KeyDown(object sender, KeyEventArgs e)
        {
            
                if (e.KeyCode == Keys.Enter)
            {
                browseButton.Focus();
                e.Handled = true;
            }

        }
    }
}
