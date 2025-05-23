﻿using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsAppProject_SyncFiles.Interfaces;

namespace WindowsFormsAppProject_SyncFiles.HelperClasses
{
    public class AppendColoredText : IAppendColoredText
    {
        private RichTextBox _richTextBoxMessages;

        void IAppendColoredText.SetRichTextBox(RichTextBox richTextBoxMessages)
        {
            _richTextBoxMessages = richTextBoxMessages;
        }

        void IAppendColoredText.AppendColoredText(string message, Color color)
        {
            _richTextBoxMessages.BeginInvoke((Action)(() =>
                {
                    _richTextBoxMessages.SelectionStart = _richTextBoxMessages.TextLength; // Move cursor to end
                    _richTextBoxMessages.SelectionLength = 0; // Ensure no text is selected
                    _richTextBoxMessages.SelectionColor = color; // Set color
                    _richTextBoxMessages.AppendText(DateTime.Now.ToString() + " | " + message + Environment.NewLine + Environment.NewLine); // Append the text
                    _richTextBoxMessages.SelectionColor = _richTextBoxMessages.ForeColor; // Reset color to default
                }));
        }
    }
}
