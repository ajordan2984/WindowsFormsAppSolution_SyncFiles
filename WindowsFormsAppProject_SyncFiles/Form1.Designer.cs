
namespace WindowsFormsAppProject_SyncFiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pcFolder = new System.Windows.Forms.TextBox();
            this.externalFolder1 = new System.Windows.Forms.TextBox();
            this.buttonPcFolder = new System.Windows.Forms.Button();
            this.buttonExternalFolder1 = new System.Windows.Forms.Button();
            this.infoLable = new System.Windows.Forms.Label();
            this.buttonSyncFiles = new System.Windows.Forms.Button();
            this.buttonExternalFolder2 = new System.Windows.Forms.Button();
            this.externalFolder2 = new System.Windows.Forms.TextBox();
            this.buttonExternalFolder3 = new System.Windows.Forms.Button();
            this.externalFolder3 = new System.Windows.Forms.TextBox();
            this.richTextBoxMessages = new System.Windows.Forms.RichTextBox();
            this.buttonClearTextbox = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonExternalFolder4 = new System.Windows.Forms.Button();
            this.externalFolder4 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pcFolder
            // 
            this.pcFolder.Location = new System.Drawing.Point(141, 4);
            this.pcFolder.Name = "pcFolder";
            this.pcFolder.Size = new System.Drawing.Size(932, 22);
            this.pcFolder.TabIndex = 0;
            this.pcFolder.WordWrap = false;
            // 
            // externalFolder1
            // 
            this.externalFolder1.Location = new System.Drawing.Point(147, 356);
            this.externalFolder1.Name = "externalFolder1";
            this.externalFolder1.Size = new System.Drawing.Size(926, 22);
            this.externalFolder1.TabIndex = 1;
            this.externalFolder1.WordWrap = false;
            // 
            // buttonPcFolder
            // 
            this.buttonPcFolder.Location = new System.Drawing.Point(3, 3);
            this.buttonPcFolder.Name = "buttonPcFolder";
            this.buttonPcFolder.Size = new System.Drawing.Size(132, 23);
            this.buttonPcFolder.TabIndex = 2;
            this.buttonPcFolder.Text = "PC Folder";
            this.buttonPcFolder.UseVisualStyleBackColor = true;
            this.buttonPcFolder.Click += new System.EventHandler(this.buttonPcFolder_Click);
            // 
            // buttonExternalFolder1
            // 
            this.buttonExternalFolder1.Location = new System.Drawing.Point(3, 355);
            this.buttonExternalFolder1.Name = "buttonExternalFolder1";
            this.buttonExternalFolder1.Size = new System.Drawing.Size(132, 23);
            this.buttonExternalFolder1.TabIndex = 3;
            this.buttonExternalFolder1.Text = "External Folder 1";
            this.buttonExternalFolder1.UseVisualStyleBackColor = true;
            this.buttonExternalFolder1.Click += new System.EventHandler(this.buttonExternalFolder1_Click);
            // 
            // infoLable
            // 
            this.infoLable.Dock = System.Windows.Forms.DockStyle.Top;
            this.infoLable.Location = new System.Drawing.Point(0, 0);
            this.infoLable.Name = "infoLable";
            this.infoLable.Size = new System.Drawing.Size(1100, 23);
            this.infoLable.TabIndex = 4;
            this.infoLable.Text = "Please select the folder on your computer with files you want to sync to the exte" +
    "rnal drive(s) folder";
            this.infoLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonSyncFiles
            // 
            this.buttonSyncFiles.Location = new System.Drawing.Point(406, 468);
            this.buttonSyncFiles.Name = "buttonSyncFiles";
            this.buttonSyncFiles.Size = new System.Drawing.Size(132, 23);
            this.buttonSyncFiles.TabIndex = 5;
            this.buttonSyncFiles.Text = "Sync Files Now";
            this.buttonSyncFiles.UseVisualStyleBackColor = true;
            this.buttonSyncFiles.Click += new System.EventHandler(this.buttonSyncFiles_Click);
            // 
            // buttonExternalFolder2
            // 
            this.buttonExternalFolder2.Location = new System.Drawing.Point(3, 384);
            this.buttonExternalFolder2.Name = "buttonExternalFolder2";
            this.buttonExternalFolder2.Size = new System.Drawing.Size(132, 23);
            this.buttonExternalFolder2.TabIndex = 9;
            this.buttonExternalFolder2.Text = "External Folder 2";
            this.buttonExternalFolder2.UseVisualStyleBackColor = true;
            this.buttonExternalFolder2.Click += new System.EventHandler(this.buttonExternalFolder2_Click);
            // 
            // externalFolder2
            // 
            this.externalFolder2.Location = new System.Drawing.Point(147, 384);
            this.externalFolder2.Name = "externalFolder2";
            this.externalFolder2.Size = new System.Drawing.Size(926, 22);
            this.externalFolder2.TabIndex = 8;
            this.externalFolder2.WordWrap = false;
            // 
            // buttonExternalFolder3
            // 
            this.buttonExternalFolder3.Location = new System.Drawing.Point(3, 412);
            this.buttonExternalFolder3.Name = "buttonExternalFolder3";
            this.buttonExternalFolder3.Size = new System.Drawing.Size(132, 23);
            this.buttonExternalFolder3.TabIndex = 11;
            this.buttonExternalFolder3.Text = "External Folder 3";
            this.buttonExternalFolder3.UseVisualStyleBackColor = true;
            this.buttonExternalFolder3.Click += new System.EventHandler(this.buttonExternalFolder3_Click);
            // 
            // externalFolder3
            // 
            this.externalFolder3.Location = new System.Drawing.Point(147, 412);
            this.externalFolder3.Name = "externalFolder3";
            this.externalFolder3.Size = new System.Drawing.Size(926, 22);
            this.externalFolder3.TabIndex = 10;
            this.externalFolder3.WordWrap = false;
            // 
            // richTextBoxMessages
            // 
            this.richTextBoxMessages.BackColor = System.Drawing.SystemColors.HighlightText;
            this.richTextBoxMessages.Location = new System.Drawing.Point(3, 32);
            this.richTextBoxMessages.Name = "richTextBoxMessages";
            this.richTextBoxMessages.ReadOnly = true;
            this.richTextBoxMessages.Size = new System.Drawing.Size(1070, 317);
            this.richTextBoxMessages.TabIndex = 16;
            this.richTextBoxMessages.Text = "";
            // 
            // buttonClearTextbox
            // 
            this.buttonClearTextbox.Location = new System.Drawing.Point(544, 468);
            this.buttonClearTextbox.Name = "buttonClearTextbox";
            this.buttonClearTextbox.Size = new System.Drawing.Size(130, 23);
            this.buttonClearTextbox.TabIndex = 17;
            this.buttonClearTextbox.Text = "Clear Textbox";
            this.buttonClearTextbox.UseVisualStyleBackColor = true;
            this.buttonClearTextbox.Click += new System.EventHandler(this.buttonClearTextbox_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonExternalFolder4);
            this.panel1.Controls.Add(this.externalFolder4);
            this.panel1.Controls.Add(this.buttonPcFolder);
            this.panel1.Controls.Add(this.buttonExternalFolder3);
            this.panel1.Controls.Add(this.buttonClearTextbox);
            this.panel1.Controls.Add(this.externalFolder3);
            this.panel1.Controls.Add(this.pcFolder);
            this.panel1.Controls.Add(this.buttonExternalFolder2);
            this.panel1.Controls.Add(this.richTextBoxMessages);
            this.panel1.Controls.Add(this.externalFolder2);
            this.panel1.Controls.Add(this.externalFolder1);
            this.panel1.Controls.Add(this.buttonSyncFiles);
            this.panel1.Controls.Add(this.buttonExternalFolder1);
            this.panel1.Location = new System.Drawing.Point(12, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1076, 498);
            this.panel1.TabIndex = 18;
            // 
            // buttonExternalFolder4
            // 
            this.buttonExternalFolder4.Location = new System.Drawing.Point(3, 440);
            this.buttonExternalFolder4.Name = "buttonExternalFolder4";
            this.buttonExternalFolder4.Size = new System.Drawing.Size(132, 23);
            this.buttonExternalFolder4.TabIndex = 19;
            this.buttonExternalFolder4.Text = "External Folder 4";
            this.buttonExternalFolder4.UseVisualStyleBackColor = true;
            this.buttonExternalFolder4.Click += new System.EventHandler(this.buttonExternalFolder4_Click);
            // 
            // externalFolder4
            // 
            this.externalFolder4.Location = new System.Drawing.Point(147, 440);
            this.externalFolder4.Name = "externalFolder4";
            this.externalFolder4.Size = new System.Drawing.Size(926, 22);
            this.externalFolder4.TabIndex = 18;
            this.externalFolder4.WordWrap = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 529);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.infoLable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Sync Files";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox pcFolder;
        private System.Windows.Forms.TextBox externalFolder1;
        private System.Windows.Forms.Button buttonPcFolder;
        private System.Windows.Forms.Button buttonExternalFolder1;
        private System.Windows.Forms.Label infoLable;
        private System.Windows.Forms.Button buttonSyncFiles;
        private System.Windows.Forms.Button buttonExternalFolder2;
        private System.Windows.Forms.TextBox externalFolder2;
        private System.Windows.Forms.Button buttonExternalFolder3;
        private System.Windows.Forms.TextBox externalFolder3;
        private System.Windows.Forms.RichTextBox richTextBoxMessages;
        private System.Windows.Forms.Button buttonClearTextbox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonExternalFolder4;
        private System.Windows.Forms.TextBox externalFolder4;
    }
}

