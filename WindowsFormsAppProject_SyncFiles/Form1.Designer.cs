
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
            this.pcFolderDirectory = new System.Windows.Forms.TextBox();
            this.externalFolderDirectory1 = new System.Windows.Forms.TextBox();
            this.buttonPcFolder = new System.Windows.Forms.Button();
            this.buttonExternalFolder1 = new System.Windows.Forms.Button();
            this.infoLable = new System.Windows.Forms.Label();
            this.buttonSyncFiles = new System.Windows.Forms.Button();
            this.buttonExternalFolder2 = new System.Windows.Forms.Button();
            this.externalFolderDirectory2 = new System.Windows.Forms.TextBox();
            this.buttonExternalFolder3 = new System.Windows.Forms.Button();
            this.externalFolderDirectory3 = new System.Windows.Forms.TextBox();
            this.progressBarExternalFolder2 = new System.Windows.Forms.ProgressBar();
            this.progressBarExternalFolder1 = new System.Windows.Forms.ProgressBar();
            this.progressBarExternalFolder3 = new System.Windows.Forms.ProgressBar();
            this.richTextBoxMessages = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // pcFolderDirectory
            // 
            this.pcFolderDirectory.Location = new System.Drawing.Point(156, 44);
            this.pcFolderDirectory.Name = "pcFolderDirectory";
            this.pcFolderDirectory.ReadOnly = true;
            this.pcFolderDirectory.Size = new System.Drawing.Size(627, 22);
            this.pcFolderDirectory.TabIndex = 0;
            this.pcFolderDirectory.WordWrap = false;
            // 
            // externalFolderDirectory1
            // 
            this.externalFolderDirectory1.Location = new System.Drawing.Point(156, 229);
            this.externalFolderDirectory1.Name = "externalFolderDirectory1";
            this.externalFolderDirectory1.ReadOnly = true;
            this.externalFolderDirectory1.Size = new System.Drawing.Size(627, 22);
            this.externalFolderDirectory1.TabIndex = 1;
            this.externalFolderDirectory1.WordWrap = false;
            // 
            // buttonPcFolder
            // 
            this.buttonPcFolder.Location = new System.Drawing.Point(12, 43);
            this.buttonPcFolder.Name = "buttonPcFolder";
            this.buttonPcFolder.Size = new System.Drawing.Size(132, 23);
            this.buttonPcFolder.TabIndex = 2;
            this.buttonPcFolder.Text = "PC Folder";
            this.buttonPcFolder.UseVisualStyleBackColor = true;
            this.buttonPcFolder.Click += new System.EventHandler(this.buttonPcFolder_Click);
            // 
            // buttonExternalFolder1
            // 
            this.buttonExternalFolder1.Location = new System.Drawing.Point(12, 228);
            this.buttonExternalFolder1.Name = "buttonExternalFolder1";
            this.buttonExternalFolder1.Size = new System.Drawing.Size(132, 23);
            this.buttonExternalFolder1.TabIndex = 3;
            this.buttonExternalFolder1.Text = "External Folder 1";
            this.buttonExternalFolder1.UseVisualStyleBackColor = true;
            this.buttonExternalFolder1.Click += new System.EventHandler(this.buttonExternalFolder1_Click);
            // 
            // infoLable
            // 
            this.infoLable.Location = new System.Drawing.Point(18, 18);
            this.infoLable.Name = "infoLable";
            this.infoLable.Size = new System.Drawing.Size(607, 23);
            this.infoLable.TabIndex = 4;
            this.infoLable.Text = "Please select the folder on your computer with files you want to sync to the exte" +
    "rnal drive(s) folder";
            this.infoLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonSyncFiles
            // 
            this.buttonSyncFiles.Location = new System.Drawing.Point(12, 433);
            this.buttonSyncFiles.Name = "buttonSyncFiles";
            this.buttonSyncFiles.Size = new System.Drawing.Size(132, 23);
            this.buttonSyncFiles.TabIndex = 5;
            this.buttonSyncFiles.Text = "Sync Files Now";
            this.buttonSyncFiles.UseVisualStyleBackColor = true;
            this.buttonSyncFiles.Click += new System.EventHandler(this.buttonSyncFiles_Click);
            // 
            // buttonExternalFolder2
            // 
            this.buttonExternalFolder2.Location = new System.Drawing.Point(12, 294);
            this.buttonExternalFolder2.Name = "buttonExternalFolder2";
            this.buttonExternalFolder2.Size = new System.Drawing.Size(132, 23);
            this.buttonExternalFolder2.TabIndex = 9;
            this.buttonExternalFolder2.Text = "External Folder 2";
            this.buttonExternalFolder2.UseVisualStyleBackColor = true;
            this.buttonExternalFolder2.Click += new System.EventHandler(this.buttonExternalFolder2_Click);
            // 
            // externalFolderDirectory2
            // 
            this.externalFolderDirectory2.Location = new System.Drawing.Point(156, 295);
            this.externalFolderDirectory2.Name = "externalFolderDirectory2";
            this.externalFolderDirectory2.ReadOnly = true;
            this.externalFolderDirectory2.Size = new System.Drawing.Size(627, 22);
            this.externalFolderDirectory2.TabIndex = 8;
            this.externalFolderDirectory2.WordWrap = false;
            // 
            // buttonExternalFolder3
            // 
            this.buttonExternalFolder3.Location = new System.Drawing.Point(13, 361);
            this.buttonExternalFolder3.Name = "buttonExternalFolder3";
            this.buttonExternalFolder3.Size = new System.Drawing.Size(132, 23);
            this.buttonExternalFolder3.TabIndex = 11;
            this.buttonExternalFolder3.Text = "External Folder 3";
            this.buttonExternalFolder3.UseVisualStyleBackColor = true;
            this.buttonExternalFolder3.Click += new System.EventHandler(this.buttonExternalFolder3_Click);
            // 
            // externalFolderDirectory3
            // 
            this.externalFolderDirectory3.Location = new System.Drawing.Point(157, 362);
            this.externalFolderDirectory3.Name = "externalFolderDirectory3";
            this.externalFolderDirectory3.ReadOnly = true;
            this.externalFolderDirectory3.Size = new System.Drawing.Size(627, 22);
            this.externalFolderDirectory3.TabIndex = 10;
            this.externalFolderDirectory3.WordWrap = false;
            // 
            // progressBarExternalFolder2
            // 
            this.progressBarExternalFolder2.Location = new System.Drawing.Point(13, 323);
            this.progressBarExternalFolder2.Name = "progressBarExternalFolder2";
            this.progressBarExternalFolder2.Size = new System.Drawing.Size(770, 23);
            this.progressBarExternalFolder2.TabIndex = 12;
            // 
            // progressBarExternalFolder1
            // 
            this.progressBarExternalFolder1.Location = new System.Drawing.Point(13, 257);
            this.progressBarExternalFolder1.Name = "progressBarExternalFolder1";
            this.progressBarExternalFolder1.Size = new System.Drawing.Size(770, 23);
            this.progressBarExternalFolder1.TabIndex = 13;
            // 
            // progressBarExternalFolder3
            // 
            this.progressBarExternalFolder3.Location = new System.Drawing.Point(13, 390);
            this.progressBarExternalFolder3.Name = "progressBarExternalFolder3";
            this.progressBarExternalFolder3.Size = new System.Drawing.Size(770, 23);
            this.progressBarExternalFolder3.TabIndex = 14;
            // 
            // richTextBoxMessages
            // 
            this.richTextBoxMessages.Location = new System.Drawing.Point(12, 72);
            this.richTextBoxMessages.Name = "richTextBoxMessages";
            this.richTextBoxMessages.ReadOnly = true;
            this.richTextBoxMessages.Size = new System.Drawing.Size(771, 150);
            this.richTextBoxMessages.TabIndex = 16;
            this.richTextBoxMessages.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 465);
            this.Controls.Add(this.richTextBoxMessages);
            this.Controls.Add(this.progressBarExternalFolder3);
            this.Controls.Add(this.progressBarExternalFolder1);
            this.Controls.Add(this.progressBarExternalFolder2);
            this.Controls.Add(this.buttonExternalFolder3);
            this.Controls.Add(this.externalFolderDirectory3);
            this.Controls.Add(this.buttonExternalFolder2);
            this.Controls.Add(this.externalFolderDirectory2);
            this.Controls.Add(this.buttonSyncFiles);
            this.Controls.Add(this.infoLable);
            this.Controls.Add(this.buttonExternalFolder1);
            this.Controls.Add(this.buttonPcFolder);
            this.Controls.Add(this.externalFolderDirectory1);
            this.Controls.Add(this.pcFolderDirectory);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Sync Files";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pcFolderDirectory;
        private System.Windows.Forms.TextBox externalFolderDirectory1;
        private System.Windows.Forms.Button buttonPcFolder;
        private System.Windows.Forms.Button buttonExternalFolder1;
        private System.Windows.Forms.Label infoLable;
        private System.Windows.Forms.Button buttonSyncFiles;
        private System.Windows.Forms.Button buttonExternalFolder2;
        private System.Windows.Forms.TextBox externalFolderDirectory2;
        private System.Windows.Forms.Button buttonExternalFolder3;
        private System.Windows.Forms.TextBox externalFolderDirectory3;
        private System.Windows.Forms.ProgressBar progressBarExternalFolder2;
        private System.Windows.Forms.ProgressBar progressBarExternalFolder1;
        private System.Windows.Forms.ProgressBar progressBarExternalFolder3;
        private System.Windows.Forms.RichTextBox richTextBoxMessages;
    }
}

