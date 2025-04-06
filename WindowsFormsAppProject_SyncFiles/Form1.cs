using System;
using System.Collections.Concurrent;
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
        IAppendColoredText _act = new AppendColoredText();
        IErrorCheck _ec = new ErrorCheckHelper();
        private Dictionary<string, string> _ExternalFoldersSelected = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();
            _act.SetRichTextBox(richTextBoxMessages);
        }

        #region Button Clicks

        private void buttonPcFolder_Click(object sender, EventArgs e)
        {
            _ec.selectDirectory(_act, richTextBoxMessages, pcFolder);
        }

        private void buttonExternalFolder1_Click(object sender, EventArgs e)
        {
            _ec.selectDirectory(_act, richTextBoxMessages, externalFolder1);
        }

        private void buttonExternalFolder2_Click(object sender, EventArgs e)
        {
            _ec.selectDirectory(_act, richTextBoxMessages, externalFolder2);
        }

        private void buttonExternalFolder3_Click(object sender, EventArgs e)
        {
            _ec.selectDirectory(_act, richTextBoxMessages, externalFolder3);
        }

        private void buttonExternalFolder4_Click(object sender, EventArgs e)
        {
            _ec.selectDirectory(_act, richTextBoxMessages, externalFolder4);
        }

        private void buttonClearTextbox_Click(object sender, EventArgs e)
        {
            richTextBoxMessages.Clear();
        }

        private async void buttonSyncFiles_Click(object sender, EventArgs e)
        {
            string pcFolderFromTextBox = pcFolder.Text.Trim();
            AddSelectedExternalFolder(externalFolder1.Name, externalFolder1.Text);
            AddSelectedExternalFolder(externalFolder2.Name, externalFolder2.Text);
            AddSelectedExternalFolder(externalFolder3.Name, externalFolder3.Text);
            AddSelectedExternalFolder(externalFolder4.Name, externalFolder4.Text);

            HasErrorHelper heh = _ec.CheckPaths(pcFolderFromTextBox, _ExternalFoldersSelected);

            if (!heh.HasError)
            {
                FlipButtons(false);
                _act.AppendColoredText("Your files are now being synced.", Color.Blue);

                var gafh = new GetAllFilesHelper(_act);
                var pcFiles = gafh.GetAllFiles(gafh.GetAllDirectories(pcFolder.Text.Trim()));
                var dictionary = new ConcurrentDictionary<string, FileInfoHolder>(pcFiles);
                var tasks = new List<Task>();

                foreach (var textBoxNameKey in _ExternalFoldersSelected.Keys)
                {
                    string externalFolder = _ExternalFoldersSelected[textBoxNameKey];
                    string pcFolder = pcFolderFromTextBox;

                    tasks.Add(
                    Task.Run(() =>
                    {
                        SyncFilesFromPcToExternalDrive _main = new SyncFilesFromPcToExternalDrive();
                        _main.SetAppendColorText(_act);
                        _main.SetAllSortedFilesFromPcPath(dictionary);
                        _main.SetPaths(pcFolder, externalFolder);
                        _main.SyncFiles();
                    }));
                }

                await Task.WhenAll(tasks);
                FlipButtons(true);
            }
            else
            {
                _act.AppendColoredText(heh.ErrorMessage, heh.TextColor);
                FlipButtons(true);
            }
        }

        #endregion

        void FlipButtons(bool isEnabled)
        {
            buttonExternalFolder1.Enabled = isEnabled;
            buttonExternalFolder2.Enabled = isEnabled;
            buttonExternalFolder3.Enabled = isEnabled;
            buttonExternalFolder4.Enabled = isEnabled;
            buttonPcFolder.Enabled = isEnabled;
            buttonSyncFiles.Enabled = isEnabled;
        }

        private void AddSelectedExternalFolder(string TextBoxName, string TextBoxPath)
        {
            if (string.IsNullOrEmpty(TextBoxPath))
            {
                if (_ExternalFoldersSelected.ContainsKey(TextBoxName))
                {
                    _ExternalFoldersSelected.Remove(TextBoxName);
                }
            }
            else
            {
                if (_ExternalFoldersSelected.ContainsKey(TextBoxName))
                {
                    _ExternalFoldersSelected[TextBoxName] = TextBoxPath.Trim();
                }
                else
                {
                    _ExternalFoldersSelected.Add(TextBoxName, TextBoxPath.Trim());
                }
            }
        }
    }
}
