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
        TrackTextBoxUpdatesHelper _ttbuh;

        public Form1()
        {
            InitializeComponent();
            _act.SetRichTextBox(richTextBoxMessages);
            _ttbuh = new TrackTextBoxUpdatesHelper();
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

            _ttbuh.AddSelectedExternalFolder(externalFolder1.Name, externalFolder1.Text);
            _ttbuh.AddSelectedExternalFolder(externalFolder2.Name, externalFolder2.Text);
            _ttbuh.AddSelectedExternalFolder(externalFolder3.Name, externalFolder3.Text);
            _ttbuh.AddSelectedExternalFolder(externalFolder4.Name, externalFolder4.Text);

            HasErrorHelper heh = _ec.CheckPaths(pcFolderFromTextBox, _ttbuh.ExternalFoldersSelected);

            try
            {
                if (heh.HasError)
                {
                    _act.AppendColoredText(heh.ErrorMessage, Color.Red);
                }
                else
                {
                    FlipTextBoxesUI(false);
                    FlipButtonsUI(false);

                    _act.AppendColoredText("Now starting on syncing your files to the external folder(s) selected.", Color.Blue);

                    GetAllFilesHelper gafh = new GetAllFilesHelper(_act);
                    List<string> allSelectedPcFolders = gafh.GetAllDirectories(pcFolderFromTextBox);
                    SortedDictionary<string, FileInfoHolder> allSelectedPcFiles = gafh.GetAllFiles(allSelectedPcFolders);
                    ConcurrentDictionary<string, FileInfoHolder> allSeclectedPcFilesForTasks = new ConcurrentDictionary<string, FileInfoHolder>(allSelectedPcFiles);
                    var tasks = new List<Task>();

                    foreach (var textBoxNameKey in _ttbuh.ExternalFoldersSelected.Keys)
                    {
                        string externalFolder = _ttbuh.ExternalFoldersSelected[textBoxNameKey];
                        string pcFolder = pcFolderFromTextBox;

                        tasks.Add(
                        Task.Run(() =>
                        {
                            SyncFilesFromPcToExternalDrive _main = new SyncFilesFromPcToExternalDrive();
                            _main.SetAppendColorText(_act);
                            _main.SetAllSortedFilesFromPcPath(allSeclectedPcFilesForTasks);
                            _main.SetPaths(pcFolder, externalFolder);
                            _main.SyncFiles();
                            _act.AppendColoredText($"Completed syncing your files to \"{externalFolder}\".", Color.Blue);
                        }));
                    }

                    await Task.WhenAll(tasks);

                    FlipTextBoxesUI(true);
                    FlipButtonsUI(true);
                }
            }
            catch (Exception ex)
            {
                _act.AppendColoredText(ex.Message, Color.Red);
                FlipTextBoxesUI(true);
                FlipButtonsUI(true);
            }
        }

        #endregion

        void FlipTextBoxesUI(bool isEnabled)
        {
            pcFolder.Enabled = isEnabled;
            externalFolder1.Enabled = isEnabled;
            externalFolder2.Enabled = isEnabled;
            externalFolder3.Enabled = isEnabled;
            externalFolder4.Enabled = isEnabled;
        }

        void FlipButtonsUI(bool isEnabled)
        {
            buttonExternalFolder1.Enabled = isEnabled;
            buttonExternalFolder2.Enabled = isEnabled;
            buttonExternalFolder3.Enabled = isEnabled;
            buttonExternalFolder4.Enabled = isEnabled;
            buttonPcFolder.Enabled = isEnabled;
            buttonSyncFiles.Enabled = isEnabled;
        }
    }
}
