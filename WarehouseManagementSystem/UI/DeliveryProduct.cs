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
    public partial class DeliveryProduct : Form
    {
        private SqlCommand cmd;
        ConnectionString Cs=new ConnectionString();
        private SqlConnection con;
        private SqlDataReader rdr;
        private string impOd,sl;
        private DataGridViewRow dr;
        private int checkvalue,smId,available;
        private int SupplierId;
        private int Sio;
        private string shipmentOrderNo, clientId, quotationId, brandCode;

        public DeliveryProduct()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SupplierComboBox.SelectedIndex != -1)
            {
                string[] splitter = SupplierComboBox.Text.Split('-');
                brandCode = splitter[0];
                clientId = splitter[2];
                quotationId = splitter[4];
                con = new SqlConnection(Cs.DBConn);
                string qry =
                    "SELECT        DeliveryProduct.DeliveryProductId, ProductListSummary.ProductGenericDescription, ProductListSummary.ItemCode, ProductListSummary.ItemDescription, DeliveryProduct.DPQty, DeliveryProduct.BacklogQty, MasterStocks1.MQuantity, ProductListSummary.Sl FROM Delivery INNER JOIN DeliveryProduct ON Delivery.DeliveryId = DeliveryProduct.DeliveryId INNER JOIN ProductQuotation ON DeliveryProduct.PQId = ProductQuotation.PQId INNER JOIN ProductListSummary ON ProductQuotation.Sl = ProductListSummary.Sl INNER JOIN MasterStocks1 ON ProductListSummary.Sl = MasterStocks1.Sl WHERE (Delivery.RefNo ='" + SupplierComboBox.Text + "' ) AND (MasterStocks1.MQuantity > 0) AND (DeliveryProduct.BacklogQty > 0)";
                cmd = new SqlCommand(qry, con);
                dataGridView1.Rows.Clear();
                con.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6],rdr[7]);
                }
                con.Close();
               
            }
            //GetShimpentOredrNo();
        }
        


        private void DeliveryProduct_Load(object sender, EventArgs e)
        {
            Deliveryorder();
           
        }

        private void Deliveryorder()
        {

            con = new SqlConnection(Cs.DBConn);
            string qry =
                "SELECT RefNo FROM Delivery";
            cmd = new SqlCommand(qry, con);
            con.Open();
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                SupplierComboBox.Items.Add(rdr[0]);
            }
            con.Close();

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
               dr = dataGridView1.SelectedRows[0];
                impOd = dr.Cells[0].Value.ToString();
                ProductCodeTextBox.Text = dr.Cells[2].Value.ToString();
                ShipingQtyTextBox.Text = dr.Cells[5].Value.ToString();
                ProductNameTextBox.Text = dr.Cells[1].Value.ToString();
                ProductDesTextBox.Text = dr.Cells[3].Value.ToString();
                checkvalue =Convert.ToInt32( dr.Cells[5].Value.ToString());
                available = Convert.ToInt32(dr.Cells[6].Value.ToString());
                sl = dr.Cells[7].Value.ToString();
            }
            else
            {
                MessageBox.Show(@"Select Something first");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

                if (string.IsNullOrEmpty(ProductCodeTextBox.Text))
                {
                    MessageBox.Show("Select A Product First");
                }
                else if (string.IsNullOrWhiteSpace(ShipingQtyTextBox.Text) || Convert.ToInt32(ShipingQtyTextBox.Text)<1)
                {
                    MessageBox.Show("Product With Zero , MInus or Empty Quantity Can Not Be Added");
                }
                else if (Convert.ToInt32(ShipingQtyTextBox.Text)>checkvalue)
                {
                    MessageBox.Show("Receive Amount Cannot Be greater Than the Backloq Quantity");
                }
                else if (Convert.ToInt32(ShipingQtyTextBox.Text) > available)
                {
                    MessageBox.Show("Receive Amount Cannot Be greater Than the Available Quantity");
                }
                else
                {


                    if (listView1.Items.Count < 1)
                    {
                        ListViewItem l1 = new ListViewItem();
                        l1.Text = impOd;
                        l1.SubItems.Add(ProductNameTextBox.Text);
                        l1.SubItems.Add(ProductCodeTextBox.Text);
                        l1.SubItems.Add(ProductDesTextBox.Text);
                        l1.SubItems.Add(ShipingQtyTextBox.Text);
                        l1.SubItems.Add(sl);
                        listView1.Items.Add(l1);
                        ClearselectedProduct();
                        groupBox1.Enabled = false;
                    }
                    else
                    {
                        if (GetValue())
                        {
                            ListViewItem l2 = new ListViewItem();
                            l2.Text = impOd;
                            l2.SubItems.Add(ProductNameTextBox.Text);
                            l2.SubItems.Add(ProductCodeTextBox.Text);
                            l2.SubItems.Add(ProductDesTextBox.Text);
                            l2.SubItems.Add(ShipingQtyTextBox.Text);
                            l2.SubItems.Add(sl);
                            listView1.Items.Add(l2);
                            ClearselectedProduct();
                            //groupBox1.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("This Prduct already Added");
                            ClearselectedProduct();
                        }
                    }
                }
           

            
           
           
        }
        private bool GetValue()
        {
            bool x = true;
            foreach (ListViewItem z in listView1.Items)
            {
                if (z.Text == impOd)
                {
                    x = false;
                    break;
                }
            }
            return x;
        }

     private void ClearselectedProduct()
        {
            impOd = null;
            ProductCodeTextBox.Clear();
            ShipingQtyTextBox.Clear();
            ProductDesTextBox.Clear();
            ProductNameTextBox.Clear();
        }

     private void ClearShipmentandgridsinfo() 
     {
         SupplierComboBox.SelectedIndex = -1;

         ShipmentOrderNoTextBox.Clear();

         SupplierComboBox.ResetText();


         listView1.Items.Clear();
         dataGridView1.Rows.Clear();
         dataGridView1.Refresh();
     } 

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ProductCodeTextBox.Text))
            {
                if (listView1.Items.Count>0)
                {

                    con = new SqlConnection(Cs.DBConn);
                    string q1 =
                        "INSERT INTO OutTable  (DeliveryId,UserId ,OutDate) VALUES (@d1,@d2,@d3)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                    cmd=new SqlCommand(q1,con);
                    cmd.Parameters.AddWithValue("@d1", quotationId);
                    cmd.Parameters.AddWithValue("@d2", LoginForm.uId2);
                    cmd.Parameters.AddWithValue("@d3", DateTime.UtcNow.ToLocalTime());
                    con.Open();
                    string ShID=cmd.ExecuteScalar().ToString();
                    con.Close();
                    for (int i = 0; i <= listView1.Items.Count - 1; i++)
                    {
                        string imprno = listView1.Items[i].Text;
                        string qty = listView1.Items[i].SubItems[4].Text;
                        string query =
                            "INSERT INTO OutProduct (DeliveryProductId,OutId,OutQty) VALUES(@d1,@d2,@d3)";
                        cmd=new SqlCommand(query,con);
                        cmd.Parameters.AddWithValue("@d1", imprno);
                        cmd.Parameters.AddWithValue("@d2", ShID);
                        cmd.Parameters.AddWithValue("@d3", qty );
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        string query2 =
                            "UPDATE DeliveryProduct SET BacklogQty = BacklogQty -@d1 WHERE (DeliveryProductId = @d2)";
                        cmd = new SqlCommand(query2, con);
                        cmd.Parameters.AddWithValue("@d1", qty);
                        cmd.Parameters.AddWithValue("@d2", imprno);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        string query3 =
                            "UPDATE  MasterStocks1 SET  MQuantity = MQuantity - @d1 WHERE (Sl = @d2)";
                        cmd = new SqlCommand(query3, con);
                        cmd.Parameters.AddWithValue("@d1", qty);
                        cmd.Parameters.AddWithValue("@d2", listView1.Items[i].SubItems[5].Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    MessageBox.Show("Shipment Order Done");
                    SupplierComboBox.Items.Clear();
                    Deliveryorder();


                }
                else
                {
                    MessageBox.Show("No Pruduct Added");
                }
                
            }
            else
            {
                MessageBox.Show("May be You forgot to add Last Selected Product\r\n Add The Product");
            }

            ClearselectedProduct();
            ClearShipmentandgridsinfo();
            groupBox1.Enabled = true;
        }



        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }

       
        
         
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
          
        

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count < 1)
            {
                MessageBox.Show("Please Select a row from the list which you  want to remove", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                for (int i = listView1.Items.Count - 1; i >= 0; i--)
                {
                    if (listView1.Items[i].Selected)
                    {
                        listView1.Items[i].Remove();
                    }
                }
            }
        }
    }
}
