using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsAppProject_SyncFiles.HelperClasses;

namespace WindowsFormsAppProject_SyncFiles.Interfaces
{
    interface IErrorCheck
    {
        void selectDirectory(IAppendColoredText iact, RichTextBox rtb, TextBox tb);

        Triple<bool, string, Color> CheckPaths(string pcFolder, List<TextBox> textBoxes);
    }
}
