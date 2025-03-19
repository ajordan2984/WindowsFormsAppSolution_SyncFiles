using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAppProject_SyncFiles.HelperClasses;
using WindowsFormsAppProject_SyncFiles.Interfaces;

namespace WindowsFormsAppProject_SyncFiles
{
    public partial class Form1 : Form
    {
        IAppendColoredText _act = new AppendColoredText();
        SyncFilesFromPcToExternalDrive _main = new SyncFilesFromPcToExternalDrive();
        IErrorCheck _ec = new ErrorCheck();


        public Form1()
        {
            InitializeComponent();
            _act.SetRichTextBox(richTextBoxMessages);
            _main.SetAppendColorText(_act);
        }

        private void buttonPcFolder_Click(object sender, EventArgs e)
        {
            _ec.selectDirectory(_act, richTextBoxMessages, pcFolderDirectory);
        }

        private void buttonExternalFolder1_Click(object sender, EventArgs e)
        {
            _ec.selectDirectory(_act, richTextBoxMessages, externalFolderDirectory1);
        }

        private void buttonExternalFolder2_Click(object sender, EventArgs e)
        {
            _ec.selectDirectory(_act, richTextBoxMessages, externalFolderDirectory2);
        }

        private void buttonExternalFolder3_Click(object sender, EventArgs e)
        {
            _ec.selectDirectory(_act, richTextBoxMessages, externalFolderDirectory3);
        }

        private void buttonClearTextbox_Click(object sender, EventArgs e)
        {
            richTextBoxMessages.Clear();
        }

        private async void buttonSyncFiles_Click(object sender, EventArgs e)
        {
            flipButtons(false);

            List<TextBox> viewTextBoxes = new List<TextBox>
            {
                externalFolderDirectory1,
                externalFolderDirectory2,
                externalFolderDirectory3
            };

            Triple<bool, string, Color> errorFree = _ec.CheckPaths(pcFolderDirectory.Text, viewTextBoxes);

            if (errorFree.First)
            {
                _act.AppendColoredText("Your files are now being synced.", Color.Blue);

                List<Task> tasks = new List<Task>();

                ParallelOptions options = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount };
                Parallel.ForEach(viewTextBoxes, options, vtb =>
                {
                    // Capture variables to prevent potential scope issues
                    string pcFolder = pcFolderDirectory.Text;
                    string externalFolder = vtb.Text;

                    if (!string.IsNullOrEmpty(externalFolder))
                    {
                        _main.SetPaths(pcFolder, externalFolder);
                        _main.SyncFiles();
                    }
                });

                flipButtons(true);
            }
            else
            {
                _act.AppendColoredText(errorFree.Second, errorFree.Third);
                flipButtons(true);
            }
        }

        void flipButtons(bool flip)
        {
            buttonExternalFolder1.Enabled = flip;
            buttonExternalFolder2.Enabled = flip;
            buttonExternalFolder3.Enabled = flip;
            buttonPcFolder.Enabled = flip;
            buttonSyncFiles.Enabled = flip;
        }
    }
}
