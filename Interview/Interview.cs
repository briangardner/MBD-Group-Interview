﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Interview
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            ReportRequest report = new ReportRequest(fldrXMLPath.folderPath, fldrResultPath.folderPath, fldrXMLPath.showIncludeSubfolders, txtXMLElement.Text.Trim());
            try
            {
                report.GenerateReport();
                MessageBox.Show("File Created");
                System.Diagnostics.Process.Start(this.fldrResultPath.folderPath + "\\Results.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occured: " + ex.Message.ToString());
            }
            
        }
    }
}
