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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderReceive));
            this.receiveOrderButton = new System.Windows.Forms.Button();
            this.receiveDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPurchaseOrderNo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.receivePriceTextBox = new System.Windows.Forms.TextBox();
            this.receiveQuantityTextBox = new System.Windows.Forms.TextBox();
            this.cmbProductId = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.doneButton = new System.Windows.Forms.Button();
            this.localStoreButton = new System.Windows.Forms.Button();
            this.txtCOGSUnitPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // receiveOrderButton
            // 
            this.receiveOrderButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.receiveOrderButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.receiveOrderButton.ForeColor = System.Drawing.Color.Blue;
            this.receiveOrderButton.Location = new System.Drawing.Point(423, 312);
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
            this.receiveDate.Location = new System.Drawing.Point(286, 128);
            this.receiveDate.Name = "receiveDate";
            this.receiveDate.Size = new System.Drawing.Size(250, 29);
            this.receiveDate.TabIndex = 2;
            this.receiveDate.ValueChanged += new System.EventHandler(this.receiveDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(124, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 22);
            this.label2.TabIndex = 39;
            this.label2.Text = "Receive Date";
            // 
            // cmbPurchaseOrderNo
            // 
            this.cmbPurchaseOrderNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPurchaseOrderNo.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPurchaseOrderNo.FormattingEnabled = true;
            this.cmbPurchaseOrderNo.Location = new System.Drawing.Point(286, 32);
            this.cmbPurchaseOrderNo.Name = "cmbPurchaseOrderNo";
            this.cmbPurchaseOrderNo.Size = new System.Drawing.Size(250, 30);
            this.cmbPurchaseOrderNo.TabIndex = 0;
            this.cmbPurchaseOrderNo.SelectedIndexChanged += new System.EventHandler(this.cmbWorkOrderNo_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(83, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 22);
            this.label6.TabIndex = 37;
            this.label6.Text = "Import Order No";
            // 
            // receivePriceTextBox
            // 
            this.receivePriceTextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.receivePriceTextBox.Location = new System.Drawing.Point(286, 259);
            this.receivePriceTextBox.Name = "receivePriceTextBox";
            this.receivePriceTextBox.Size = new System.Drawing.Size(250, 29);
            this.receivePriceTextBox.TabIndex = 4;
            this.receivePriceTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.receivePriceTextBox_KeyDown);
            this.receivePriceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.receivePriceTextBox_KeyPress);
            // 
            // receiveQuantityTextBox
            // 
            this.receiveQuantityTextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.receiveQuantityTextBox.Location = new System.Drawing.Point(286, 177);
            this.receiveQuantityTextBox.Name = "receiveQuantityTextBox";
            this.receiveQuantityTextBox.Size = new System.Drawing.Size(250, 29);
            this.receiveQuantityTextBox.TabIndex = 3;
            this.receiveQuantityTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.receiveQuantityTextBox_KeyDown);
            this.receiveQuantityTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.receiveQuantityTextBox_KeyPress);
            // 
            // cmbProductId
            // 
            this.cmbProductId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductId.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProductId.FormattingEnabled = true;
            this.cmbProductId.Location = new System.Drawing.Point(286, 78);
            this.cmbProductId.Name = "cmbProductId";
            this.cmbProductId.Size = new System.Drawing.Size(250, 30);
            this.cmbProductId.TabIndex = 1;
            this.cmbProductId.SelectedIndexChanged += new System.EventHandler(this.cmbProductId_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(87, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 22);
            this.label5.TabIndex = 33;
            this.label5.Text = "Receive Quantity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(78, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 22);
            this.label4.TabIndex = 32;
            this.label4.Text = "Receive Unit Price";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(140, 81);
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
            this.doneButton.Location = new System.Drawing.Point(727, 390);
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
            this.localStoreButton.Location = new System.Drawing.Point(268, 312);
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
            this.txtCOGSUnitPrice.Location = new System.Drawing.Point(288, 218);
            this.txtCOGSUnitPrice.Name = "txtCOGSUnitPrice";
            this.txtCOGSUnitPrice.Size = new System.Drawing.Size(250, 29);
            this.txtCOGSUnitPrice.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(84, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 22);
            this.label3.TabIndex = 44;
            this.label3.Text = "COGS Unit Price";
            // 
            // OrderReceive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(734, 444);
            this.Controls.Add(this.txtCOGSUnitPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.localStoreButton);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.receiveOrderButton);
            this.Controls.Add(this.receiveDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbPurchaseOrderNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.receivePriceTextBox);
            this.Controls.Add(this.receiveQuantityTextBox);
            this.Controls.Add(this.cmbProductId);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button receiveOrderButton;
        private System.Windows.Forms.DateTimePicker receiveDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPurchaseOrderNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox receivePriceTextBox;
        private System.Windows.Forms.TextBox receiveQuantityTextBox;
        private System.Windows.Forms.ComboBox cmbProductId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.Button localStoreButton;
        private System.Windows.Forms.TextBox txtCOGSUnitPrice;
        private System.Windows.Forms.Label label3;
    }
}