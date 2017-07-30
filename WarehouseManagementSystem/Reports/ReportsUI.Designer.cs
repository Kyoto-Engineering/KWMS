namespace WarehouseManagementSystem.Reports
{
    partial class ReportsUI
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ProMovementButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.PrintDeliveryAckButton = new System.Windows.Forms.Button();
            this.PrintInvoiceButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PrintInvoiceButton);
            this.groupBox1.Controls.Add(this.PrintDeliveryAckButton);
            this.groupBox1.Controls.Add(this.ProMovementButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(635, 369);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // ProMovementButton
            // 
            this.ProMovementButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProMovementButton.Location = new System.Drawing.Point(16, 19);
            this.ProMovementButton.Name = "ProMovementButton";
            this.ProMovementButton.Size = new System.Drawing.Size(122, 61);
            this.ProMovementButton.TabIndex = 0;
            this.ProMovementButton.Text = "Product Movement";
            this.ProMovementButton.UseVisualStyleBackColor = true;
            this.ProMovementButton.Click += new System.EventHandler(this.ProMovementButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(539, 15);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // PrintDeliveryAckButton
            // 
            this.PrintDeliveryAckButton.Location = new System.Drawing.Point(166, 19);
            this.PrintDeliveryAckButton.Name = "PrintDeliveryAckButton";
            this.PrintDeliveryAckButton.Size = new System.Drawing.Size(130, 61);
            this.PrintDeliveryAckButton.TabIndex = 21;
            this.PrintDeliveryAckButton.Text = "Print Delivery Acknowledgement ";
            this.PrintDeliveryAckButton.UseVisualStyleBackColor = true;
            this.PrintDeliveryAckButton.Click += new System.EventHandler(this.PrintDeliveryAckButton_Click);
            // 
            // PrintInvoiceButton
            // 
            this.PrintInvoiceButton.Location = new System.Drawing.Point(324, 21);
            this.PrintInvoiceButton.Name = "PrintInvoiceButton";
            this.PrintInvoiceButton.Size = new System.Drawing.Size(103, 57);
            this.PrintInvoiceButton.TabIndex = 22;
            this.PrintInvoiceButton.Text = "Print Invoice";
            this.PrintInvoiceButton.UseVisualStyleBackColor = true;
            this.PrintInvoiceButton.Click += new System.EventHandler(this.PrintInvoiceButton_Click);
            // 
            // ReportsUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 445);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReportsUI";
            this.Text = "ReportsUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReportsUI_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ProMovementButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button PrintDeliveryAckButton;
        private System.Windows.Forms.Button PrintInvoiceButton;
    }
}