namespace WarehouseManagementSystem.UI
{
    partial class NewFeederStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewFeederStock));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFeederName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFeederName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(591, 135);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtFeederName
            // 
            this.txtFeederName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFeederName.Location = new System.Drawing.Point(176, 46);
            this.txtFeederName.Name = "txtFeederName";
            this.txtFeederName.Size = new System.Drawing.Size(388, 29);
            this.txtFeederName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Feeder Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonSubmit.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubmit.ForeColor = System.Drawing.Color.Blue;
            this.buttonSubmit.Location = new System.Drawing.Point(430, 162);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(173, 73);
            this.buttonSubmit.TabIndex = 1;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = false;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // NewFeederStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(619, 241);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewFeederStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewFeederStock";
            this.Load += new System.EventHandler(this.NewFeederStock_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtFeederName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSubmit;
    }
}