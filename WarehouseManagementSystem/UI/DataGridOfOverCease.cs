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
    public partial class DataGridOfOverCease : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public DataGridOfOverCease()
        {
            InitializeComponent();
        }

        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(Sl),RTRIM(ProductGenericDescription),RTRIM(ItemDescription),RTRIM(ItemCode),RTRIM(CountryOfOrigin),RTRIM(StockAvailability),RTRIM(TaxtoDuty),RTRIM(Price) from ProductListSummary  order by Sl desc", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0],rdr[1],rdr[2], rdr[3],rdr[4],rdr[5],rdr[6],rdr[7]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DataGridOfOverCease_Load(object sender, EventArgs e)
        {
            GetData();
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
                frm.txtUStockAmount.Text = dr.Cells[5].Value.ToString();
                frm.txtUTaxToDuty.Text = dr.Cells[6].Value.ToString();
                frm.txtUPrice.Text = dr.Cells[7].Value.ToString();
                frm.labelk.Text = labelg.Text;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
