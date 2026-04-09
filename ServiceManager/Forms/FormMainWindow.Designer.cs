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
            panelToolbar = new Krypton.Toolkit.KryptonPanel();
            buttonAbout = new Krypton.Toolkit.KryptonButton();
            buttonEditServerList = new Krypton.Toolkit.KryptonButton();
            buttonThemeSelect = new Krypton.Toolkit.KryptonButton();
            buttonAutoRefresh = new Krypton.Toolkit.KryptonButton();
            labelRefreshDate = new Krypton.Toolkit.KryptonLabel();
            buttonRefresh = new Krypton.Toolkit.KryptonButton();
            panelMain = new Krypton.Toolkit.KryptonPanel();
            kryptonDockableWorkspace = new Krypton.Docking.KryptonDockableWorkspace();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            contextMenuItemSetDefaultSortOrder = new System.Windows.Forms.ToolStripMenuItem();
            themeMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
            autoRefreshTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)panelToolbar).BeginInit();
            panelToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panelMain).BeginInit();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)kryptonDockableWorkspace).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // kryptonManager
            // 
            kryptonManager.GlobalPaletteMode = Krypton.Toolkit.PaletteMode.Microsoft365White;
            kryptonManager.ToolkitStrings.MessageBoxStrings.LessDetails = "L&ess Details...";
            kryptonManager.ToolkitStrings.MessageBoxStrings.MoreDetails = "&More Details...";
            // 
            // panelToolbar
            // 
            panelToolbar.Controls.Add(buttonAbout);
            panelToolbar.Controls.Add(buttonEditServerList);
            panelToolbar.Controls.Add(buttonThemeSelect);
            panelToolbar.Controls.Add(buttonAutoRefresh);
            panelToolbar.Controls.Add(labelRefreshDate);
            panelToolbar.Controls.Add(buttonRefresh);
            panelToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            panelToolbar.Location = new System.Drawing.Point(0, 0);
            panelToolbar.Name = "panelToolbar";
            panelToolbar.Size = new System.Drawing.Size(930, 40);
            panelToolbar.TabIndex = 0;
            // 
            // buttonAbout
            // 
            buttonAbout.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            buttonAbout.Location = new System.Drawing.Point(870, 8);
            buttonAbout.Name = "buttonAbout";
            buttonAbout.Size = new System.Drawing.Size(60, 25);
            buttonAbout.TabIndex = 5;
            buttonAbout.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            buttonAbout.Values.Text = "About";
            buttonAbout.Click += ButtonAbout_Click;
            // 
            // buttonEditServerList
            // 
            buttonEditServerList.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            buttonEditServerList.Location = new System.Drawing.Point(770, 8);
            buttonEditServerList.Name = "buttonEditServerList";
            buttonEditServerList.Size = new System.Drawing.Size(96, 25);
            buttonEditServerList.TabIndex = 3;
            buttonEditServerList.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            buttonEditServerList.Values.Text = "Edit Server List";
            buttonEditServerList.Click += ButtonEditServerList_Click;
            // 
            // buttonThemeSelect
            // 
            buttonThemeSelect.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            buttonThemeSelect.Location = new System.Drawing.Point(646, 8);
            buttonThemeSelect.Name = "buttonThemeSelect";
            buttonThemeSelect.Size = new System.Drawing.Size(116, 25);
            buttonThemeSelect.TabIndex = 2;
            buttonThemeSelect.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            buttonThemeSelect.Values.Text = "Theme ▼";
            buttonThemeSelect.Click += ButtonThemeSelect_Click;
            // 
            // buttonAutoRefresh
            // 
            buttonAutoRefresh.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            buttonAutoRefresh.Location = new System.Drawing.Point(518, 8);
            buttonAutoRefresh.Name = "buttonAutoRefresh";
            buttonAutoRefresh.Size = new System.Drawing.Size(120, 25);
            buttonAutoRefresh.TabIndex = 4;
            buttonAutoRefresh.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            buttonAutoRefresh.Values.Text = "Auto Refresh: Off";
            buttonAutoRefresh.Click += ButtonAutoRefresh_Click;
            // 
            // labelRefreshDate
            // 
            labelRefreshDate.Location = new System.Drawing.Point(90, 10);
            labelRefreshDate.Name = "labelRefreshDate";
            labelRefreshDate.Size = new System.Drawing.Size(90, 25);
            labelRefreshDate.TabIndex = 1;
            labelRefreshDate.Values.Text = "";
            //
            // buttonRefresh
            //
            buttonRefresh.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            buttonRefresh.ButtonStyle = Krypton.Toolkit.ButtonStyle.Standalone;
            buttonRefresh.Location = new System.Drawing.Point(8, 8);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new System.Drawing.Size(75, 25);
            buttonRefresh.TabIndex = 0;
            buttonRefresh.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            buttonRefresh.Values.Text = "Refresh";
            buttonRefresh.Click += ButtonRefresh_Click;
            // 
            // panelMain
            // 
            panelMain.Controls.Add(kryptonDockableWorkspace);
            panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMain.Location = new System.Drawing.Point(0, 40);
            panelMain.Name = "panelMain";
            panelMain.Size = new System.Drawing.Size(930, 521);
            panelMain.TabIndex = 1;
            // 
            // kryptonDockableWorkspace
            // 
            kryptonDockableWorkspace.ActivePage = null;
            kryptonDockableWorkspace.CompactFlags = Krypton.Workspace.CompactFlags.RemoveEmptyCells | Krypton.Workspace.CompactFlags.RemoveEmptySequences | Krypton.Workspace.CompactFlags.PromoteLeafs;
            kryptonDockableWorkspace.ContainerBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelClient;
            kryptonDockableWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            kryptonDockableWorkspace.Location = new System.Drawing.Point(0, 0);
            kryptonDockableWorkspace.Name = "kryptonDockableWorkspace";
            // 
            // 
            // 
            kryptonDockableWorkspace.Root.UniqueName = "51ff52bd6b814f759db37d91a811dfbd";
            kryptonDockableWorkspace.SeparatorStyle = Krypton.Toolkit.SeparatorStyle.LowProfile;
            kryptonDockableWorkspace.ShowMaximizeButton = false;
            kryptonDockableWorkspace.Size = new System.Drawing.Size(930, 521);
            kryptonDockableWorkspace.SplitterWidth = 5;
            kryptonDockableWorkspace.TabIndex = 0;
            kryptonDockableWorkspace.TabStop = true;
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
            // themeMenuStrip
            // 
            themeMenuStrip.Name = "themeMenuStrip";
            themeMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // autoRefreshTimer
            // 
            autoRefreshTimer.Interval = 300000;
            autoRefreshTimer.Tick += AutoRefreshTimer_Tick;
            // 
            // FormMainWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(930, 561);
            Controls.Add(panelMain);
            Controls.Add(panelToolbar);
            Name = "FormMainWindow";
            Text = "Service Manager";
            ((System.ComponentModel.ISupportInitialize)panelToolbar).EndInit();
            panelToolbar.ResumeLayout(false);
            panelToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)panelMain).EndInit();
            panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)kryptonDockableWorkspace).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
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
