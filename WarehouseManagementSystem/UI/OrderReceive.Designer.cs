namespace WarehouseManagementSystem.UI
{
    partial class OrderReceive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderReceive));
            this.receiveOrderButton = new System.Windows.Forms.Button();
            this.receiveDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbImportOrderNo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtReceiveUnitPrice = new System.Windows.Forms.TextBox();
            this.txtReceiveQuantity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.doneButton = new System.Windows.Forms.Button();
            this.localStoreButton = new System.Windows.Forms.Button();
            this.txtCOGSUnitPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.g = new System.Windows.Forms.Label();
            this.k = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // receiveOrderButton
            // 
            this.receiveOrderButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.receiveOrderButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.receiveOrderButton.ForeColor = System.Drawing.Color.Blue;
            this.receiveOrderButton.Location = new System.Drawing.Point(323, 355);
            this.receiveOrderButton.Name = "receiveOrderButton";
            this.receiveOrderButton.Size = new System.Drawing.Size(113, 54);
            this.receiveOrderButton.TabIndex = 5;
            this.receiveOrderButton.Text = "Receive";
            this.receiveOrderButton.UseVisualStyleBackColor = false;
            this.receiveOrderButton.Click += new System.EventHandler(this.receiveOrderButton_Click);
            // 
            // receiveDate
            // 
            this.receiveDate.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.receiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.receiveDate.Location = new System.Drawing.Point(188, 171);
            this.receiveDate.Name = "receiveDate";
            this.receiveDate.Size = new System.Drawing.Size(248, 29);
            this.receiveDate.TabIndex = 2;
            this.receiveDate.ValueChanged += new System.EventHandler(this.receiveDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(63, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 22);
            this.label2.TabIndex = 39;
            this.label2.Text = "Receive Date";
            // 
            // cmbImportOrderNo
            // 
            this.cmbImportOrderNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImportOrderNo.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbImportOrderNo.FormattingEnabled = true;
            this.cmbImportOrderNo.Location = new System.Drawing.Point(186, 75);
            this.cmbImportOrderNo.Name = "cmbImportOrderNo";
            this.cmbImportOrderNo.Size = new System.Drawing.Size(250, 30);
            this.cmbImportOrderNo.TabIndex = 0;
            this.cmbImportOrderNo.SelectedIndexChanged += new System.EventHandler(this.cmbWorkOrderNo_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 22);
            this.label6.TabIndex = 37;
            this.label6.Text = "Import Order No";
            // 
            // txtReceiveUnitPrice
            // 
            this.txtReceiveUnitPrice.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiveUnitPrice.Location = new System.Drawing.Point(188, 302);
            this.txtReceiveUnitPrice.Name = "txtReceiveUnitPrice";
            this.txtReceiveUnitPrice.Size = new System.Drawing.Size(248, 29);
            this.txtReceiveUnitPrice.TabIndex = 4;
            this.txtReceiveUnitPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.receivePriceTextBox_KeyDown);
            this.txtReceiveUnitPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.receivePriceTextBox_KeyPress);
            // 
            // txtReceiveQuantity
            // 
            this.txtReceiveQuantity.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiveQuantity.Location = new System.Drawing.Point(188, 220);
            this.txtReceiveQuantity.Name = "txtReceiveQuantity";
            this.txtReceiveQuantity.Size = new System.Drawing.Size(250, 29);
            this.txtReceiveQuantity.TabIndex = 3;
            this.txtReceiveQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.receiveQuantityTextBox_KeyDown);
            this.txtReceiveQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.receiveQuantityTextBox_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 22);
            this.label5.TabIndex = 33;
            this.label5.Text = "Receive Quantity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 305);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 22);
            this.label4.TabIndex = 32;
            this.label4.Text = "Receive Unit Price";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(79, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 22);
            this.label1.TabIndex = 31;
            this.label1.Text = "Product Id";
            // 
            // doneButton
            // 
            this.doneButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.doneButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doneButton.ForeColor = System.Drawing.Color.Brown;
            this.doneButton.Location = new System.Drawing.Point(1265, 389);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(10, 54);
            this.doneButton.TabIndex = 42;
            this.doneButton.UseVisualStyleBackColor = false;
            this.doneButton.Visible = false;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // localStoreButton
            // 
            this.localStoreButton.BackColor = System.Drawing.Color.Teal;
            this.localStoreButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localStoreButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.localStoreButton.Location = new System.Drawing.Point(168, 355);
            this.localStoreButton.Name = "localStoreButton";
            this.localStoreButton.Size = new System.Drawing.Size(112, 54);
            this.localStoreButton.TabIndex = 6;
            this.localStoreButton.Text = "View Local Store";
            this.localStoreButton.UseVisualStyleBackColor = false;
            this.localStoreButton.Click += new System.EventHandler(this.localStoreButton_Click);
            // 
            // txtCOGSUnitPrice
            // 
            this.txtCOGSUnitPrice.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCOGSUnitPrice.Location = new System.Drawing.Point(188, 261);
            this.txtCOGSUnitPrice.Name = "txtCOGSUnitPrice";
            this.txtCOGSUnitPrice.Size = new System.Drawing.Size(250, 29);
            this.txtCOGSUnitPrice.TabIndex = 43;
            this.txtCOGSUnitPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCOGSUnitPrice_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 22);
            this.label3.TabIndex = 44;
            this.label3.Text = "COGS Unit Price";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(489, 69);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(750, 363);
            this.dataGridView1.TabIndex = 45;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // txtProductId
            // 
            this.txtProductId.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductId.Location = new System.Drawing.Point(188, 121);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(248, 29);
            this.txtProductId.TabIndex = 46;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ImportOrderNo";
            this.Column1.Name = "Column1";
            this.Column1.Width = 140;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Product Id";
            this.Column2.Name = "Column2";
            this.Column2.Width = 120;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Product Name";
            this.Column3.Name = "Column3";
            this.Column3.Width = 280;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Item Code";
            this.Column4.Name = "Column4";
            this.Column4.Width = 160;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(306, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(421, 40);
            this.label7.TabIndex = 47;
            this.label7.Text = "Select Product  for Receive";
            // 
            // g
            // 
            this.g.AutoSize = true;
            this.g.Location = new System.Drawing.Point(21, 418);
            this.g.Name = "g";
            this.g.Size = new System.Drawing.Size(13, 13);
            this.g.TabIndex = 48;
            this.g.Text = "g";
            this.g.Visible = false;
            // 
            // k
            // 
            this.k.AutoSize = true;
            this.k.Location = new System.Drawing.Point(83, 417);
            this.k.Name = "k";
            this.k.Size = new System.Drawing.Size(13, 13);
            this.k.TabIndex = 49;
            this.k.Text = "k";
            this.k.Visible = false;
            // 
            // OrderReceive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1275, 444);
            this.Controls.Add(this.k);
            this.Controls.Add(this.g);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtProductId);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtCOGSUnitPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.localStoreButton);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.receiveOrderButton);
            this.Controls.Add(this.receiveDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbImportOrderNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtReceiveUnitPrice);
            this.Controls.Add(this.txtReceiveQuantity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderReceive";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrderReceive";
            this.Load += new System.EventHandler(this.OrderReceive_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button receiveOrderButton;
        private System.Windows.Forms.DateTimePicker receiveDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbImportOrderNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtReceiveUnitPrice;
        private System.Windows.Forms.TextBox txtReceiveQuantity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.Button localStoreButton;
        private System.Windows.Forms.TextBox txtCOGSUnitPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label g;
        private System.Windows.Forms.Label k;
    }
}