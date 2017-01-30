namespace WarehouseManagementSystem.UI
{
    partial class DeliveryOrderUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeliveryOrderUI));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonApprove = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.feederStockCombo = new System.Windows.Forms.ComboBox();
            this.deliveryOrderCombo = new System.Windows.Forms.ComboBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(303, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(424, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "Approval From Warehouse";
            // 
            // buttonApprove
            // 
            this.buttonApprove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonApprove.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonApprove.ForeColor = System.Drawing.Color.Blue;
            this.buttonApprove.Location = new System.Drawing.Point(490, 453);
            this.buttonApprove.Name = "buttonApprove";
            this.buttonApprove.Size = new System.Drawing.Size(120, 67);
            this.buttonApprove.TabIndex = 2;
            this.buttonApprove.Text = "Approve";
            this.buttonApprove.UseVisualStyleBackColor = false;
            this.buttonApprove.Click += new System.EventHandler(this.buttonApprove_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(816, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Feeder Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(53, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Delivery Order";
            // 
            // feederStockCombo
            // 
            this.feederStockCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.feederStockCombo.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feederStockCombo.FormattingEnabled = true;
            this.feederStockCombo.Location = new System.Drawing.Point(953, 105);
            this.feederStockCombo.Name = "feederStockCombo";
            this.feederStockCombo.Size = new System.Drawing.Size(228, 30);
            this.feederStockCombo.TabIndex = 5;
            this.feederStockCombo.SelectedIndexChanged += new System.EventHandler(this.feederStockCombo_SelectedIndexChanged);
            // 
            // deliveryOrderCombo
            // 
            this.deliveryOrderCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deliveryOrderCombo.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deliveryOrderCombo.FormattingEnabled = true;
            this.deliveryOrderCombo.Location = new System.Drawing.Point(207, 124);
            this.deliveryOrderCombo.Name = "deliveryOrderCombo";
            this.deliveryOrderCombo.Size = new System.Drawing.Size(242, 32);
            this.deliveryOrderCombo.TabIndex = 6;
            this.deliveryOrderCombo.SelectedIndexChanged += new System.EventHandler(this.deliveryOrderCombo_SelectedIndexChanged);
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listView2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView2.GridLines = true;
            this.listView2.Location = new System.Drawing.Point(50, 161);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(560, 285);
            this.listView2.TabIndex = 8;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Product Name";
            this.columnHeader6.Width = 259;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Model";
            this.columnHeader7.Width = 161;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Quantity";
            this.columnHeader8.Width = 131;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.Location = new System.Drawing.Point(610, 161);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(636, 285);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "RId";
            this.columnHeader1.Width = 8;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "FeederId";
            this.columnHeader2.Width = 7;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Product Name";
            this.columnHeader3.Width = 271;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Model";
            this.columnHeader4.Width = 216;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Quantity";
            this.columnHeader5.Width = 127;
            // 
            // DeliveryOrderUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Olive;
            this.ClientSize = new System.Drawing.Size(1259, 532);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.deliveryOrderCombo);
            this.Controls.Add(this.feederStockCombo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonApprove);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeliveryOrderUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeliveryOrderUI";
            this.Load += new System.EventHandler(this.DeliveryOrderUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonApprove;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox feederStockCombo;
        private System.Windows.Forms.ComboBox deliveryOrderCombo;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader8;
    }
}