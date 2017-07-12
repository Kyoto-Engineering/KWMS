﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using WarehouseManagementSystem.DAO;
using WarehouseManagementSystem.DbGateway;
using ZXing;
using ZXing.Common;

namespace WarehouseManagementSystem.Reports
{
    public partial class IUI : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        ConnectionString cs = new ConnectionString();
        private SqlDataReader rdr;
        public int quotationId, brandid;
        public string qtype;
        public IUI()
        {
            InitializeComponent();
        }

        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // Your background task goes here
            for (int i = 0; i <= 20; i++)
            {
                // Report progress to 'UI' thread
                backgroundWorker1.ReportProgress(i);
                // Simulate long task
                System.Threading.Thread.Sleep(100);
            }
        }
        // Back on the 'UI' thread so we can update the progress bar
        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // The progress percentage is a property of e
            progressBar1.Value = e.ProgressPercentage;
        }
        private void IUI_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "SELECT  RefNumForQuotation.ReferenceNo FROM Delivery INNER JOIN RefNumForQuotation ON Delivery.QuotationId = RefNumForQuotation.QuotationId";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    comboBox1.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Report1()
        {
            button1.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
            progressBar1.Visible = true;

            // To report progress from the background worker we need to set this property
            backgroundWorker1.WorkerReportsProgress = true;
            // This event will be raised on the worker thread when the worker starts
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            // This event will be raised when we call ReportProgress
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            ParameterField paramField1 = new ParameterField();


            //creating an object of ParameterFields class
            ParameterFields paramFields1 = new ParameterFields();

            //creating an object of ParameterDiscreteValue class
            ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();

            //set the parameter field name
            paramField1.Name = "id";

            //set the parameter value
            paramDiscreteValue1.Value = quotationId;

            //add the parameter value in the ParameterField object
            paramField1.CurrentValues.Add(paramDiscreteValue1);

            //add the parameter in the ParameterFields object
            paramFields1.Add(paramField1);
            ReportViewer f2 = new ReportViewer();
            TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
            TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
            ConnectionInfo reportConInfo = new ConnectionInfo();
            Tables tables = default(Tables);
            //	Table table = default(Table);
            var with1 = reportConInfo;
            with1.ServerName = "tcp:KyotoServer,49172";
            with1.DatabaseName = "ProductNRelatedDB";
            with1.UserID = "sa";
            with1.Password = "SystemAdministrator";
            ReportDocument cr = new ReportDocument();
            if (brandid == 1)
            {
                cr = new Invoice();
            }
            else if (brandid == 2)
            {
                cr = new InvoiceKEAL();
            }
            else if (brandid == 3)
            {
                cr = new InvoiceAzbil();
            }
            else if (brandid == 4)
            {
                cr = new InvoiceBA();
            }
            else if (brandid == 5)
            {
                cr = new InvoiceIRD();
            }
            else if (brandid == 6)
            {
                cr = new InvoiceKawaShima();
            }
            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }
            BArcode ds = new BArcode();

            var content = comboBox1.Text;
            var writer = new BarcodeWriter
            {

                Format = BarcodeFormat.CODE_128,
                Options = new EncodingOptions
                {
                    PureBarcode = true,
                    Height = 100,
                    Width = 465
                }
            };
            var png = writer.Write(content);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            png.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

            DataRow dtr = ds.Tables[0].NewRow();
            dtr["REF"] = comboBox1.Text;
            dtr["BarcodeImage"] = ms.ToArray();
            ds.Tables[0].Rows.Add(dtr);
            cr.Subreports["BarCode.rpt"].DataSourceConnections.Clear();
            cr.Subreports["BarCode.rpt"].SetDataSource(ds);
            f2.crystalReportViewer1.ParameterFieldInfo = paramFields1;
            f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;

            f2.ShowDialog();
            this.Visible = true;
            backgroundWorker1.CancelAsync();
            backgroundWorker1.Dispose();
            progressBar1.Visible = false;
            button1.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select   T.QuotationId, T.QType, BrandId from  Quotation T JOIN RefNumForQuotation N ON T.QuotationId = N.QuotationId  where N.ReferenceNo='" + comboBox1.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    // txtBalance.Text = (rdr.GetDouble(0).ToString());
                    quotationId = (rdr.GetInt32(0));
                    qtype = (rdr.GetString(1));
                    brandid = Convert.ToInt32(rdr["BrandId"]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
