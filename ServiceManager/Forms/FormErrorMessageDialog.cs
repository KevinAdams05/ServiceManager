using System;
using System.Drawing;
using System.Windows.Forms;
using Krypton.Toolkit;

namespace ServiceManager
{
    public partial class ErrorMessageDialog : KryptonForm
    {
        private const int WindowHeightExpanded = 242;
        private const int WindowHeightCollapsed = 120;

        public ErrorMessageDialog(string title, string detailedError = null, bool hasDetailedError = false)
        {
            InitializeComponent();

            Icon appIcon = Utility.GetApplicationIcon();

            if (appIcon != null)
            {
                this.Icon = appIcon;
            }

            labelErrorTitle.Values.Text = title;
            textDetailErrorText.Text = detailedError;

            if (hasDetailedError)
            {
                Height = WindowHeightExpanded;
                textDetailErrorText.Visible = true;
                labelErrorDetails.Visible = true;
            }
            else
            {
                textDetailErrorText.Visible = false;
                labelErrorDetails.Visible = false;
                Height = WindowHeightCollapsed;
            }
        }

        private void labelErrorTitle_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(labelErrorTitle.Values.Text);
        }

        private void buttonCopyText_Click(object sender, EventArgs e)
        {
            string clipboardText = labelErrorTitle.Values.Text;

            if (!string.IsNullOrEmpty(textDetailErrorText.Text))
            {
                clipboardText = clipboardText + Environment.NewLine + textDetailErrorText.Text;
            }

            Clipboard.SetText(clipboardText);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
