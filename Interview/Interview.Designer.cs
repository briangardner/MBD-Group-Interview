namespace Interview
{
    partial class Form1
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
            this.lblXMLElement = new System.Windows.Forms.Label();
            this.txtXMLElement = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.fldrResultPath = new Interview.FolderBrowser();
            this.fldrXMLPath = new Interview.FolderBrowser();
            this.SuspendLayout();
            // 
            // lblXMLElement
            // 
            this.lblXMLElement.AutoSize = true;
            this.lblXMLElement.Location = new System.Drawing.Point(12, 9);
            this.lblXMLElement.Name = "lblXMLElement";
            this.lblXMLElement.Size = new System.Drawing.Size(122, 13);
            this.lblXMLElement.TabIndex = 6;
            this.lblXMLElement.Text = "XML element to look for:";
            // 
            // txtXMLElement
            // 
            this.txtXMLElement.Location = new System.Drawing.Point(12, 28);
            this.txtXMLElement.Name = "txtXMLElement";
            this.txtXMLElement.Size = new System.Drawing.Size(181, 20);
            this.txtXMLElement.TabIndex = 5;
            this.txtXMLElement.Text = "CANPort";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 204);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 9;
            this.btnRun.Text = "Report";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // fldrResultPath
            // 
            this.fldrResultPath.Location = new System.Drawing.Point(15, 130);
            this.fldrResultPath.Name = "fldrResultPath";
            this.fldrResultPath.Prompt = "Report Path:";
            this.fldrResultPath.showIncludeSubfolders = false;
            this.fldrResultPath.Size = new System.Drawing.Size(278, 48);
            this.fldrResultPath.TabIndex = 8;
            // 
            // fldrXMLPath
            // 
            this.fldrXMLPath.Location = new System.Drawing.Point(15, 55);
            this.fldrXMLPath.Name = "fldrXMLPath";
            this.fldrXMLPath.Prompt = "Top Level XML Path:";
            this.fldrXMLPath.showIncludeSubfolders = true;
            this.fldrXMLPath.Size = new System.Drawing.Size(278, 68);
            this.fldrXMLPath.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 325);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.fldrResultPath);
            this.Controls.Add(this.fldrXMLPath);
            this.Controls.Add(this.lblXMLElement);
            this.Controls.Add(this.txtXMLElement);
            this.Name = "Form1";
            this.Text = "Technical Interview";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblXMLElement;
        private System.Windows.Forms.TextBox txtXMLElement;
        private FolderBrowser fldrXMLPath;
        private FolderBrowser fldrResultPath;
        private System.Windows.Forms.Button btnRun;

    }
}

