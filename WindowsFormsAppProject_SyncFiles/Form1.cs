using System;
using System.Drawing;
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
            selectDirectory(pcFolderDirectory);
        }

        private void buttonExternalFolder1_Click(object sender, EventArgs e)
        {
            selectDirectory(externalFolderDirectory1);
        }

        private void buttonExternalFolder2_Click(object sender, EventArgs e)
        {
            selectDirectory(externalFolderDirectory2);
        }

        private void buttonExternalFolder3_Click(object sender, EventArgs e)
        {
            selectDirectory(externalFolderDirectory1);
        }

        private void buttonSyncFiles_Click(object sender, EventArgs e)
        {
            flipButtons(false);
            string msg = _main.ErrorCheck(pcFolderDirectory.Text, externalFolderDirectory1.Text) + Environment.NewLine;

            if (!string.IsNullOrEmpty(msg))
            {
                richTextBoxMessages.ForeColor = Color.Red;
                richTextBoxMessages.Text = msg;
                flipButtons(true);
            }
            else
            {
                richTextBoxMessages.ForeColor = Color.Blue;
                richTextBoxMessages.Text = "Your files are now being synced." + Environment.NewLine;

                Task.Run(() =>
                {
                    _main.SyncFiles();

                    Invoke(new Action(() =>
                    {
                        flipButtons(true);
                        richTextBoxMessages.ForeColor = Color.Blue;
                        richTextBoxMessages.Text = "Your files are now synced." + Environment.NewLine;
                    }));
                });
            }
        }

        private void selectDirectory(TextBox tb)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath) && Directory.Exists(fbd.SelectedPath))
                {
                    tb.Text = fbd.SelectedPath;
                }
                else
                {
                    richTextBoxMessages.ForeColor = Color.Red;
                    richTextBoxMessages.Text = "Error: Please select a folder." + Environment.NewLine;
                    tb.Text = "";
                }
            }
        }

        private void flipButtons(bool flip)
        {
            buttonExternalFolder1.Enabled = flip;
            buttonPcFolder.Enabled = flip;
            buttonSyncFiles.Enabled = flip;
        }
    }
}
