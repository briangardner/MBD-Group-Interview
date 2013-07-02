using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Interview
{
    public partial class FolderBrowser : UserControl
    {
        public FolderBrowser()
        {
            InitializeComponent();
        }
        public string Prompt
        {
            get
            {
                return lblPrompt.Text;
            }
            set
            {
                lblPrompt.Text = value;
            }
        }

        public bool showIncludeSubfolders
        {
            get
            {
                return chkIncludeSubfolders.Visible;
            }
            set
            {
                chkIncludeSubfolders.Visible = value;
            }
        }

        public string folderPath
        {
            get
            {
                return txtPath.Text;
            }
        }
        private void btnBrowser_Click(object sender, EventArgs e)
        {
            fldrBrowser.ShowDialog();
            txtPath.Text = fldrBrowser.SelectedPath;
        }
    }
}
