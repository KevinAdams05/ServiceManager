using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceManager
{
    public partial class ErrorMessageDialog : Form
    {
        private const int WindowHeightExpanded = 242;
        private const int WindowHeightCollapsed = 120;

        public ErrorMessageDialog(string title, string detailedError = null, bool hasDetailedError = false)
        {
            InitializeComponent();

            labelErrorTitle.Text = title;
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
            Clipboard.SetText(labelErrorTitle.Text);
        }

        private void buttonCopyText_Click(object sender, EventArgs e)
        {
            string clipboardText = labelErrorTitle.Text;

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
