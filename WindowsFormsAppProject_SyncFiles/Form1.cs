using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppProject_SyncFiles
{
    public partial class Form1 : Form
    {
        SyncFilesFromPcToExternalDrive _main = new SyncFilesFromPcToExternalDrive();

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
            flipButtons(false);
            string msg = _main.ErrorCheck(pcFolderDirectory.Text, externalFolderDirectory.Text);

            if (!string.IsNullOrEmpty(msg))
            {
                labelError.Text = msg;
                flipButtons(true);
            }
            else
            {
                Task.Run(() =>
                {
                    _main.SyncFiles();
                    flipButtons(true);
                });
            }
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

        private void flipButtons(bool flip)
        {
            buttonExternalFolder.Enabled = flip;
            buttonPcFolder.Enabled = flip;
            buttonSyncFiles.Enabled = flip;
        }
    }
}
