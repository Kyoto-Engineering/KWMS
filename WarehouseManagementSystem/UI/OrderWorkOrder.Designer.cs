namespace WarehouseManagementSystem.UI
{
    partial class OrderWorkOrder
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderWorkOrder));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.invoiceDate = new System.Windows.Forms.DateTimePicker();
            this.lcDate = new System.Windows.Forms.DateTimePicker();
            this.importOrderDate = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lcNumberTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.invoiceNumberTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.packingListNoTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.purchaseOrderNoTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.invoiceDate);
            this.groupBox1.Controls.Add(this.lcDate);
            this.groupBox1.Controls.Add(this.importOrderDate);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lcNumberTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.invoiceNumberTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.packingListNoTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.purchaseOrderNoTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(23, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(704, 468);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // invoiceDate
            // 
            this.invoiceDate.Enabled = false;
            this.invoiceDate.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.invoiceDate.Location = new System.Drawing.Point(311, 281);
            this.invoiceDate.Name = "invoiceDate";
            this.invoiceDate.Size = new System.Drawing.Size(278, 32);
            this.invoiceDate.TabIndex = 5;
            this.invoiceDate.ValueChanged += new System.EventHandler(this.invoiceDate_ValueChanged);
            // 
            // lcDate
            // 
            this.lcDate.Enabled = false;
            this.lcDate.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.lcDate.Location = new System.Drawing.Point(311, 179);
            this.lcDate.Name = "lcDate";
            this.lcDate.Size = new System.Drawing.Size(278, 32);
            this.lcDate.TabIndex = 3;
            this.lcDate.ValueChanged += new System.EventHandler(this.lcDate_ValueChanged);
            // 
            // importOrderDate
            // 
            this.importOrderDate.Enabled = false;
            this.importOrderDate.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.importOrderDate.Location = new System.Drawing.Point(310, 73);
            this.importOrderDate.Name = "importOrderDate";
            this.importOrderDate.Size = new System.Drawing.Size(277, 32);
            this.importOrderDate.TabIndex = 1;
            this.importOrderDate.ValueChanged += new System.EventHandler(this.importOrderDate_ValueChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Teal;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(311, 392);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 52);
            this.button2.TabIndex = 8;
            this.button2.Text = "Edit";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.AliceBlue;
            this.button1.Location = new System.Drawing.Point(466, 390);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 52);
            this.button1.TabIndex = 7;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label4.Location = new System.Drawing.Point(208, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 22);
            this.label4.TabIndex = 26;
            this.label4.Text = "LC Date";
            // 
            // lcNumberTextBox
            // 
            this.lcNumberTextBox.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcNumberTextBox.Location = new System.Drawing.Point(311, 128);
            this.lcNumberTextBox.Name = "lcNumberTextBox";
            this.lcNumberTextBox.ReadOnly = true;
            this.lcNumberTextBox.Size = new System.Drawing.Size(278, 32);
            this.lcNumberTextBox.TabIndex = 2;
            this.lcNumberTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lcNumberTextBox_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(185, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 22);
            this.label3.TabIndex = 24;
            this.label3.Text = "LC Number";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Chartreuse;
            this.label7.Location = new System.Drawing.Point(147, 331);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 22);
            this.label7.TabIndex = 23;
            this.label7.Text = "Packing List No";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Chartreuse;
            this.label6.Location = new System.Drawing.Point(180, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 22);
            this.label6.TabIndex = 20;
            this.label6.Text = "Invoice Date";
            // 
            // invoiceNumberTextBox
            // 
            this.invoiceNumberTextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoiceNumberTextBox.Location = new System.Drawing.Point(311, 235);
            this.invoiceNumberTextBox.Name = "invoiceNumberTextBox";
            this.invoiceNumberTextBox.ReadOnly = true;
            this.invoiceNumberTextBox.Size = new System.Drawing.Size(278, 29);
            this.invoiceNumberTextBox.TabIndex = 4;
            this.invoiceNumberTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.invoiceNumberTextBox_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Chartreuse;
            this.label5.Location = new System.Drawing.Point(152, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 22);
            this.label5.TabIndex = 18;
            this.label5.Text = "Invoice Number";
            // 
            // packingListNoTextBox
            // 
            this.packingListNoTextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.packingListNoTextBox.Location = new System.Drawing.Point(311, 328);
            this.packingListNoTextBox.Name = "packingListNoTextBox";
            this.packingListNoTextBox.ReadOnly = true;
            this.packingListNoTextBox.Size = new System.Drawing.Size(278, 29);
            this.packingListNoTextBox.TabIndex = 6;
            this.packingListNoTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.packingListNoTextBox_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Chartreuse;
            this.label2.Location = new System.Drawing.Point(189, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 22);
            this.label2.TabIndex = 16;
            this.label2.Text = "Order Date";
            // 
            // purchaseOrderNoTextBox
            // 
            this.purchaseOrderNoTextBox.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchaseOrderNoTextBox.Location = new System.Drawing.Point(310, 25);
            this.purchaseOrderNoTextBox.Name = "purchaseOrderNoTextBox";
            this.purchaseOrderNoTextBox.ReadOnly = true;
            this.purchaseOrderNoTextBox.Size = new System.Drawing.Size(279, 32);
            this.purchaseOrderNoTextBox.TabIndex = 0;
            this.purchaseOrderNoTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.purchaseOrderNoTextBox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Chartreuse;
            this.label1.Location = new System.Drawing.Point(138, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 22);
            this.label1.TabIndex = 14;
            this.label1.Text = "Import Order No";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Yellow;
            this.label8.Location = new System.Drawing.Point(65, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(611, 22);
            this.label8.TabIndex = 2;
            this.label8.Text = "Check that you have entered Right Information. To edit click  Edit button.";
            // 
            // OrderWorkOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(762, 545);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrderWorkOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrderWorkOrder";
            this.Load += new System.EventHandler(this.OrderWorkOrder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        public  System.Windows.Forms.TextBox invoiceNumberTextBox;
        private System.Windows.Forms.Label label5;
        public  System.Windows.Forms.TextBox packingListNoTextBox;
        private System.Windows.Forms.Label label2;
        public  System.Windows.Forms.TextBox purchaseOrderNoTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        public  System.Windows.Forms.TextBox lcNumberTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.DateTimePicker invoiceDate;
        public  System.Windows.Forms.DateTimePicker lcDate;
        public  System.Windows.Forms.DateTimePicker importOrderDate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label8;
    }
}