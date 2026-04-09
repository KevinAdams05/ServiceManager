namespace ServiceManager
{
    partial class ErrorMessageDialog
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorMessageDialog));
            this.labelErrorTitle = new Krypton.Toolkit.KryptonLabel();
            this.buttonClose = new Krypton.Toolkit.KryptonButton();
            this.buttonCopyText = new Krypton.Toolkit.KryptonButton();
            this.labelErrorDetails = new Krypton.Toolkit.KryptonLabel();
            this.label2 = new Krypton.Toolkit.KryptonLabel();
            this.textDetailErrorText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            //
            // labelErrorTitle
            //
            this.labelErrorTitle.Location = new System.Drawing.Point(77, 9);
            this.labelErrorTitle.Name = "labelErrorTitle";
            this.labelErrorTitle.TabIndex = 1;
            this.labelErrorTitle.Values.Text = "labelErrorTitle";
            this.labelErrorTitle.Click += new System.EventHandler(this.labelErrorTitle_Click);

            //
            // buttonClose
            //
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(256, 170);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 25);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Values.Text = "Ok";
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);

            //
            // buttonCopyText
            //
            this.buttonCopyText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopyText.Location = new System.Drawing.Point(15, 170);
            this.buttonCopyText.Name = "buttonCopyText";
            this.buttonCopyText.Size = new System.Drawing.Size(75, 25);
            this.buttonCopyText.TabIndex = 4;
            this.buttonCopyText.Values.Text = "Copy Text";
            this.buttonCopyText.Click += new System.EventHandler(this.buttonCopyText_Click);

            //
            // labelErrorDetails
            //
            this.labelErrorDetails.Location = new System.Drawing.Point(12, 34);
            this.labelErrorDetails.Name = "labelErrorDetails";
            this.labelErrorDetails.TabIndex = 6;
            this.labelErrorDetails.Values.Text = "Details:";
            this.labelErrorDetails.Visible = false;

            //
            // label2
            //
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.TabIndex = 7;
            this.label2.Values.Text = "Error:";

            //
            // textDetailErrorText
            //
            this.textDetailErrorText.Location = new System.Drawing.Point(80, 34);
            this.textDetailErrorText.Multiline = true;
            this.textDetailErrorText.Name = "textDetailErrorText";
            this.textDetailErrorText.ReadOnly = true;
            this.textDetailErrorText.Size = new System.Drawing.Size(245, 130);
            this.textDetailErrorText.TabIndex = 8;
            this.textDetailErrorText.Visible = false;

            //
            // ErrorMessageDialog
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 203);
            this.Controls.Add(this.textDetailErrorText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelErrorDetails);
            this.Controls.Add(this.buttonCopyText);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelErrorTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ErrorMessageDialog";
            this.Text = "Error";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Krypton.Toolkit.KryptonLabel labelErrorTitle;
        private Krypton.Toolkit.KryptonButton buttonClose;
        private Krypton.Toolkit.KryptonButton buttonCopyText;
        private Krypton.Toolkit.KryptonLabel labelErrorDetails;
        private Krypton.Toolkit.KryptonLabel label2;
        private System.Windows.Forms.TextBox textDetailErrorText;
    }
}
