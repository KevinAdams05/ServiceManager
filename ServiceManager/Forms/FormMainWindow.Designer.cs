using System;

namespace ServiceManager
{
    public partial class FormMainWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainWindow));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Environment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Server = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stop = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Start = new System.Windows.Forms.DataGridViewButtonColumn();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.labelRefreshDate = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageServices = new System.Windows.Forms.TabPage();
            this.labelFilter = new System.Windows.Forms.Label();
            this.tabPageWebServers = new System.Windows.Forms.TabPage();
            this.dataGridViewWebServers = new System.Windows.Forms.DataGridView();
            this.AppServerEnvironmentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppServerServerColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppServerStatusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppServerResetColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.AppServerStopColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.AppServerStartColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.buttonEditServerList = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuItemSetDefaultSortOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new ServiceManager.DelayedTextBox();
            this.textBoxStatus = new ServiceManager.DelayedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageServices.SuspendLayout();
            this.tabPageWebServers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWebServers)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Environment,
            this.Server,
            this.Service,
            this.Status,
            this.Stop,
            this.Start});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(3, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(712, 357);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            // 
            // Environment
            // 
            this.Environment.HeaderText = "Environment";
            this.Environment.Name = "Environment";
            // 
            // Server
            // 
            this.Server.HeaderText = "Server";
            this.Server.Name = "Server";
            // 
            // Service
            // 
            this.Service.HeaderText = "Service";
            this.Service.Name = "Service";
            this.Service.Width = 150;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // Stop
            // 
            this.Stop.HeaderText = "";
            this.Stop.Name = "Stop";
            this.Stop.Text = "Stop";
            this.Stop.UseColumnTextForButtonValue = true;
            this.Stop.Width = 80;
            // 
            // Start
            // 
            this.Start.HeaderText = "";
            this.Start.Name = "Start";
            this.Start.Text = "Start";
            this.Start.UseColumnTextForButtonValue = true;
            this.Start.Width = 80;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(13, 13);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 1;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.ButtonRefresh_Click);
            // 
            // labelRefreshDate
            // 
            this.labelRefreshDate.AutoSize = true;
            this.labelRefreshDate.Location = new System.Drawing.Point(94, 18);
            this.labelRefreshDate.Name = "labelRefreshDate";
            this.labelRefreshDate.Size = new System.Drawing.Size(0, 13);
            this.labelRefreshDate.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageServices);
            this.tabControl1.Controls.Add(this.tabPageWebServers);
            this.tabControl1.Location = new System.Drawing.Point(13, 42);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(729, 417);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPageServices
            // 
            this.tabPageServices.Controls.Add(this.labelFilter);
            this.tabPageServices.Controls.Add(this.textBox1);
            this.tabPageServices.Controls.Add(this.dataGridView1);
            this.tabPageServices.Location = new System.Drawing.Point(4, 22);
            this.tabPageServices.Name = "tabPageServices";
            this.tabPageServices.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageServices.Size = new System.Drawing.Size(721, 391);
            this.tabPageServices.TabIndex = 0;
            this.tabPageServices.Text = "Services";
            this.tabPageServices.UseVisualStyleBackColor = true;
            // 
            // labelFilter
            // 
            this.labelFilter.AutoSize = true;
            this.labelFilter.Location = new System.Drawing.Point(6, 9);
            this.labelFilter.Name = "labelFilter";
            this.labelFilter.Size = new System.Drawing.Size(69, 13);
            this.labelFilter.TabIndex = 3;
            this.labelFilter.Text = "Environment:";
            // 
            // tabPageWebServers
            // 
            this.tabPageWebServers.Controls.Add(this.dataGridViewWebServers);
            this.tabPageWebServers.Location = new System.Drawing.Point(4, 22);
            this.tabPageWebServers.Name = "tabPageWebServers";
            this.tabPageWebServers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWebServers.Size = new System.Drawing.Size(721, 391);
            this.tabPageWebServers.TabIndex = 1;
            this.tabPageWebServers.Text = "Web Servers";
            this.tabPageWebServers.UseVisualStyleBackColor = true;
            // 
            // dataGridViewWebServers
            // 
            this.dataGridViewWebServers.AllowUserToAddRows = false;
            this.dataGridViewWebServers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewWebServers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWebServers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AppServerEnvironmentColumn,
            this.AppServerServerColumn,
            this.AppServerStatusColumn,
            this.AppServerResetColumn,
            this.AppServerStopColumn,
            this.AppServerStartColumn});
            this.dataGridViewWebServers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewWebServers.Location = new System.Drawing.Point(5, 0);
            this.dataGridViewWebServers.Name = "dataGridViewWebServers";
            this.dataGridViewWebServers.Size = new System.Drawing.Size(710, 388);
            this.dataGridViewWebServers.TabIndex = 1;
            this.dataGridViewWebServers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewWebServers_CellClick);
            // 
            // AppServerEnvironmentColumn
            // 
            this.AppServerEnvironmentColumn.HeaderText = "Environment";
            this.AppServerEnvironmentColumn.Name = "AppServerEnvironmentColumn";
            // 
            // AppServerServerColumn
            // 
            this.AppServerServerColumn.HeaderText = "Server";
            this.AppServerServerColumn.Name = "AppServerServerColumn";
            // 
            // AppServerStatusColumn
            // 
            this.AppServerStatusColumn.HeaderText = "Status";
            this.AppServerStatusColumn.Name = "AppServerStatusColumn";
            // 
            // AppServerResetColumn
            // 
            this.AppServerResetColumn.HeaderText = "Reset";
            this.AppServerResetColumn.Name = "AppServerResetColumn";
            this.AppServerResetColumn.Text = "Reset";
            this.AppServerResetColumn.UseColumnTextForButtonValue = true;
            // 
            // AppServerStopColumn
            // 
            this.AppServerStopColumn.HeaderText = "";
            this.AppServerStopColumn.Name = "AppServerStopColumn";
            this.AppServerStopColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AppServerStopColumn.Text = "Stop";
            this.AppServerStopColumn.UseColumnTextForButtonValue = true;
            // 
            // AppServerStartColumn
            // 
            this.AppServerStartColumn.HeaderText = "";
            this.AppServerStartColumn.Name = "AppServerStartColumn";
            this.AppServerStartColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AppServerStartColumn.Text = "Start";
            this.AppServerStartColumn.UseColumnTextForButtonValue = true;
            // 
            // buttonEditServerList
            // 
            this.buttonEditServerList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditServerList.Location = new System.Drawing.Point(640, 13);
            this.buttonEditServerList.Name = "buttonEditServerList";
            this.buttonEditServerList.Size = new System.Drawing.Size(92, 23);
            this.buttonEditServerList.TabIndex = 5;
            this.buttonEditServerList.Text = "Edit Server List";
            this.buttonEditServerList.UseVisualStyleBackColor = true;
            this.buttonEditServerList.Click += new System.EventHandler(this.ButtonEditServerList_Click);
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
            // textBox1
            // 
            this.textBox1.DelayedTextChangedTimeout = 1000;
            this.textBox1.Location = new System.Drawing.Point(80, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(122, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.DelayedTextChanged += new System.EventHandler(this.TextBox1_DelayedTextChanged);
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStatus.DelayedTextChangedTimeout = 1000;
            this.textBoxStatus.Location = new System.Drawing.Point(13, 465);
            this.textBoxStatus.Multiline = true;
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(729, 106);
            this.textBoxStatus.TabIndex = 3;
            // 
            // FormMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 583);
            this.Controls.Add(this.buttonEditServerList);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.labelRefreshDate);
            this.Controls.Add(this.buttonRefresh);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMainWindow";
            this.Text = "Service Status";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageServices.ResumeLayout(false);
            this.tabPageServices.PerformLayout();
            this.tabPageWebServers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWebServers)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Label labelRefreshDate;
        private DelayedTextBox textBoxStatus;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageServices;
        private System.Windows.Forms.TabPage tabPageWebServers;
        private System.Windows.Forms.DataGridView dataGridViewWebServers;
        private System.Windows.Forms.Button buttonEditServerList;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppServerEnvironmentColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppServerServerColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppServerStatusColumn;
        private System.Windows.Forms.DataGridViewButtonColumn AppServerResetColumn;
        private System.Windows.Forms.DataGridViewButtonColumn AppServerStopColumn;
        private System.Windows.Forms.DataGridViewButtonColumn AppServerStartColumn;
        private System.Windows.Forms.Label labelFilter;
        private DelayedTextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemSetDefaultSortOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn Environment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Server;
        private System.Windows.Forms.DataGridViewTextBoxColumn Service;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewButtonColumn Stop;
        private System.Windows.Forms.DataGridViewButtonColumn Start;
    }
}

