using System.Drawing;

namespace WindowsFormsAppProject_SyncFiles.HelperClasses
{
    public class HasErrorModel
    {
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
        public Color TextColor { get; set; }

        public HasErrorModel()
        {
            HasError = false;
            ErrorMessage = null;
            TextColor = Color.Black;
        }

        public HasErrorModel(bool hasError, string errorMessage, Color textColor)
        {
            HasError = hasError;
            ErrorMessage = errorMessage;
            TextColor = textColor;
        }
    }
}
