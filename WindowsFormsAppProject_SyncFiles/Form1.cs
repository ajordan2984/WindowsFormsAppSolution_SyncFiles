using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppProject_SyncFiles
{
    public partial class Form1 : Form
    {
        SyncFilesFromPcToExternalDrive _main = new SyncFilesFromPcToExternalDrive();
        ErrorCheck _ec = new ErrorCheck();

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

            List<TextBox> tb = new List<TextBox>
            {
                externalFolderDirectory1,
                externalFolderDirectory2,
                externalFolderDirectory3
            };

            if (CheckPaths(pcFolderDirectory.Text, tb))
            {
                AppendColoredText("Your files are now being synced." + Environment.NewLine, Color.Blue);

                Task.Run(() =>
                {
                    _main.SyncFiles();

                    Invoke(new Action(() =>
                    {
                        flipButtons(true);
                        AppendColoredText("Your files are now synced." + Environment.NewLine, Color.Blue);
                    }));
                });
            }
            else
            {
                flipButtons(true);
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
                    AppendColoredText("Error: Please select a folder." + Environment.NewLine, Color.Red);
                    tb.Text = "";
                }
            }
        }

        private void AppendColoredText(string text, Color color)
        {
            richTextBoxMessages.SelectionStart = richTextBoxMessages.TextLength; // Move cursor to end
            richTextBoxMessages.SelectionLength = 0; // Ensure no text is selected
            richTextBoxMessages.SelectionColor = color; // Set color
            richTextBoxMessages.AppendText(text); // Append the text
            richTextBoxMessages.SelectionColor = richTextBoxMessages.ForeColor; // Reset color to default
        }

        private void flipButtons(bool flip)
        {
            buttonExternalFolder1.Enabled = flip;
            buttonExternalFolder2.Enabled = flip;
            buttonExternalFolder3.Enabled = flip;
            buttonPcFolder.Enabled = flip;
            buttonSyncFiles.Enabled = flip;
        }

        private bool CheckPaths(string pcFolder, List<TextBox> textBoxes)
        {
            if (string.IsNullOrEmpty(pcFolder))
            {
                AppendColoredText("Error: The PC path cannot be empty. Please Try again." + Environment.NewLine, Color.Red);
                return false;
            }
            
            foreach (var tb in textBoxes)
            {
                if (tb.Text == pcFolder)
                {
                    AppendColoredText("Error: The PC path and External Path cannot be the same. Please Try again." + Environment.NewLine, Color.Red);
                    return false;
                }

                string error = _ec.StartCheck(pcFolder, tb.Text) + Environment.NewLine;

                if (!string.IsNullOrEmpty(error))
                {
                    AppendColoredText(error, Color.Red);
                    return false;
                }
            }
            return true;
        }
    }
}
