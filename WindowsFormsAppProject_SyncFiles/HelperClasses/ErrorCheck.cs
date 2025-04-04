using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WindowsFormsAppProject_SyncFiles.Interfaces;

namespace WindowsFormsAppProject_SyncFiles.HelperClasses
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
            }
        }

        HasErrorModel IErrorCheck.CheckPaths(string pcFolder, Dictionary<string, string> textBoxes)
        {
            if (string.IsNullOrEmpty(pcFolder))
            {
                return new HasErrorModel(true, "Error: The PC path cannot be empty. Please Try again.", Color.Red);
            }

            if (!Directory.Exists(pcFolder))
            {
                return new HasErrorModel(true, $"Error: Sorry the path on your PC: \"{pcFolder}\" does not exist. Please try again.", Color.Red);
            }

            if (textBoxes.Count == 0)
            {
                return new HasErrorModel(true, "Error: You must have one external folder selected. Please Try again.", Color.Red);
            }

            foreach (string textBoxNameKey in textBoxes.Keys)
            {
                string externalFolder = textBoxes[textBoxNameKey];

                if (externalFolder == pcFolder)
                {
                    return new HasErrorModel(true, "Error: The PC folder path and External folder path cannot be the same. Please Try again.", Color.Red);
                }

                if (!Directory.Exists(externalFolder))
                {
                    return new HasErrorModel(true, $"Error: Sorry the folder path on your External Drive: \"{externalFolder}\" does not exist. Please try again.", Color.Red);
                }

                string pathA = Path.GetFileName(pcFolder);
                string pathB = Path.GetFileName(externalFolder);

                if (pathA != pathB)
                {
                    return new HasErrorModel(true, $"Error: Sorry the end of path: \"{pcFolder}\" does not match the end of path \"{externalFolder}\". Please try again.", Color.Red);
                }
            }

            return new HasErrorModel(false, "", Color.Black);
        }
    }
}
