using System;

namespace ServiceManager
{
    public partial class FormMainWindow
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
            components = new System.ComponentModel.Container();
            kryptonManager = new Krypton.Toolkit.KryptonManager(components);
            kryptonDockingManager = new Krypton.Docking.KryptonDockingManager();
            panelMain = new Krypton.Toolkit.KryptonPanel();
            kryptonDockableWorkspace = new Krypton.Docking.KryptonDockableWorkspace();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            contextMenuItemSetDefaultSortOrder = new System.Windows.Forms.ToolStripMenuItem();
            autoRefreshTimer = new System.Windows.Forms.Timer(components);
            toolStrip = new System.Windows.Forms.ToolStrip();
            statusStrip = new System.Windows.Forms.StatusStrip();
            statusLabelRefresh = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)panelMain).BeginInit();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)kryptonDockableWorkspace).BeginInit();
            contextMenuStrip1.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            //
            // kryptonManager
            //
            kryptonManager.GlobalPaletteMode = Krypton.Toolkit.PaletteMode.Microsoft365White;
            //
            // toolStrip
            //
            toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            toolStrip.Name = "toolStrip";
            toolStrip.Dock = System.Windows.Forms.DockStyle.Top;
            toolStrip.TabIndex = 3;
            //
            // panelMain
            //
            panelMain.Controls.Add(kryptonDockableWorkspace);
            panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMain.Name = "panelMain";
            panelMain.TabIndex = 1;
            //
            // kryptonDockableWorkspace
            //
            kryptonDockableWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            kryptonDockableWorkspace.Name = "kryptonDockableWorkspace";
            kryptonDockableWorkspace.TabIndex = 0;
            //
            // contextMenuStrip1
            //
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { contextMenuItemSetDefaultSortOrder });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(216, 26);
            //
            // contextMenuItemSetDefaultSortOrder
            //
            contextMenuItemSetDefaultSortOrder.Name = "contextMenuItemSetDefaultSortOrder";
            contextMenuItemSetDefaultSortOrder.Size = new System.Drawing.Size(215, 22);
            contextMenuItemSetDefaultSortOrder.Text = "Set as Default Sort Column";
            contextMenuItemSetDefaultSortOrder.Click += ContextMenuItemSetDefaultSortOrder_Click;
            //
            // autoRefreshTimer
            //
            autoRefreshTimer.Interval = 300000;
            autoRefreshTimer.Tick += AutoRefreshTimer_Tick;
            //
            // statusStrip
            //
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { statusLabelRefresh });
            statusStrip.Name = "statusStrip";
            statusStrip.TabIndex = 2;
            //
            // statusLabelRefresh
            //
            statusLabelRefresh.Name = "statusLabelRefresh";
            statusLabelRefresh.Text = "";
            //
            // FormMainWindow
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(930, 700);
            Controls.Add(panelMain);
            Controls.Add(statusStrip);
            Controls.Add(toolStrip);
            Name = "FormMainWindow";
            Text = "Service Manager";
            ((System.ComponentModel.ISupportInitialize)panelMain).EndInit();
            panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)kryptonDockableWorkspace).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Krypton.Toolkit.KryptonManager kryptonManager;
        private Krypton.Docking.KryptonDockingManager kryptonDockingManager;
        private Krypton.Toolkit.KryptonPanel panelMain;
        private Krypton.Docking.KryptonDockableWorkspace kryptonDockableWorkspace;
        private System.Windows.Forms.Timer autoRefreshTimer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemSetDefaultSortOrder;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelRefresh;
    }
}
