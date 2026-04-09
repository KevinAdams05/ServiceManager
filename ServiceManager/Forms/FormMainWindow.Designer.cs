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
            this.components = new System.ComponentModel.Container();

            this.kryptonManager = new Krypton.Toolkit.KryptonManager(this.components);
            this.kryptonDockingManager = new Krypton.Docking.KryptonDockingManager();
            this.panelToolbar = new Krypton.Toolkit.KryptonPanel();
            this.panelMain = new Krypton.Toolkit.KryptonPanel();
            this.buttonRefresh = new Krypton.Toolkit.KryptonButton();
            this.buttonEditServerList = new Krypton.Toolkit.KryptonButton();
            this.buttonThemeSelect = new Krypton.Toolkit.KryptonButton();
            this.labelRefreshDate = new Krypton.Toolkit.KryptonLabel();
            this.kryptonDockableWorkspace = new Krypton.Docking.KryptonDockableWorkspace();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuItemSetDefaultSortOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.themeMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.buttonAutoRefresh = new Krypton.Toolkit.KryptonButton();
            this.autoRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.buttonAbout = new Krypton.Toolkit.KryptonButton();

            ((System.ComponentModel.ISupportInitialize)(this.panelToolbar)).BeginInit();
            this.panelToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDockableWorkspace)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();

            //
            // kryptonManager
            //
            this.kryptonManager.GlobalPaletteMode = Krypton.Toolkit.PaletteMode.Microsoft365White;

            //
            // panelToolbar
            //
            this.panelToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToolbar.Location = new System.Drawing.Point(0, 0);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Size = new System.Drawing.Size(784, 40);
            this.panelToolbar.TabIndex = 0;
            this.panelToolbar.Controls.Add(this.buttonAbout);
            this.panelToolbar.Controls.Add(this.buttonEditServerList);
            this.panelToolbar.Controls.Add(this.buttonThemeSelect);
            this.panelToolbar.Controls.Add(this.buttonAutoRefresh);
            this.panelToolbar.Controls.Add(this.labelRefreshDate);
            this.panelToolbar.Controls.Add(this.buttonRefresh);

            //
            // buttonRefresh
            //
            this.buttonRefresh.Location = new System.Drawing.Point(8, 8);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 25);
            this.buttonRefresh.TabIndex = 0;
            this.buttonRefresh.Values.Text = "Refresh";
            this.buttonRefresh.Click += new System.EventHandler(this.ButtonRefresh_Click);

            //
            // labelRefreshDate
            //
            this.labelRefreshDate.Location = new System.Drawing.Point(90, 10);
            this.labelRefreshDate.Name = "labelRefreshDate";
            this.labelRefreshDate.TabIndex = 1;
            this.labelRefreshDate.Values.Text = "";

            //
            // buttonThemeSelect
            //
            this.buttonThemeSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonThemeSelect.Location = new System.Drawing.Point(556, 8);
            this.buttonThemeSelect.Name = "buttonThemeSelect";
            this.buttonThemeSelect.Size = new System.Drawing.Size(116, 25);
            this.buttonThemeSelect.TabIndex = 2;
            this.buttonThemeSelect.Values.Text = "Theme \u25BC";
            this.buttonThemeSelect.Click += new System.EventHandler(this.ButtonThemeSelect_Click);

            //
            // themeMenuStrip
            //
            this.themeMenuStrip.Name = "themeMenuStrip";
            this.themeMenuStrip.Size = new System.Drawing.Size(200, 26);

            //
            // buttonAutoRefresh
            //
            this.buttonAutoRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAutoRefresh.Location = new System.Drawing.Point(430, 8);
            this.buttonAutoRefresh.Name = "buttonAutoRefresh";
            this.buttonAutoRefresh.Size = new System.Drawing.Size(120, 25);
            this.buttonAutoRefresh.TabIndex = 4;
            this.buttonAutoRefresh.Values.Text = "Auto Refresh: Off";
            this.buttonAutoRefresh.Click += new System.EventHandler(this.ButtonAutoRefresh_Click);

            //
            // autoRefreshTimer
            //
            this.autoRefreshTimer.Interval = 300000;
            this.autoRefreshTimer.Tick += new System.EventHandler(this.AutoRefreshTimer_Tick);

            //
            // buttonEditServerList
            //
            this.buttonEditServerList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditServerList.Location = new System.Drawing.Point(680, 8);
            this.buttonEditServerList.Name = "buttonEditServerList";
            this.buttonEditServerList.Size = new System.Drawing.Size(96, 25);
            this.buttonEditServerList.TabIndex = 3;
            this.buttonEditServerList.Values.Text = "Edit Server List";
            this.buttonEditServerList.Click += new System.EventHandler(this.ButtonEditServerList_Click);

            //
            // buttonAbout
            //
            this.buttonAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAbout.Location = new System.Drawing.Point(780, 8);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(60, 25);
            this.buttonAbout.TabIndex = 5;
            this.buttonAbout.Values.Text = "About";
            this.buttonAbout.Click += new System.EventHandler(this.ButtonAbout_Click);

            //
            // panelMain
            //
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 40);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(784, 521);
            this.panelMain.TabIndex = 1;
            this.panelMain.Controls.Add(this.kryptonDockableWorkspace);

            //
            // kryptonDockableWorkspace
            //
            this.kryptonDockableWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonDockableWorkspace.Name = "kryptonDockableWorkspace";
            this.kryptonDockableWorkspace.TabIndex = 0;

            //
            // contextMenuStrip1
            //
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.contextMenuItemSetDefaultSortOrder});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(216, 26);

            //
            // contextMenuItemSetDefaultSortOrder
            //
            this.contextMenuItemSetDefaultSortOrder.Name = "contextMenuItemSetDefaultSortOrder";
            this.contextMenuItemSetDefaultSortOrder.Size = new System.Drawing.Size(215, 22);
            this.contextMenuItemSetDefaultSortOrder.Text = "Set as Default Sort Column";
            this.contextMenuItemSetDefaultSortOrder.Click += new System.EventHandler(this.ContextMenuItemSetDefaultSortOrder_Click);

            //
            // FormMainWindow
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 561);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelToolbar);
            this.Name = "FormMainWindow";
            this.Text = "Service Manager";

            ((System.ComponentModel.ISupportInitialize)(this.panelToolbar)).EndInit();
            this.panelToolbar.ResumeLayout(false);
            this.panelToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDockableWorkspace)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Krypton.Toolkit.KryptonManager kryptonManager;
        private Krypton.Docking.KryptonDockingManager kryptonDockingManager;
        private Krypton.Toolkit.KryptonPanel panelToolbar;
        private Krypton.Toolkit.KryptonPanel panelMain;
        private Krypton.Toolkit.KryptonButton buttonRefresh;
        private Krypton.Toolkit.KryptonButton buttonEditServerList;
        private Krypton.Toolkit.KryptonButton buttonThemeSelect;
        private Krypton.Toolkit.KryptonLabel labelRefreshDate;
        private System.Windows.Forms.ContextMenuStrip themeMenuStrip;
        private Krypton.Toolkit.KryptonButton buttonAutoRefresh;
        private System.Windows.Forms.Timer autoRefreshTimer;
        private Krypton.Docking.KryptonDockableWorkspace kryptonDockableWorkspace;
        private Krypton.Toolkit.KryptonButton buttonAbout;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemSetDefaultSortOrder;
    }
}
