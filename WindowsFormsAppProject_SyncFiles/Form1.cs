using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAppProject_SyncFiles.HelperClasses;
using WindowsFormsAppProject_SyncFiles.Interfaces;

namespace WindowsFormsAppProject_SyncFiles
{
    public partial class Form1 : Form
    {
        SyncFilesFromPcToExternalDrive _main = new SyncFilesFromPcToExternalDrive();
        IErrorCheck _ec = new ErrorCheck();
        IAppendColoredText _act = new AppendColoredText();
        

        public Form1()
        {
            InitializeComponent();
            _act.SetRichTextBox(richTextBoxMessages);
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

        private void buttonSyncFiles_Click(object sender, EventArgs e)
        {
            flipButtons(false);

            List<TextBox> tb = new List<TextBox>
            {
                externalFolderDirectory1,
                externalFolderDirectory2,
                externalFolderDirectory3
            };

            Triple<bool, string, Color> errorFree = _ec.CheckPaths(pcFolderDirectory.Text, tb);

            if (errorFree.First)
            {
                _act.AppendColoredText("Your files are now being synced." + Environment.NewLine, Color.Blue);

                Task.Run(() =>
                {
                    _main.SyncFiles();

                    Invoke(new Action(() =>
                    {
                        flipButtons(true);
                        _act.AppendColoredText("Your files are now synced." + Environment.NewLine, Color.Blue);
                    }));
                });
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
