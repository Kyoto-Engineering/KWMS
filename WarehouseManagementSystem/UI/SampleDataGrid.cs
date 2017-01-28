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
    public partial class SampleDataGrid : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        private SqlDataAdapter sda;
        ConnectionString cs=new ConnectionString();
        public SampleDataGrid()
        {
            InitializeComponent();
        }

        private void MyTestGrid()
        {
            con=new SqlConnection(cs.DBConn);
            con.Open();
            sda = new SqlDataAdapter("Select  pp.Sl,pp.ProductGenericDescription,pp.ItemDescription,pp.ItemCode,pp.CountryOfOrigin,pp.Price,pp.StockAvailability,pp.TaxtoDuty,pp.ProductImage from ProductListSummary as pp order by pp.Sl desc", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 90;
            dataGridView1.Columns[4].Width = 90;
            dataGridView1.Columns[5].Width = 90;
            dataGridView1.Columns[6].Width = 90;
            dataGridView1.Columns[7].Width = 50;
            dataGridView1.Columns[8].Width = 180; // or whatever width works well for abbrev
            //dataGridView1.Columns[2].Width = dataGridView1.Width - dataGridView1.Columns[0].Width - dataGridView1.Columns[1].Width - 72;  
            con.Close();
        }
        private void SampleDataGrid_Load(object sender, EventArgs e)
        {
            MyTestGrid();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                this.Hide();
                frmProductUpdate frm = new frmProductUpdate();
                frm.Show();
                frm.txtUProductId.Text = dr.Cells[0].Value.ToString();
                frm.txtUProductName.Text = dr.Cells[1].Value.ToString();
                frm.txtUItemDescription.Text = dr.Cells[2].Value.ToString();
                frm.txtUItemCode.Text = dr.Cells[3].Value.ToString();
                frm.txtUCountryOfOrigin.Text = dr.Cells[4].Value.ToString();
                frm.txtUPrice.Text = dr.Cells[5].Value.ToString();
                frm.txtUStockAmount.Text = dr.Cells[6].Value.ToString();
                frm.txtUTaxToDuty.Text = dr.Cells[7].Value.ToString();
                byte[] data = (byte[])dr.Cells[8].Value;
                MemoryStream ms = new MemoryStream(data);
                frm.txtUPictureBox.Image = Image.FromStream(ms);
                frm.labelk.Text = labelg.Text;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
