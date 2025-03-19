using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WindowsFormsAppProject_SyncFiles.HelperClasses;
using WindowsFormsAppProject_SyncFiles.Interfaces;

namespace WindowsFormsAppProject_SyncFiles
{
    public class ErrorCheck : IErrorCheck
    {
        public ErrorCheck()
        {

        }

        void IErrorCheck.selectDirectory(IAppendColoredText iact, RichTextBox rtb, TextBox tb)
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
                    iact.AppendColoredText(rtb, "Error: Please select a folder." + Environment.NewLine, Color.Red);
                    tb.Text = "";
                }
            }
        }

        Triple<bool, string, Color> IErrorCheck.CheckPaths(string pcFolder, List<TextBox> textBoxes)
        {
            if (string.IsNullOrEmpty(pcFolder))
            {
                return new Triple<bool, string, Color>(false, "Error: The PC path cannot be empty. Please Try again." + Environment.NewLine, Color.Red);
            }

            foreach (var tb in textBoxes)
            {
                if (tb.Text == pcFolder)
                {
                    return new Triple<bool, string, Color>(false, "Error: The PC path and External Path cannot be the same. Please Try again." + Environment.NewLine, Color.Red);
                }

                string error = StartCheck(pcFolder, tb.Text) + Environment.NewLine;

                if (!string.IsNullOrEmpty(error))
                {
                    return new Triple<bool, string, Color>(false, error, Color.Red);
                }
            }
            
            return new Triple<bool, string, Color>(true, "", Color.Black);
        }

        private string StartCheck(string PathToFilesOnPc, string PathToFilesOnExternal)
        {
            if (!Directory.Exists(PathToFilesOnPc))
            {
                return $"Error: Sorry the path on your PC: {PathToFilesOnPc} does not exist. Please try again.";
            }

            if (!Directory.Exists(PathToFilesOnExternal))
            {
                return $"Error: Sorry the path on your External Drive: {PathToFilesOnExternal} does not exist. Please try again.";
            }

            string pathA = Path.GetFileName(PathToFilesOnPc);
            string pathB = Path.GetFileName(PathToFilesOnExternal);

            if (Path.GetFileName(pathA) != Path.GetFileName(pathB))
            {
                return $"Error: Sorry the end of path: {PathToFilesOnPc} does not match the end of path {PathToFilesOnExternal}. Please try again.";
            }

            return null;
        }
    }
}
