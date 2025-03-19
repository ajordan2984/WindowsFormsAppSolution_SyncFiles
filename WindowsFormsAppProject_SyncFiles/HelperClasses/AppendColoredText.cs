
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsAppProject_SyncFiles.Interfaces;

namespace WindowsFormsAppProject_SyncFiles.HelperClasses
{
    public class AppendColoredText : IAppendColoredText
    {
        void IAppendColoredText.AppendColoredText(RichTextBox richTextBoxMessages, string message, Color color)
        {
            richTextBoxMessages.SelectionStart = richTextBoxMessages.TextLength; // Move cursor to end
            richTextBoxMessages.SelectionLength = 0; // Ensure no text is selected
            richTextBoxMessages.SelectionColor = color; // Set color
            richTextBoxMessages.AppendText(message); // Append the text
            richTextBoxMessages.SelectionColor = richTextBoxMessages.ForeColor; // Reset color to default
        }
    }
}
