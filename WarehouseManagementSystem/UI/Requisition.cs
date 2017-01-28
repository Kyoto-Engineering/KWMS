using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseManagementSystem.DbGateway;
using WarehouseManagementSystem.LoginUI;

namespace WarehouseManagementSystem.UI
{
    public partial class Requisition : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public string submittedBy, fullName;
        public string b, c, x, y, MId;
        public Nullable<Int64> LId;
        public Int64 d,k,m,n;
        public decimal zero, ReqNO;
        public string  feederId,requisitionNo;
        public Requisition()
        {
            InitializeComponent();
        }

        private void txt1ProductId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String sql = "SELECT RTRIM(MasterStocks.MStockId),RTRIM(MasterStocks.ImportOrderNo),RTRIM(ProductListSummary.ProductGenericDescription),RTRIM(ProductListSummary.ItemCode),RTRIM(MasterStocks.MQuantity),RTRIM(MasterStocks.UnitPrice) from MasterStocks,ProductListSummary where MasterStocks.Sl=ProductListSummary.Sl and MasterStocks.MStockId like '" + txt1ProductId.Text + "%' and  MasterStocks.MQuantity!='0.0' order by MasterStocks.Sl desc";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5]);
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
                cmd = new SqlCommand("SELECT RTRIM(MasterStocks.MStockId),RTRIM(MasterStocks.ImportOrderNo),RTRIM(ProductListSummary.ProductGenericDescription),RTRIM(ProductListSummary.ItemCode),RTRIM(MasterStocks.CurrentQuantity),RTRIM(MasterStocks.UnitPrice)  from MasterStocks,ProductListSummary  where MasterStocks.Sl=ProductListSummary.Sl and (MasterStocks.CurrentQuantity >0 and MasterStocks.CurrentQuantity !=0) order by MasterStocks.MStockId desc", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FeederStockComboPopulate()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(FeederName) from FeederStockDetails  order by FeederId desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbFeederStock.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Requisition_Load(object sender, EventArgs e)
        {
            //label2.Visible = false;
            //txtRequisitionNo.Visible = false;
            FeederStockComboPopulate();
            //txtRequisitionNo.Focus();
            submittedBy = LoginForm.uId2.ToString();
            GetData();
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String sql = "SELECT RTRIM(MasterStocks.MStockId),RTRIM(MasterStocks.ImportOrderNo),RTRIM(ProductListSummary.ProductGenericDescription),RTRIM(ProductListSummary.ItemCode),RTRIM(MasterStocks.MQuantity),RTRIM(MasterStocks.UnitPrice) from MasterStocks,ProductListSummary where MasterStocks.Sl=ProductListSummary.Sl and ProductListSummary.ProductGenericDescription like '" + txtProductName.Text + "%' and MasterStocks.MQuantity!='0.0' order by MasterStocks.Sl desc";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String sql = "SELECT RTRIM(MasterStocks.MStockId),RTRIM(MasterStocks.ImportOrderNo),RTRIM(ProductListSummary.ProductGenericDescription),RTRIM(ProductListSummary.ItemCode),RTRIM(MasterStocks.MQuantity),RTRIM(MasterStocks.UnitPrice) from MasterStocks,ProductListSummary where MasterStocks.Sl=ProductListSummary.Sl and ProductListSummary.ItemCode like '" + txtItemCode.Text + "%' and MasterStocks.MQuantity!='0.0' order by MasterStocks.Sl desc";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
               
                txtProductId.Text = dr.Cells[0].Value.ToString();
                txtImportOrderNo.Text = dr.Cells[1].Value.ToString();
                txtQuantity.Text = dr.Cells[4].Value.ToString();
                label7.Text = label1.Text;               
                submitButton.Enabled = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void addToChartButton_Click(object sender, EventArgs e)
        {
            if (txtProductId.Text == "")
            {
                MessageBox.Show("You must select a  product first.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProductId.Focus();
                return;
            }
            
            if (txtQuantity.Text == "")
            {
                MessageBox.Show("Please enter quantity", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Focus();
                return;
            }
            if (txtUnitPrice.Text == "")
            {
                MessageBox.Show("Please enter Order Quantity.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUnitPrice.Focus();
                return;
            }
            for (int i = 0; i <= listView1.Items.Count - 1; i++)
            {

                if (listView1.Items[i].SubItems[2].Text == txtProductId.Text)
                {
                    MessageBox.Show("You can not Add one Item more  than one time", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                

            }

           
            try
            {

                if (listView1.Items.Count == 0)
                {
                    ListViewItem lst=new ListViewItem();
                    lst.SubItems.Add(txtImportOrderNo.Text);
                    lst.SubItems.Add(txtProductId.Text);
                    lst.SubItems.Add(txtQuantity.Text);
                    lst.SubItems.Add(txtUnitPrice.Text);
                    listView1.Items.Add(lst);
                    txtProductId.Text = "";
                    txtImportOrderNo.Text = "";
                    txtQuantity.Text = "";
                    txtUnitPrice.Text = "";
                    cmbFeederStock.Enabled = false;
                    return;

                }
                ListViewItem lst1 = new ListViewItem();
                lst1.SubItems.Add(txtImportOrderNo.Text);
                lst1.SubItems.Add(txtProductId.Text);
                lst1.SubItems.Add(txtQuantity.Text);
                lst1.SubItems.Add(txtUnitPrice.Text);
                listView1.Items.Add(lst1);
                txtImportOrderNo.Text = "";
                txtProductId.Text = "";
                txtQuantity.Text = "";
                txtUnitPrice.Text = "";
                cmbFeederStock.Enabled = false;
                return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

        }

        private void removeButton_Click(object sender, EventArgs e)
        {
           
            for (int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                if (listView1.Items[i].Selected)
                {
                    listView1.Items[i].Remove();
                }
            }
        }               
        private void GetNewId()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string cty = "SELECT IDENT_CURRENT ('Requisition') ";           
            cmd = new SqlCommand(cty);
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                zero = (rdr.GetDecimal(0));
                if (zero == 0)
                {
                    requisitionNo = "REQ-"+DateTime.Now.Year+"-100001";
                }
                else
                {
                    SecondNewId(); 
                }
            }
        }

        private void SecondNewId()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();

            string cty4 = "SELECT MAX(Requisition.RequisitionNo) FROM Requisition";
            cmd = new SqlCommand(cty4);
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                MId = (rdr.GetString(0));
                string[] s = MId.Split('-');
                b = s[0];
                c = s[1];
                x = s[2];
                d = Convert.ToInt64(x);
                k = d + 1;
                requisitionNo = "REQ-"+DateTime.Now.Year.ToString()+"-" + k;               
            }           
        }
        private void auto3()
        {
            requisitionNo = "REQ-2016-100001";
        }
        private void Reset()
        {
            
            cmbFeederStock.SelectedIndex = -1;
            submitButton.Enabled = true;
            cmbFeederStock.Enabled = true;
            listView1.Items.Clear();
        }

        private void ChangeIdentityValue()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "DBCC CHECKIDENT (Requisition, RESEED, 1)";
                cmd = new SqlCommand(query);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void submitButton_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("Please Select Item  Before Submit", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {                
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cty4 = "select Name from Registration where UserId='" + submittedBy + "'";
                cmd = new SqlCommand(cty4);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    fullName = (rdr.GetString(0));
                }
                con.Close();
                
                GetNewId();
                if (zero == 0)
                {
                    requisitionNo = "REQ-2016-100001";
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cd2 = "insert Into Requisition(RequisitionNo,RequisitionBy,RequisitionDate,RequisitionStatus,FeederId) VALUES (@d1,@d2,@d3,@d4,@d5)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";                  
                    cmd = new SqlCommand(cd2);
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@d1", requisitionNo);
                    cmd.Parameters.AddWithValue("@d2", fullName);
                    cmd.Parameters.AddWithValue("@d3", Convert.ToDateTime(System.DateTime.Today, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));                   
                    cmd.Parameters.AddWithValue("@d4", "Pending");
                    cmd.Parameters.AddWithValue("@d5", feederId);
                    ReqNO = (int)cmd.ExecuteScalar();
                    con.Close();
                    ChangeIdentityValue();

                }
                else
                {
                    
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cd2 = "insert Into Requisition(RequisitionNo,RequisitionBy,RequisitionDate,RequisitionStatus,FeederId) VALUES (@d1,@d2,@d3,@d4,@d5)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                    cmd = new SqlCommand(cd2);
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@d1", requisitionNo);
                    cmd.Parameters.AddWithValue("@d2", fullName);
                    cmd.Parameters.AddWithValue("@d3", Convert.ToDateTime(System.DateTime.Today, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                    cmd.Parameters.AddWithValue("@d4", "Pending");
                    cmd.Parameters.AddWithValue("@d5", feederId);
                    ReqNO = (int) cmd.ExecuteScalar();
                    con.Close();
                }          
                for (int i = 0; i <= listView1.Items.Count - 1; i++)
                {
                    
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cd = "insert Into RequisitionList(ReqId,MStockId,Quantity) VALUES (@d1,@d2,@d3)";
                    cmd = new SqlCommand(cd);
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@d1", ReqNO);
                    cmd.Parameters.AddWithValue("@d2", listView1.Items[i].SubItems[2].Text);
                    cmd.Parameters.AddWithValue("@d3", listView1.Items[i].SubItems[4].Text);                    
                    cmd.ExecuteNonQuery();
                    con.Close();

                    }

                 MessageBox.Show("Successfully Submitted.Requision No is:"+requisitionNo, "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

                listView1.Items.Clear();
                cmbFeederStock.SelectedIndex = -1;
                cmbFeederStock.Enabled = true;
                submitButton.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void TwodigitNumberAfterdosomic()
        //{
        //    if (!char.IsControl(e.KeyChar)
        //           && !char.IsDigit(e.KeyChar)
        //           && e.KeyChar != '.' && e.KeyChar != ',')
        //    {
        //        e.Handled = true;
        //    }

        //    //check if '.' , ',' pressed
        //    char sepratorChar = 's';
        //    if (e.KeyChar == '.' || e.KeyChar == ',')
        //    {
        //        // check if it's in the beginning of text not accept
        //        if (txtUnitPrice.Text.Length == 0) e.Handled = true;
        //        // check if it's in the beginning of text not accept
        //        if (txtUnitPrice.SelectionStart == 0) e.Handled = true;
        //        // check if there is already exist a '.' , ','
        //        if (alreadyExist(txtUnitPrice.Text, ref sepratorChar)) e.Handled = true;
        //        //check if '.' or ',' is in middle of a number and after it is not a number greater than 99
        //        if (txtUnitPrice.SelectionStart != txtUnitPrice.Text.Length && e.Handled == false)
        //        {
        //            // '.' or ',' is in the middle
        //            string AfterDotString = txtUnitPrice.Text.Substring(txtUnitPrice.SelectionStart);

        //            if (AfterDotString.Length > 2)
        //            {
        //                e.Handled = true;
        //            }
        //        }
        //    }
        //    //check if a number pressed

        //    if (Char.IsDigit(e.KeyChar))
        //    {
        //        //check if a coma or dot exist
        //        if (alreadyExist(txtUnitPrice.Text, ref sepratorChar))
        //        {
        //            int sepratorPosition = txtUnitPrice.Text.IndexOf(sepratorChar);
        //            string afterSepratorString = txtUnitPrice.Text.Substring(sepratorPosition + 1);
        //            if (txtUnitPrice.SelectionStart > sepratorPosition && afterSepratorString.Length > 1)
        //            {
        //                e.Handled = true;
        //            }

        //        }
        //    }
        //}
        //private bool alreadyExist(string _text, ref char KeyChar)
        //{
        //    if (_text.IndexOf('.') > -1)
        //    {
        //        KeyChar = '.';
        //        return true;
        //    }
        //    if (_text.IndexOf(',') > -1)
        //    {
        //        KeyChar = ',';
        //        return true;
        //    }
        //    return false;
        //}
        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
            
        }

        private void txtRequisitionNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtImportOrderNo.Focus();
                e.Handled = true;
            }
        }

        private void txtImportOrderNo_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                txtProductId.Focus();
                e.Handled = true;
            }
        }

        private void txtProductId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQuantity.Focus();
                e.Handled = true;
            }
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUnitPrice.Focus();
                e.Handled = true;
            }
        }

        private void txtUnitPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addToChartButton.Focus();
                e.Handled = true;
            }
        }

        private void txtUnitPrice_Validating(object sender, CancelEventArgs e)
        {
            decimal x = Convert.ToDecimal(txtUnitPrice.Text);
            decimal y = Convert.ToDecimal(txtQuantity.Text);

            if (x == 0)
            {
                MessageBox.Show("Requested Amount Can Not be Zero", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUnitPrice.Clear();
                txtUnitPrice.Focus();
                return;
            }
            if (x > y)
            {
                MessageBox.Show("Requested Amount Can Not Be Greater Than Available Amount", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUnitPrice.Clear();
                txtUnitPrice.Focus();
                return;
            }
        }

        private void cmbFeederStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT  RTRIM(FeederStockDetails.FeederId) from FeederStockDetails WHERE FeederStockDetails.FeederName = '" + cmbFeederStock.Text + "'";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {

                    feederId = (rdr.GetString(0));


                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.CurrentRow;
                txtProductId.Text = dr.Cells[0].Value.ToString();
                txtImportOrderNo.Text = dr.Cells[1].Value.ToString();
                txtQuantity.Text = dr.Cells[4].Value.ToString();
                label7.Text = label1.Text;               
                submitButton.Enabled = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
