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
    public partial class VoucherNumberUI : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        private string userId;
        private int batchId,voucherNo;

        public VoucherNumberUI()
        {
            InitializeComponent();
        }

        private void SaveUserRecord()
        {
       
            
        }

        private void Reset()
        {
            voucherNoStartPoint.Clear();
            voucherNoEndPoint.Clear();
            txtBookNumber.Clear();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtBookNumber.Text))
            {
                MessageBox.Show("Please enter Book No ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBookNumber.Focus();
               
            }
            else if (string.IsNullOrWhiteSpace(voucherNoStartPoint.Text))
            {
                MessageBox.Show("Please enter Gate Pass Start Point", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                voucherNoStartPoint.Focus();
            
            }
            else if (string.IsNullOrWhiteSpace(voucherNoEndPoint.Text))
            {
                MessageBox.Show("Please enter Gate Pass end Point", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                voucherNoEndPoint.Focus();
                //return;
            }
            else if(ValidatBookNo())
            {
                // voucherNo = (rdr.GetInt32(0));
                MessageBox.Show("This Book Number Range is already exist.Please select correct Book Number.", "error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                txtBookNumber.Clear();
                //voucherNoEndPoint.Clear();
                txtBookNumber.Focus();
            }
            else if (ValidateGetPass())
            {
                MessageBox.Show("This Gate Pass Range is already exist.Please select correct Gate Passrange.", "error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                voucherNoStartPoint.Clear();
                voucherNoEndPoint.Clear();
                voucherNoStartPoint.Focus();
            }
            else try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                SqlTransaction trans = con.BeginTransaction();
                string qry = "INSERT INTO GatePassEntry (UserId, EntryTime, BookNo) VALUES        (@d1,@d2,@d3)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(qry, con,trans);
                cmd.Parameters.AddWithValue("@d1", LoginForm.uId2);
                cmd.Parameters.AddWithValue("@d2", DateTime.UtcNow.ToLocalTime());
                cmd.Parameters.AddWithValue("@d3", txtBookNumber.Text);
                batchId = (int)cmd.ExecuteScalar();

                for (UInt64 k = Convert.ToUInt64(voucherNoStartPoint.Text); k <= Convert.ToUInt64(voucherNoEndPoint.Text); k++)
                {
                    //con = new SqlConnection(cs.DBConn);
                    //con.Open();
                    string query = "INSERT INTO GatePasses (GPEId,GPNo)VALUES (@d1,@d2)";
                    cmd = new SqlCommand(query, con,trans);
                    cmd.Parameters.AddWithValue("@d1", batchId);
                    cmd.Parameters.AddWithValue("@d2", k.ToString());
                    cmd.ExecuteNonQuery();
                    //con.Close();

                }   
                cmd.Transaction.Commit();
                con.Close();
                MessageBox.Show("These Voucher Number Successfully  Created.", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error But We Are Rollebacking", MessageBoxButtons.OK,MessageBoxIcon.Error);
                cmd.Transaction.Rollback();
                con.Close();
            }
          
        }

        private bool ValidateGetPass()
        {
            bool x = false;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string query1 = "Select GatePasses.* from GatePasses where GPNo='" + voucherNoStartPoint.Text + "' OR  GPNo='" +
                            voucherNoEndPoint.Text + "' ";
            cmd = new SqlCommand(query1, con);
            rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                x = true;
              
                // voucherNo = (rdr.GetInt32(0));
                
            }
            con.Close();
            return x;
        }

        private bool ValidatBookNo()
        {
           bool x = false;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string query1 = "SELECT BookNo FROM GatePassEntry WHERE BookNo = @d1";

            cmd = new SqlCommand(query1, con);
            cmd.Parameters.AddWithValue("@d1", txtBookNumber.Text);
            rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                x = true;
            }
            con.Close();
            return x;
        }

        private void VoucherNumberUI_Load(object sender, EventArgs e)
        {
          
        }
    }
}
