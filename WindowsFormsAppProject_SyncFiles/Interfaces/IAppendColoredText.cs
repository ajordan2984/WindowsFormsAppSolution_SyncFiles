using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsAppProject_SyncFiles.Interfaces
{
    public interface IAppendColoredText
    {
        void SetRichTextBox(RichTextBox rtb);

        void AppendColoredText(string message, Color color);
    }
}
