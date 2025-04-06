using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsAppProject_SyncFiles.HelperClasses;

namespace WindowsFormsAppProject_SyncFiles.Interfaces
{
    interface IErrorCheck
    {
        void selectDirectory(IAppendColoredText iact, RichTextBox rtb, TextBox tb);

        HasErrorHelper CheckPaths(string pcFolder, Dictionary<string, string> textBoxes);
    }
}