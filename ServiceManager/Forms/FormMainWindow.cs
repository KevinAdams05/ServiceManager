using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Krypton.Docking;
using Krypton.Navigator;
using Krypton.Toolkit;
using Krypton.Workspace;

namespace ServiceManager
{
    public partial class FormMainWindow : KryptonForm
    {
        private List<Server> serversCurrent = new List<Server>();
        private string currentAppliedTheme;
        private KryptonDataGridView dataGridView1;
        private KryptonDataGridView dataGridViewWebServers;
        private DelayedTextBox textBoxStatus;
        private DelayedTextBox textBox1;
        private KryptonLabel labelFilter;

        public FormMainWindow()
        {
            InitializeComponent();
            CreateControls();
            SetupDocking();
            ApplyThemeFromSettings();
            SetFormIcon();
            InitializeApplication();
        }

        private void SetFormIcon()
        {
            Icon appIcon = Utility.GetApplicationIcon();

            if (appIcon != null)
            {
                this.Icon = appIcon;
            }
        }

        private void CreateControls()
        {
            // Services DataGridView
            dataGridView1 = new KryptonDataGridView();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { HeaderText = "Environment", Name = "Environment" },
                new DataGridViewTextBoxColumn { HeaderText = "Server", Name = "Server" },
                new DataGridViewTextBoxColumn { HeaderText = "Service", Name = "Service", Width = 150 },
                new DataGridViewTextBoxColumn { HeaderText = "Status", Name = "Status" },
                new DataGridViewButtonColumn { HeaderText = "", Name = "Stop", Text = "Stop", UseColumnTextForButtonValue = true, Width = 80 },
                new DataGridViewButtonColumn { HeaderText = "", Name = "Start", Text = "Start", UseColumnTextForButtonValue = true, Width = 80 }
            });
            dataGridView1.CellClick += DataGridView1_CellClick;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.HeaderCell.ContextMenuStrip = contextMenuStrip1;
            }

            // Web Servers DataGridView
            dataGridViewWebServers = new KryptonDataGridView();
            dataGridViewWebServers.AllowUserToAddRows = false;
            dataGridViewWebServers.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridViewWebServers.Dock = DockStyle.Fill;
            dataGridViewWebServers.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { HeaderText = "Environment", Name = "AppServerEnvironmentColumn" },
                new DataGridViewTextBoxColumn { HeaderText = "Server", Name = "AppServerServerColumn" },
                new DataGridViewTextBoxColumn { HeaderText = "Status", Name = "AppServerStatusColumn" },
                new DataGridViewButtonColumn { HeaderText = "Reset", Name = "AppServerResetColumn", Text = "Reset", UseColumnTextForButtonValue = true },
                new DataGridViewButtonColumn { HeaderText = "", Name = "AppServerStopColumn", Text = "Stop", UseColumnTextForButtonValue = true },
                new DataGridViewButtonColumn { HeaderText = "", Name = "AppServerStartColumn", Text = "Start", UseColumnTextForButtonValue = true }
            });
            dataGridViewWebServers.CellClick += DataGridViewWebServers_CellClick;

            // Filter controls
            labelFilter = new KryptonLabel();
            labelFilter.Values.Text = "Environment:";
            labelFilter.Location = new Point(6, 6);

            textBox1 = new DelayedTextBox();
            textBox1.DelayedTextChangedTimeout = 1000;
            textBox1.Location = new Point(100, 4);
            textBox1.Size = new Size(150, 23);
            textBox1.DelayedTextChanged += TextBox1_DelayedTextChanged;

            // Status textbox
            textBoxStatus = new DelayedTextBox();
            textBoxStatus.Multiline = true;
            textBoxStatus.Dock = DockStyle.Fill;
            textBoxStatus.ScrollBars = ScrollBars.Vertical;
        }

        private void SetupDocking()
        {
            // Create pages
            KryptonPage servicesPage = CreatePage("Services", "Services");
            KryptonPage webServersPage = CreatePage("Web Servers", "WebServers");
            KryptonPage statusPage = CreatePage("Status Log", "StatusLog");

            // Services page: filter panel (top) + grid (fill)
            KryptonPanel filterPanel = new KryptonPanel();
            filterPanel.Dock = DockStyle.Top;
            filterPanel.Height = 30;
            filterPanel.Controls.Add(textBox1);
            filterPanel.Controls.Add(labelFilter);

            servicesPage.Controls.Add(dataGridView1);
            servicesPage.Controls.Add(filterPanel);

            // Web Servers page
            webServersPage.Controls.Add(dataGridViewWebServers);

            // Status page
            statusPage.Controls.Add(textBoxStatus);

            // Setup docking manager
            KryptonDockingWorkspace w = kryptonDockingManager.ManageWorkspace("Workspace", kryptonDockableWorkspace);
            kryptonDockingManager.ManageControl("Control", panelMain, w);
            kryptonDockingManager.ManageFloating("Floating", this);

            // Add main tabs to workspace
            KryptonWorkspaceCell cell = new KryptonWorkspaceCell();
            cell.Pages.AddRange(new KryptonPage[] { servicesPage, webServersPage });
            kryptonDockableWorkspace.Root.Children.Add(cell);

            // Add status log as docked panel at bottom
            kryptonDockingManager.AddDockspace("Control", DockingEdge.Bottom, new KryptonPage[] { statusPage });
        }

        private KryptonPage CreatePage(string title, string uniqueName)
        {
            KryptonPage page = new KryptonPage();
            page.Text = title;
            page.TextTitle = title;
            page.TextDescription = title;
            page.UniqueName = uniqueName;

            return page;
        }

        private void InitializeApplication()
        {
            if (!Utility.DoesServerListExist(Utility.GetSettingServerListFilePath()))
            {
                DialogResult result = MessageBox.Show(
                    "Unable to find a list of servers, would you like to create a new list?",
                    "Create New List?",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    Utility.GenerateAndSaveTestServerList();
                }
            }

            serversCurrent = Utility.LoadServerList();
            PopulateDataGrids(serversCurrent);
            RefreshServiceStatus();
        }

        private void PopulateDataGrids(List<Server> servers)
        {
            dataGridView1.Rows.Clear();
            dataGridViewWebServers.Rows.Clear();

            foreach (Server server in servers)
            {
                if (server.ServerType == ServerTypes.WebServer)
                {
                    dataGridViewWebServers.Rows.Add(server.EnvironmentName, server.ServerName);
                }

                if (server.ServerType == ServerTypes.Service)
                {
                    dataGridView1.Rows.Add(server.EnvironmentName, server.ServerName, server.ServiceName, "unknown");
                }
            }

            SortGridsByDefaultSortSetting();
            ResizeColumns();
        }

        private void ResizeColumns()
        {
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewWebServers.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewWebServers.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewWebServers.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void SortGridsByDefaultSortSetting()
        {
            int sortColumn = Utility.GetSettingDefaultSortColumn();

            if (dataGridView1.ColumnCount - 1 >= sortColumn)
            {
                dataGridView1.Sort(dataGridView1.Columns[sortColumn], ListSortDirection.Ascending);
            }

            if (dataGridViewWebServers.ColumnCount - 1 >= sortColumn)
            {
                dataGridViewWebServers.Sort(dataGridViewWebServers.Columns[sortColumn], ListSortDirection.Ascending);
            }
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshServiceStatus();
        }

        private void RefreshServiceStatus()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string computerName = dataGridView1.Rows[row.Index].Cells["Server"].Value.ToString();
                    string serviceName = dataGridView1.Rows[row.Index].Cells["Service"].Value.ToString();

                    try
                    {
                        string status = Utility.GetServiceStatus(computerName, serviceName);
                        dataGridView1.Rows[row.Index].Cells["Status"].Value = status;

                        if (status == "Stopped")
                        {
                            dataGridView1.Rows[row.Index].Cells["Status"].Style.BackColor = Color.LightPink;
                        }
                        else
                        {
                            dataGridView1.Rows[row.Index].Cells["Status"].Style.BackColor = DefaultBackColor;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex.InnerException?.Message == "The specified service does not exist as an installed service")
                        {
                            dataGridView1.Rows[row.Index].Cells["Status"].Style.BackColor = Color.Red;
                            dataGridView1.Rows[row.Index].Cells["Status"].Value = ex.InnerException.Message;
                            textBoxStatus.AppendText(computerName);
                            textBoxStatus.AppendText(ex.Message + Environment.NewLine);
                        }

                        if (ex.InnerException?.Message == "The RPC server is unavailable")
                        {
                            dataGridView1.Rows[row.Index].Cells["Status"].Style.BackColor = Color.Red;
                            dataGridView1.Rows[row.Index].Cells["Status"].Value = ex.InnerException.Message;
                            textBoxStatus.AppendText(computerName + ": ");
                            textBoxStatus.AppendText(ex.Message + Environment.NewLine);
                        }
                        else
                        {
                            textBoxStatus.AppendText(ex.ToString());
                        }
                    }
                }

                string messageText = $"Last refresh: {DateTime.Now}";
                textBoxStatus.AppendText(messageText + Environment.NewLine);
                labelRefreshDate.Values.Text = messageText;
            }
            catch (Exception ex)
            {
                textBoxStatus.AppendText(ex.ToString());
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                if (dataGridView1.Columns.Contains("Start") && e.ColumnIndex == dataGridView1.Columns["Start"].Index)
                {
                    ChangeServiceState("start", e.RowIndex);
                }

                if (dataGridView1.Columns.Contains("Stop") && e.ColumnIndex == dataGridView1.Columns["Stop"].Index)
                {
                    ChangeServiceState("stop", e.RowIndex);
                }
            }
            catch (InvalidOperationException ex)
            {
                if (ex.InnerException?.Message == "The service cannot be started, either because it is disabled or because it has no enabled devices associated with it")
                {
                    string serverName = dataGridView1.Rows[e.RowIndex].Cells["Server"].Value.ToString();
                    textBoxStatus.AppendText($"{serverName}: {ex.InnerException?.Message}");
                }
                else
                {
                    textBoxStatus.AppendText(ex.ToString());
                }
            }

            Cursor.Current = Cursors.Default;
        }

        private void ChangeServiceState(string action, int rowIndex)
        {
            string results = string.Empty;
            string computerName = dataGridView1.Rows[rowIndex].Cells["Server"].Value.ToString();
            string serviceName = dataGridView1.Rows[rowIndex].Cells["Service"].Value.ToString();
            string environmentName = dataGridView1.Rows[rowIndex].Cells["Environment"].Value.ToString();
            textBoxStatus.AppendText($"{action} '{serviceName}' on '{computerName}'{Environment.NewLine}");

            if (serviceName.IsNullOrEmpty())
            {
                textBoxStatus.AppendText("Service Name field is empty");
                return;
            }

            if (computerName.IsNullOrEmpty())
            {
                textBoxStatus.AppendText("Computer Name field is empty");
                return;
            }

            if (environmentName.IsNullOrEmpty())
            {
                textBoxStatus.AppendText("Environment field is empty");
                return;
            }

            if (WarnOnProduction() && IsServerProduction(environmentName) && RunOnProduction() == DialogResult.No)
            {
                return;
            }

            if (action == "stop")
            {
                results = Utility.ServiceStop(computerName, serviceName);
            }

            if (action == "start")
            {
                results = Utility.ServiceStart(computerName, serviceName);
            }

            textBoxStatus.AppendText(results + Environment.NewLine);
            RefreshServiceStatus();
        }

        private void DataGridViewWebServers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            int rowIndex = e.RowIndex;

            if (rowIndex < 0)
            {
                return;
            }

            string computerName = dataGridViewWebServers.Rows[rowIndex].Cells["AppServerServerColumn"].Value.ToString();
            string environmentName = dataGridViewWebServers.Rows[rowIndex].Cells["AppServerEnvironmentColumn"].Value.ToString();

            if (computerName.IsNullOrEmpty())
            {
                textBoxStatus.AppendText("Computer Name field is empty");
                return;
            }

            if (environmentName.IsNullOrEmpty())
            {
                textBoxStatus.AppendText("Environment field is empty");
                return;
            }

            if (WarnOnProduction() && IsServerProduction(environmentName) && RunOnProduction() == DialogResult.No)
            {
                return;
            }

            try
            {
                if (dataGridViewWebServers.Columns.Contains("AppServerResetColumn") && e.ColumnIndex == dataGridViewWebServers.Columns["AppServerResetColumn"].Index)
                {
                    textBoxStatus.AppendText($"IIS Reset on '{computerName}'{Environment.NewLine}");
                    Utility.PerformWebServerAction(computerName, "restart");
                }

                if (dataGridViewWebServers.Columns.Contains("AppServerStopColumn") && e.ColumnIndex == dataGridViewWebServers.Columns["AppServerStopColumn"].Index)
                {
                    textBoxStatus.AppendText($"IIS Stop on '{computerName}'{Environment.NewLine}");
                    Utility.PerformWebServerAction(computerName, "stop");
                }

                if (dataGridViewWebServers.Columns.Contains("AppServerStartColumn") && e.ColumnIndex == dataGridViewWebServers.Columns["AppServerStartColumn"].Index)
                {
                    textBoxStatus.AppendText($"IIS Start on '{computerName}'{Environment.NewLine}");
                    Utility.PerformWebServerAction(computerName, "start");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "The system cannot find the file specified")
                {
                    textBoxStatus.AppendText($"ERROR: Unable to reset IIS on '{computerName}'{Environment.NewLine}");
                    textBoxStatus.AppendText($"Do you have IIS installed on your local computer?{Environment.NewLine}");
                    textBoxStatus.AppendText("This is required to do a remote IISReset");
                }
                else
                {
                    textBoxStatus.AppendText($"ERROR: Exception while resetting IIS on '{computerName}'{Environment.NewLine}");
                    textBoxStatus.AppendText(ex + Environment.NewLine);
                }
            }

            Cursor.Current = Cursors.Default;
        }

        public static DialogResult RunOnProduction()
        {
            DialogResult result = MessageBox.Show(
                "WARNING: This is a production environment, would you like to proceed?",
                "Warning",
                MessageBoxButtons.YesNo);

            return result;
        }

        public static List<string> GetSettingProductionEnvironmentTerms()
        {
            List<string> terms = new List<string>(ConfigurationManager.AppSettings["ProductionEnvironmentTerms"].Split(';'));

            return terms;
        }

        private static bool WarnOnProduction()
        {
            return ConfigurationManager.AppSettings["WarnOnProduction"].CaseInsensitiveContains("true");
        }

        public static bool IsServerProduction(string environmentName)
        {
            bool isProduction = false;

            foreach (string term in GetSettingProductionEnvironmentTerms())
            {
                if (environmentName.CaseInsensitiveContains(term))
                {
                    isProduction = true;
                }
            }

            return isProduction;
        }

        private void ButtonEditServerList_Click(object sender, EventArgs e)
        {
            FormServerList formServerList = new FormServerList();
            DialogResult result = formServerList.ShowDialog();

            if (result == DialogResult.OK)
            {
                PopulateDataGrids(formServerList.Servers);
                RefreshServiceStatus();
            }
        }

        private void TextBox1_DelayedTextChanged(object sender, EventArgs e)
        {
            List<Server> serversFiltered = serversCurrent
                .Where(x => x.EnvironmentName.ToUpper().Contains(textBox1.Text.ToUpper()))
                .ToList();

            PopulateDataGrids(serversFiltered);
            RefreshServiceStatus();
        }

        private void ContextMenuItemSetDefaultSortOrder_Click(object sender, EventArgs e)
        {
            int columnIndex = dataGridView1.HitTest(
                dataGridView1.PointToClient(Cursor.Position).X,
                dataGridView1.PointToClient(Cursor.Position).Y).ColumnIndex;

            if (columnIndex < 4)
            {
                Utility.UpdateSettingDefaultSortColumn(columnIndex);
                dataGridView1.Sort(dataGridView1.Columns[columnIndex], ListSortDirection.Ascending);
            }

            textBoxStatus.AppendText($"Column {columnIndex} set as default sort column {Environment.NewLine}");
        }

        private void ButtonThemeSelect_Click(object sender, EventArgs e)
        {
            BuildThemeMenu();
            themeMenuStrip.Show(buttonThemeSelect, new Point(0, buttonThemeSelect.Height));
        }

        private void BuildThemeMenu()
        {
            themeMenuStrip.Items.Clear();
            string themesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Themes");
            string currentTheme = Utility.GetSettingTheme();

            if (!Directory.Exists(themesFolder))
            {
                return;
            }

            string[] themeFiles = Directory.GetFiles(themesFolder, "*.xml");
            Array.Sort(themeFiles, (a, b) => string.Compare(Path.GetFileNameWithoutExtension(a), Path.GetFileNameWithoutExtension(b), StringComparison.OrdinalIgnoreCase));

            foreach (string themeFile in themeFiles)
            {
                string themeName = Path.GetFileNameWithoutExtension(themeFile);
                ToolStripMenuItem menuItem = new ToolStripMenuItem(themeName);
                menuItem.Tag = themeFile;

                if (string.Equals(themeName, currentTheme, StringComparison.OrdinalIgnoreCase))
                {
                    menuItem.Checked = true;
                }

                menuItem.Click += ThemeMenuItem_Click;

                // Right-click to set as default
                menuItem.MouseDown += ThemeMenuItem_MouseDown;

                themeMenuStrip.Items.Add(menuItem);
            }

            themeMenuStrip.Items.Add(new ToolStripSeparator());

            string defaultTheme = Utility.GetSettingTheme();
            ToolStripMenuItem defaultLabel = new ToolStripMenuItem($"Default: {defaultTheme}");
            defaultLabel.Enabled = false;
            themeMenuStrip.Items.Add(defaultLabel);

            ToolStripMenuItem setDefaultItem = new ToolStripMenuItem("Set Current as Default");
            setDefaultItem.Click += SetCurrentAsDefault_Click;
            themeMenuStrip.Items.Add(setDefaultItem);
        }

        private void ThemeMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            string themeFile = (string)menuItem.Tag;
            string themeName = Path.GetFileNameWithoutExtension(themeFile);

            ApplyTheme(themeName);
            currentAppliedTheme = themeName;
        }

        private void ThemeMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
                string themeName = Path.GetFileNameWithoutExtension((string)menuItem.Tag);
                Utility.UpdateSettingTheme(themeName);
                textBoxStatus.AppendText($"Default theme set to: {themeName}{Environment.NewLine}");
                themeMenuStrip.Close();
            }
        }

        private void SetCurrentAsDefault_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentAppliedTheme))
            {
                Utility.UpdateSettingTheme(currentAppliedTheme);
                textBoxStatus.AppendText($"Default theme set to: {currentAppliedTheme}{Environment.NewLine}");
            }
        }

        private void ApplyThemeFromSettings()
        {
            string theme = Utility.GetSettingTheme();
            ApplyTheme(theme);
            currentAppliedTheme = theme;
        }

        private void ApplyTheme(string themeName)
        {
            string themesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Themes");
            string palettePath = Path.Combine(themesFolder, themeName + ".xml");

            if (File.Exists(palettePath))
            {
                try
                {
                    KryptonCustomPaletteBase palette = new KryptonCustomPaletteBase();
                    palette.Import(palettePath);
                    kryptonManager.GlobalCustomPalette = palette;
                    kryptonManager.GlobalPaletteMode = PaletteMode.Custom;
                    currentAppliedTheme = themeName;
                }
                catch (Exception ex)
                {
                    textBoxStatus.AppendText($"Error loading theme '{themeName}': {ex.Message}{Environment.NewLine}");
                    kryptonManager.GlobalPaletteMode = PaletteMode.Microsoft365White;
                }
            }
            else
            {
                kryptonManager.GlobalPaletteMode = PaletteMode.Microsoft365White;
            }
        }
    }
}
