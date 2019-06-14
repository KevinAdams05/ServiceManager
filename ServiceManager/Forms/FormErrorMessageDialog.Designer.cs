namespace ServiceManager
{
    partial class ErrorMessageDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorMessageDialog));
            this.labelErrorTitle = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonCopyText = new System.Windows.Forms.Button();
            this.labelErrorDetails = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textDetailErrorText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelErrorTitle
            // 
            this.labelErrorTitle.AutoSize = true;
            this.labelErrorTitle.Location = new System.Drawing.Point(77, 9);
            this.labelErrorTitle.Name = "labelErrorTitle";
            this.labelErrorTitle.Size = new System.Drawing.Size(71, 13);
            this.labelErrorTitle.TabIndex = 1;
            this.labelErrorTitle.Text = "labelErrorTitle";
            this.labelErrorTitle.Click += new System.EventHandler(this.labelErrorTitle_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(256, 170);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Ok";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonCopyText
            // 
            this.buttonCopyText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopyText.Location = new System.Drawing.Point(15, 170);
            this.buttonCopyText.Name = "buttonCopyText";
            this.buttonCopyText.Size = new System.Drawing.Size(75, 23);
            this.buttonCopyText.TabIndex = 4;
            this.buttonCopyText.Text = "Copy Text";
            this.buttonCopyText.UseVisualStyleBackColor = true;
            this.buttonCopyText.Click += new System.EventHandler(this.buttonCopyText_Click);
            // 
            // labelErrorDetails
            // 
            this.labelErrorDetails.AutoSize = true;
            this.labelErrorDetails.Location = new System.Drawing.Point(12, 34);
            this.labelErrorDetails.Name = "labelErrorDetails";
            this.labelErrorDetails.Size = new System.Drawing.Size(42, 13);
            this.labelErrorDetails.TabIndex = 6;
            this.labelErrorDetails.Text = "Details:";
            this.labelErrorDetails.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Error:";
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 203);
            this.Controls.Add(this.textDetailErrorText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelErrorDetails);
            this.Controls.Add(this.buttonCopyText);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelErrorTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ErrorMessageDialog";
            this.Text = "Error";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelErrorTitle;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonCopyText;
        private System.Windows.Forms.Label labelErrorDetails;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textDetailErrorText;
    }
}