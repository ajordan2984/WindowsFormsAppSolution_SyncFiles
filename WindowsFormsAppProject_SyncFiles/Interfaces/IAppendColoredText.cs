using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsAppProject_SyncFiles.Interfaces
{
    public interface IAppendColoredText
    {
        void AppendColoredText(RichTextBox rtb, string message, Color color);
    }
}
