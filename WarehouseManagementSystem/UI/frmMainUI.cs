﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseManagementSystem.LoginUI;

namespace WarehouseManagementSystem.UI
{
    public partial class frmMainUI : Form
    {
        public frmMainUI()
        {
            InitializeComponent();
        }

        private void btnWorkOrder_Click(object sender, EventArgs e)
        {
            this.Hide();
            PreviousOrderList frm = new PreviousOrderList();
            frm.Show();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {


            this.Hide();
            UserManagementUI aform=new UserManagementUI();
            aform.ShowDialog();
            
        }

        private void lcButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            dynamic afrm = new frmWorkOrder();
            afrm.ShowDialog();
            this.Visible = true;

        }

        private void btnReceiveOrder_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            dynamic afrm = new OrderReceive();
            afrm.ShowDialog();
            this.Visible = true;
        }

        private void setPriceButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            dynamic afrm = new Requisition();
            afrm.ShowDialog();
            this.Visible = true;
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            dynamic  afrm=new RequisitionApproval();
            afrm.ShowDialog();
            this.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm frm=new LoginForm();
             frm.Show();
        }

        private void localStoreRoomButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            dynamic afrm=new GridForLocalStore();
            afrm.ShowDialog();
            this.Visible = true;
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            this.Hide();
          frmNewProductEntry frm = new frmNewProductEntry();
            frm.Show();
            //this.Visible = false;
            //dynamic frm = new frmNewProductEntry();
            //frm.ShowDialog();
            //this.Visible = true;
        }

        private void overseaseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            SampleDataGrid frm=new SampleDataGrid();
            frm.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            dynamic frm = new NewFeederStock();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void deliveryOrderButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            dynamic frm = new DeliveryOrderApproval();
            frm.ShowDialog();
            this.Visible = true;  
        }
    }
}
