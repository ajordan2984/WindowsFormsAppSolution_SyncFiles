using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsAppProject_SyncFiles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonPcFolder_Click(object sender, EventArgs e)
        {
            string directory = selectDirectory();

            if (!string.IsNullOrEmpty(directory))
            {
                pcFolderDirectory.Text = directory;
            }
        }

        private void buttonExternalFolder_Click(object sender, EventArgs e)
        {
            string directory = selectDirectory();

            if (!string.IsNullOrEmpty(directory))
            {
                externalFolderDirectory.Text = directory;
            }
        }

        private void buttonSyncFiles_Click(object sender, EventArgs e)
        {

        }

        private string selectDirectory()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath) && Directory.Exists(fbd.SelectedPath))
                {
                    return fbd.SelectedPath;
                }
                else
                {
                    labelError.Text = "Error: Please select a folder.";
                    return null;
                }
            }
        }
    }
}
