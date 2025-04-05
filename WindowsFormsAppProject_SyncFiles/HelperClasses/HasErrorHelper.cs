using System.Drawing;

namespace WindowsFormsAppProject_SyncFiles.HelperClasses
{
    public class HasErrorHelper
    {
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
        public Color TextColor { get; set; }

        public HasErrorHelper()
        {
            HasError = false;
            ErrorMessage = null;
            TextColor = Color.Black;
        }

        public HasErrorHelper(bool hasError, string errorMessage, Color textColor)
        {
            HasError = hasError;
            ErrorMessage = errorMessage;
            TextColor = textColor;
        }
    }
}
