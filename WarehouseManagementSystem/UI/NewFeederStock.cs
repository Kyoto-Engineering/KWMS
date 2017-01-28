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
    public partial class NewFeederStock : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public string userId;
        public NewFeederStock()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (txtFeederName.Text == "")
            {
                MessageBox.Show("Please  enter feeder Name", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFeederName.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select FeederName from FeederStockDetails where FeederName='" + txtFeederName.Text + "'";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("This Name Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFeederName.Text = "";
                    txtFeederName.Focus();


                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                con=new SqlConnection(cs.DBConn);
                con.Open();
                string query = "insert into FeederStockDetails(FeederName,CreatedByUId,DateCreated) values(@d1,@d2,@d3)";
                cmd=new SqlCommand(query,con);
                cmd.Parameters.AddWithValue("@d1", txtFeederName.Text);
                cmd.Parameters.AddWithValue("@d2", userId);
                cmd.Parameters.AddWithValue("@d3", DateTime.UtcNow.ToLocalTime());
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Saved", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFeederName.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NewFeederStock_Load(object sender, EventArgs e)
        {
            userId = LoginForm.uId2.ToString();
        }
    }
}
