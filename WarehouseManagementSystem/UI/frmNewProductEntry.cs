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
    public partial class frmNewProductEntry : Form
    {
        private SqlConnection con;
        private SqlDataReader rdr;
        private SqlCommand cmd;
        ConnectionString cs=new ConnectionString();

        public frmNewProductEntry()
        {
            InitializeComponent();
        }

        private void getDataButton_Click(object sender, EventArgs e)
        {

            this.Hide();
            SampleDataGrid frm = new SampleDataGrid();
            frm.Show();
            //this.Visible = false;
            //dynamic frm = new DataGridOfOverCease();
            //frm.Show();
            //this.Visible = true;
        }

        private void Reset()
        {
            txtProductName.Text = "";
            txtItemDescription.Text = "";
            txtItemCode.Text = "";
            cmbCountryOfOrigin.SelectedIndex = -1;
            txtPrice.Text = "";
            txtStockAmount.Text = "";
            txtTaxToDuty.Text = "";
            txtPictureBox.Image = Properties.Resources._12;
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text == "")
            {
                MessageBox.Show("Please  enter Product Name","error",MessageBoxButtons.OK,MessageBoxIcon.Error); 
                txtProductName.Focus();
                return;
            }
            if (txtItemDescription.Text == "")
            {
                MessageBox.Show("Please  enter Item Description", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtItemDescription.Focus();
                return;
            }
            if (txtItemCode.Text == "")
            {
                MessageBox.Show("Please  enter item Code", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtItemCode.Focus();
                return;
            }
            if (cmbCountryOfOrigin.Text == "")
            {
                MessageBox.Show("Please  enter Country Of Origin", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCountryOfOrigin.Focus();
                return;
            }
          
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select ProductGenericDescription from ProductListSummary where ProductGenericDescription='" + txtProductName.Text + "'";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("This Product Item Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtProductName.Text = "";
                    txtProductName.Focus();


                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                con=new SqlConnection(cs.DBConn);
                con.Open();
                string query = "insert into ProductListSummary(ProductGenericDescription,ItemDescription,ItemCode,CountryOfOrigin,Price,StockAvailability,TaxtoDuty,ProductImage) values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)";
                cmd=new SqlCommand(query,con);
                cmd.Parameters.AddWithValue("@d1",txtProductName.Text);
                cmd.Parameters.AddWithValue("@d2", txtItemDescription.Text);
                cmd.Parameters.AddWithValue("@d3", txtItemCode.Text);
                cmd.Parameters.AddWithValue("@d4", cmbCountryOfOrigin.Text);
                cmd.Parameters.AddWithValue("@d5", txtPrice.Text);
                cmd.Parameters.AddWithValue("@d6", txtStockAmount.Text);
                cmd.Parameters.AddWithValue("@d7", txtTaxToDuty.Text);

                MemoryStream ms = new MemoryStream();
                Bitmap bmpImage = new Bitmap(txtPictureBox.Image);
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data = ms.GetBuffer();
                SqlParameter p = new SqlParameter("@d8", SqlDbType.Image);
                p.Value = data;
                cmd.Parameters.Add(p);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Saved", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    txtPictureBox.Image = Image.FromFile(openFileDialog1.FileName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtStockAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTaxToDuty_KeyPress(object sender, KeyPressEventArgs e)
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

        private void frmNewProductEntry_Load(object sender, EventArgs e)
        {
            txtProductName.Focus();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMainUI frm=new frmMainUI();
             frm.Show();
        }

        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtItemDescription.Focus();
                e.Handled = true;
            }
        }

        private void txtItemDescription_KeyDown(object sender, KeyEventArgs e)
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
                cmbCountryOfOrigin.Focus();
                e.Handled = true;
            }
        }

        private void cmbCountryOfOrigin_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtStockAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTaxToDuty.Focus();
                e.Handled = true;
            }
        }

        private void txtTaxToDuty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPrice.Focus();
                e.Handled = true;
            }
        }

        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                browseButton.Focus();
                e.Handled = true;
            }
        }

        private void cmbCountryOfOrigin_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtStockAmount.Focus();
        }
    }
}
