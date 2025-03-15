
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
            this.externalFolderDirectory = new System.Windows.Forms.TextBox();
            this.buttonPcFolder = new System.Windows.Forms.Button();
            this.buttonExternalFolder = new System.Windows.Forms.Button();
            this.infoLable = new System.Windows.Forms.Label();
            this.buttonSyncFiles = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pcFolderDirectory
            // 
            this.pcFolderDirectory.Location = new System.Drawing.Point(156, 90);
            this.pcFolderDirectory.Name = "pcFolderDirectory";
            this.pcFolderDirectory.ReadOnly = true;
            this.pcFolderDirectory.Size = new System.Drawing.Size(469, 22);
            this.pcFolderDirectory.TabIndex = 0;
            this.pcFolderDirectory.WordWrap = false;
            // 
            // externalFolderDirectory
            // 
            this.externalFolderDirectory.Location = new System.Drawing.Point(156, 137);
            this.externalFolderDirectory.Name = "externalFolderDirectory";
            this.externalFolderDirectory.ReadOnly = true;
            this.externalFolderDirectory.Size = new System.Drawing.Size(469, 22);
            this.externalFolderDirectory.TabIndex = 1;
            this.externalFolderDirectory.WordWrap = false;
            // 
            // buttonPcFolder
            // 
            this.buttonPcFolder.Location = new System.Drawing.Point(18, 89);
            this.buttonPcFolder.Name = "buttonPcFolder";
            this.buttonPcFolder.Size = new System.Drawing.Size(112, 23);
            this.buttonPcFolder.TabIndex = 2;
            this.buttonPcFolder.Text = "PC Folder";
            this.buttonPcFolder.UseVisualStyleBackColor = true;
            this.buttonPcFolder.Click += new System.EventHandler(this.buttonPcFolder_Click);
            // 
            // buttonExternalFolder
            // 
            this.buttonExternalFolder.Location = new System.Drawing.Point(18, 136);
            this.buttonExternalFolder.Name = "buttonExternalFolder";
            this.buttonExternalFolder.Size = new System.Drawing.Size(112, 23);
            this.buttonExternalFolder.TabIndex = 3;
            this.buttonExternalFolder.Text = "External Folder";
            this.buttonExternalFolder.UseVisualStyleBackColor = true;
            this.buttonExternalFolder.Click += new System.EventHandler(this.buttonExternalFolder_Click);
            // 
            // infoLable
            // 
            this.infoLable.Location = new System.Drawing.Point(18, 18);
            this.infoLable.Name = "infoLable";
            this.infoLable.Size = new System.Drawing.Size(607, 23);
            this.infoLable.TabIndex = 4;
            this.infoLable.Text = "Please select the folder on your computer with files you want to sync to the exte" +
    "rnal drive folder";
            this.infoLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonSyncFiles
            // 
            this.buttonSyncFiles.Location = new System.Drawing.Point(288, 169);
            this.buttonSyncFiles.Name = "buttonSyncFiles";
            this.buttonSyncFiles.Size = new System.Drawing.Size(119, 23);
            this.buttonSyncFiles.TabIndex = 5;
            this.buttonSyncFiles.Text = "Sync Files Now";
            this.buttonSyncFiles.UseVisualStyleBackColor = true;
            this.buttonSyncFiles.Click += new System.EventHandler(this.buttonSyncFiles_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(18, 52);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 17);
            this.labelError.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 219);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.buttonSyncFiles);
            this.Controls.Add(this.infoLable);
            this.Controls.Add(this.buttonExternalFolder);
            this.Controls.Add(this.buttonPcFolder);
            this.Controls.Add(this.externalFolderDirectory);
            this.Controls.Add(this.pcFolderDirectory);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Sync Files";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pcFolderDirectory;
        private System.Windows.Forms.TextBox externalFolderDirectory;
        private System.Windows.Forms.Button buttonPcFolder;
        private System.Windows.Forms.Button buttonExternalFolder;
        private System.Windows.Forms.Label infoLable;
        private System.Windows.Forms.Button buttonSyncFiles;
        private System.Windows.Forms.Label labelError;
    }
}

