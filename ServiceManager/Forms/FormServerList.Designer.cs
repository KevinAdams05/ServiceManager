using System;

namespace ServiceManager
{
    partial class FormServerList
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new Krypton.Toolkit.KryptonDataGridView();
            this.buttonSave = new Krypton.Toolkit.KryptonButton();
            this.buttonDiscard = new Krypton.Toolkit.KryptonButton();
            this.buttonAddRow = new Krypton.Toolkit.KryptonButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuItemRemoveServer = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();

            //
            // dataGridView1
            //
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(686, 399);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView1_CellMouseClick);

            //
            // buttonSave
            //
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(602, 417);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(96, 25);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Values.Text = "Save Changes";
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);

            //
            // buttonDiscard
            //
            this.buttonDiscard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDiscard.Location = new System.Drawing.Point(500, 417);
            this.buttonDiscard.Name = "buttonDiscard";
            this.buttonDiscard.Size = new System.Drawing.Size(96, 25);
            this.buttonDiscard.TabIndex = 2;
            this.buttonDiscard.Values.Text = "Discard Changes";
            this.buttonDiscard.Click += new System.EventHandler(this.ButtonDiscard_Click);

            //
            // buttonAddRow
            //
            this.buttonAddRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddRow.Location = new System.Drawing.Point(12, 417);
            this.buttonAddRow.Name = "buttonAddRow";
            this.buttonAddRow.Size = new System.Drawing.Size(96, 25);
            this.buttonAddRow.TabIndex = 3;
            this.buttonAddRow.Values.Text = "Add Server";
            this.buttonAddRow.Click += new System.EventHandler(this.ButtonAddRow_Click);

            //
            // contextMenuStrip1
            //
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.contextMenuItemRemoveServer});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 26);

            //
            // contextMenuItemRemoveServer
            //
            this.contextMenuItemRemoveServer.Name = "contextMenuItemRemoveServer";
            this.contextMenuItemRemoveServer.Size = new System.Drawing.Size(152, 22);
            this.contextMenuItemRemoveServer.Text = "Remove Server";
            this.contextMenuItemRemoveServer.Click += new System.EventHandler(this.ContextMenuItemRemoveServer_Click);

            //
            // FormServerList
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 450);
            this.Controls.Add(this.buttonAddRow);
            this.Controls.Add(this.buttonDiscard);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormServerList";
            this.Text = "Edit Server List";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Krypton.Toolkit.KryptonDataGridView dataGridView1;
        private Krypton.Toolkit.KryptonButton buttonSave;
        private Krypton.Toolkit.KryptonButton buttonDiscard;
        private Krypton.Toolkit.KryptonButton buttonAddRow;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemRemoveServer;
    }
}
