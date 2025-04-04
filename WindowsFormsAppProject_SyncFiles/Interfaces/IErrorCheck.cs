using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsAppProject_SyncFiles.HelperClasses;

namespace WindowsFormsAppProject_SyncFiles.Interfaces
{
    interface IErrorCheck
    {
        void selectDirectory(IAppendColoredText iact, RichTextBox rtb, TextBox tb);

        HasErrorModel CheckPaths(string pcFolder, Dictionary<string, string> textBoxes);
    }
}
