namespace WarehouseManagementSystem.UI
{
    partial class RequisitionApproval
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequisitionApproval));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtFeederStockName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbActionStatus = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtImportOrderNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRequisitionAmount = new System.Windows.Forms.TextBox();
            this.txtReceiveAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.txtMasterStockProductId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.newButton = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.cmbRequisitionNo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.deniedButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(442, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(909, 394);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column2,
            this.Column1,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column3});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.GridColor = System.Drawing.Color.Blue;
            this.dataGridView1.Location = new System.Drawing.Point(11, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(889, 361);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick_1);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint_1);
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Feeder Stock Name";
            this.Column7.Name = "Column7";
            this.Column7.Width = 130;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Import Order No";
            this.Column2.Name = "Column2";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Requisition No";
            this.Column1.Name = "Column1";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Product Id";
            this.Column8.Name = "Column8";
            this.Column8.Width = 70;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Product Name";
            this.Column9.Name = "Column9";
            this.Column9.Width = 140;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Iteme Code";
            this.Column10.Name = "Column10";
            this.Column10.Width = 110;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Quantity";
            this.Column11.Name = "Column11";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "RId";
            this.Column3.Name = "Column3";
            this.Column3.Width = 90;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox5.Controls.Add(this.txtFeederStockName);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.cmbActionStatus);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.txtImportOrderNo);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.txtRequisitionAmount);
            this.groupBox5.Controls.Add(this.txtReceiveAmount);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.txtItemCode);
            this.groupBox5.Controls.Add(this.txtMasterStockProductId);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(18, 142);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(413, 301);
            this.groupBox5.TabIndex = 17;
            this.groupBox5.TabStop = false;
            // 
            // txtFeederStockName
            // 
            this.txtFeederStockName.Location = new System.Drawing.Point(182, 26);
            this.txtFeederStockName.Name = "txtFeederStockName";
            this.txtFeederStockName.ReadOnly = true;
            this.txtFeederStockName.Size = new System.Drawing.Size(222, 29);
            this.txtFeederStockName.TabIndex = 36;
            this.txtFeederStockName.TextChanged += new System.EventHandler(this.txtFeederStockName_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Magenta;
            this.label10.Location = new System.Drawing.Point(7, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(172, 22);
            this.label10.TabIndex = 35;
            this.label10.Text = "Feeder Stock Name";
            // 
            // cmbActionStatus
            // 
            this.cmbActionStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActionStatus.FormattingEnabled = true;
            this.cmbActionStatus.Items.AddRange(new object[] {
            "Approved",
            "Denied"});
            this.cmbActionStatus.Location = new System.Drawing.Point(182, 218);
            this.cmbActionStatus.Name = "cmbActionStatus";
            this.cmbActionStatus.Size = new System.Drawing.Size(222, 30);
            this.cmbActionStatus.TabIndex = 5;
            this.cmbActionStatus.SelectedIndexChanged += new System.EventHandler(this.cmbActionStatus_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label6.Location = new System.Drawing.Point(114, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 22);
            this.label6.TabIndex = 34;
            this.label6.Text = "Action";
            // 
            // txtImportOrderNo
            // 
            this.txtImportOrderNo.Location = new System.Drawing.Point(182, 64);
            this.txtImportOrderNo.Name = "txtImportOrderNo";
            this.txtImportOrderNo.ReadOnly = true;
            this.txtImportOrderNo.Size = new System.Drawing.Size(222, 29);
            this.txtImportOrderNo.TabIndex = 0;
            this.txtImportOrderNo.TextChanged += new System.EventHandler(this.txtImportOrderNo_TextChanged);
            this.txtImportOrderNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtImportOrderNo_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Fuchsia;
            this.label5.Location = new System.Drawing.Point(26, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 22);
            this.label5.TabIndex = 32;
            this.label5.Text = "Import Order No";
            // 
            // txtRequisitionAmount
            // 
            this.txtRequisitionAmount.Location = new System.Drawing.Point(182, 180);
            this.txtRequisitionAmount.Name = "txtRequisitionAmount";
            this.txtRequisitionAmount.ReadOnly = true;
            this.txtRequisitionAmount.Size = new System.Drawing.Size(222, 29);
            this.txtRequisitionAmount.TabIndex = 3;
            this.txtRequisitionAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRequisitionAmount_KeyDown);
            // 
            // txtReceiveAmount
            // 
            this.txtReceiveAmount.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiveAmount.Location = new System.Drawing.Point(182, 257);
            this.txtReceiveAmount.Name = "txtReceiveAmount";
            this.txtReceiveAmount.Size = new System.Drawing.Size(222, 32);
            this.txtReceiveAmount.TabIndex = 4;
            this.txtReceiveAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReceiveAmount_KeyDown);
            this.txtReceiveAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReceiveAmount_KeyPress);
            this.txtReceiveAmount.Validating += new System.ComponentModel.CancelEventHandler(this.txtReceiveAmount_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Fuchsia;
            this.label3.Location = new System.Drawing.Point(16, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 22);
            this.label3.TabIndex = 28;
            this.label3.Text = "Requsted Quantity";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Fuchsia;
            this.label9.Location = new System.Drawing.Point(11, 262);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(165, 22);
            this.label9.TabIndex = 21;
            this.label9.Text = "Approved Quantity";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 711);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 22);
            this.label7.TabIndex = 3;
            this.label7.Text = "label3";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Fuchsia;
            this.label8.Location = new System.Drawing.Point(82, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 22);
            this.label8.TabIndex = 19;
            this.label8.Text = "Item Code";
            // 
            // txtItemCode
            // 
            this.txtItemCode.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCode.Location = new System.Drawing.Point(182, 142);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.ReadOnly = true;
            this.txtItemCode.Size = new System.Drawing.Size(222, 32);
            this.txtItemCode.TabIndex = 2;
            this.txtItemCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemCode_KeyDown);
            // 
            // txtMasterStockProductId
            // 
            this.txtMasterStockProductId.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMasterStockProductId.Location = new System.Drawing.Point(182, 102);
            this.txtMasterStockProductId.Name = "txtMasterStockProductId";
            this.txtMasterStockProductId.ReadOnly = true;
            this.txtMasterStockProductId.Size = new System.Drawing.Size(222, 32);
            this.txtMasterStockProductId.TabIndex = 1;
            this.txtMasterStockProductId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMasterStockProductId_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Fuchsia;
            this.label4.Location = new System.Drawing.Point(77, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 22);
            this.label4.TabIndex = 14;
            this.label4.Text = "Product Id";
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newButton.ForeColor = System.Drawing.Color.Blue;
            this.newButton.Location = new System.Drawing.Point(28, 447);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(115, 67);
            this.newButton.TabIndex = 2;
            this.newButton.Text = "Refresh";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.submitButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.ForeColor = System.Drawing.Color.Fuchsia;
            this.submitButton.Location = new System.Drawing.Point(306, 447);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(125, 67);
            this.submitButton.TabIndex = 1;
            this.submitButton.Text = "Aprove";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // cmbRequisitionNo
            // 
            this.cmbRequisitionNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRequisitionNo.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRequisitionNo.ForeColor = System.Drawing.Color.Red;
            this.cmbRequisitionNo.FormattingEnabled = true;
            this.cmbRequisitionNo.Location = new System.Drawing.Point(178, 98);
            this.cmbRequisitionNo.Name = "cmbRequisitionNo";
            this.cmbRequisitionNo.Size = new System.Drawing.Size(231, 32);
            this.cmbRequisitionNo.TabIndex = 0;
            this.cmbRequisitionNo.SelectedIndexChanged += new System.EventHandler(this.cmbRequisitionNo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Fuchsia;
            this.label2.Location = new System.Drawing.Point(42, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Requisition No";
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(419, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(506, 40);
            this.label1.TabIndex = 18;
            this.label1.Text = "Aprove the requisition from here";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(445, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(359, 24);
            this.label11.TabIndex = 19;
            this.label11.Text = "Select Product to  Approve  Requisition";
            // 
            // deniedButton
            // 
            this.deniedButton.BackColor = System.Drawing.Color.Aqua;
            this.deniedButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deniedButton.ForeColor = System.Drawing.Color.Fuchsia;
            this.deniedButton.Location = new System.Drawing.Point(173, 449);
            this.deniedButton.Name = "deniedButton";
            this.deniedButton.Size = new System.Drawing.Size(127, 65);
            this.deniedButton.TabIndex = 20;
            this.deniedButton.Text = "Denied";
            this.deniedButton.UseVisualStyleBackColor = false;
            this.deniedButton.Click += new System.EventHandler(this.deniedButton_Click);
            // 
            // RequisitionApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1354, 536);
            this.Controls.Add(this.deniedButton);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.cmbRequisitionNo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.submitButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RequisitionApproval";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RequisitionApproval";
            this.Load += new System.EventHandler(this.RequisitionApproval_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.TextBox txtRequisitionAmount;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtReceiveAmount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.TextBox txtMasterStockProductId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbRequisitionNo;
        private System.Windows.Forms.TextBox txtImportOrderNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbActionStatus;
        private System.Windows.Forms.Label label6;
        public  System.Windows.Forms.TextBox txtFeederStockName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button deniedButton;
    }
}