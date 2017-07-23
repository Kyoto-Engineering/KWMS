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
    public partial class MasterStocksGrid : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        private SqlDataAdapter sda;
        public MasterStocksGrid()
        {
            InitializeComponent();
        }

        private void MasterStocksGrid_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd =
                    new SqlCommand(
                        "SELECT MStockId1, MQuantity,Sl FROM MasterStocks1 order by MasterStocks1.MStockId1 asc",
                        con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MasterStocksGrid_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            frmMainUI frm = new frmMainUI();
            frm.Show();
        }
    }
}
