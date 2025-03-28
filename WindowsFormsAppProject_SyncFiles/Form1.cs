﻿using System;
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
        IErrorCheck _ec = new ErrorCheck();

        public Form1()
        {
            InitializeComponent();
            _act.SetRichTextBox(richTextBoxMessages);
        }

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
            flipButtons(false);

            List<TextBox> viewTextBoxes = new List<TextBox>
            {
                externalFolder1,
                externalFolder2,
                externalFolder3,
                externalFolder4
            };

            Triple<bool, string, Color> errorFree = _ec.CheckPaths(pcFolder.Text.Trim(), viewTextBoxes);

            if (errorFree.First)
            {
                _act.AppendColoredText("Your files are now being synced.", Color.Blue);

                var gafh = new GetAllFilesHelper(_act);
                var pcFiles = gafh.GetAllFiles(gafh.GetAllDirectories(pcFolder.Text));
                var dictionary = new ConcurrentDictionary<string, FileInfoHolder>(pcFiles);
                var tasks = new List<Task>();

                foreach (var textBox in viewTextBoxes)
                {
                    string externalFolder = textBox.Text.Trim();
                    string pcFolderFromTextBox = pcFolder.Text;

                    if (!string.IsNullOrEmpty(externalFolder))
                    {
                        tasks.Add(
                        Task.Run(() =>
                        {
                            SyncFilesFromPcToExternalDrive _main = new SyncFilesFromPcToExternalDrive();
                            _main.SetAppendColorText(_act);
                            _main.SetAllSortedFilesFromPcPath(dictionary);
                            _main.SetPaths(pcFolderFromTextBox, externalFolder);
                            _main.SyncFiles();
                        }));
                    }
                }
                
                await Task.WhenAll(tasks);
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
            buttonExternalFolder4.Enabled = flip;
            buttonPcFolder.Enabled = flip;
            buttonSyncFiles.Enabled = flip;
        }
    }
}
