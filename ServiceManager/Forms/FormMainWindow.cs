using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Windows.Forms;

namespace ServiceManager
{
    public partial class FormMainWindow : Form
    {
        private List<Server> serversCurrent = new List<Server>();

        public FormMainWindow()
        {
            InitializeComponent();
            InitializeApplication();
        }

        private void InitializeApplication()
        {
            if (!Utility.DoesServerListExist(Utility.GetSettingServerListFilePath()))
            {
                DialogResult result = MessageBox.Show("Unable to find a list of servers, would you like to create a new list?", "Create New List?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Utility.GenerateAndSaveTestServerList();
                }
            }

            foreach (DataGridViewColumn gridViewColumn in dataGridView1.Columns)
            {
                gridViewColumn.HeaderCell.ContextMenuStrip = contextMenuStrip1;
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
            // This is still in a work in progress. This will auto-size those columns, but then the user can't resize :(
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
                            textBoxStatus.AppendText(ex.Message + System.Environment.NewLine);
                        }
                        if (ex.InnerException?.Message == "The RPC server is unavailable")
                        {
                            dataGridView1.Rows[row.Index].Cells["Status"].Style.BackColor = Color.Red;
                            dataGridView1.Rows[row.Index].Cells["Status"].Value = ex.InnerException.Message;
                            textBoxStatus.AppendText(computerName + ": ");
                            textBoxStatus.AppendText(ex.Message + System.Environment.NewLine);
                        }
                        else
                        {
                            textBoxStatus.AppendText(ex.ToString());
                        }
                    }
                }

                string messageText = $"Last refresh: {DateTime.Now.ToString()} {System.Environment.NewLine}";
                textBoxStatus.AppendText(messageText);
                labelRefreshDate.Text = messageText;
            }
            catch (Exception ex)
            {
                textBoxStatus.AppendText(ex.ToString());
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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
            textBoxStatus.AppendText($"{action} '{serviceName}' on '{computerName}'{System.Environment.NewLine}");

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

            textBoxStatus.AppendText(results + System.Environment.NewLine);
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
                    textBoxStatus.AppendText($"IIS Reset on '{computerName}'{System.Environment.NewLine}");
                    Utility.PerformWebServerAction(computerName, "restart");
                }

                if (dataGridViewWebServers.Columns.Contains("AppServerStopColumn") && e.ColumnIndex == dataGridViewWebServers.Columns["AppServerStopColumn"].Index)
                {
                    textBoxStatus.AppendText($"IIS Stop on '{computerName}'{System.Environment.NewLine}");
                    Utility.PerformWebServerAction(computerName, "stop");
                }

                if (dataGridViewWebServers.Columns.Contains("AppServerStartColumn") && e.ColumnIndex == dataGridViewWebServers.Columns["AppServerStartColumn"].Index)
                {
                    textBoxStatus.AppendText($"IIS Start on '{computerName}'{System.Environment.NewLine}");
                    Utility.PerformWebServerAction(computerName, "start");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "The system cannot find the file specified")
                {
                    textBoxStatus.AppendText($"ERROR: Unable to reset IIS on '{computerName}'{System.Environment.NewLine}");
                    textBoxStatus.AppendText($"Do you have IIS installed on your local computer?{System.Environment.NewLine}");
                    textBoxStatus.AppendText("This is required to do a remote IISReset");
                }
                else
                {
                    textBoxStatus.AppendText($"ERROR: Exception while resetting IIS on '{computerName}'{System.Environment.NewLine}");
                    textBoxStatus.AppendText(ex + System.Environment.NewLine);
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
            List<Server> serversFiltered = serversCurrent.Where(x => x.EnvironmentName.ToUpper().Contains(textBox1.Text.ToUpper())).ToList();
            PopulateDataGrids(serversFiltered);
            RefreshServiceStatus();
        }

        private void ContextMenuItemSetDefaultSortOrder_Click(object sender, EventArgs e)
        {
            int columnIndex = dataGridView1.HitTest(dataGridView1.PointToClient(Cursor.Position).X, dataGridView1.PointToClient(Cursor.Position).Y).ColumnIndex;

            if (columnIndex < 4)
            {
                Utility.UpdateSettingDefaultSortColumn(columnIndex);
                dataGridView1.Sort(dataGridView1.Columns[columnIndex], ListSortDirection.Ascending);
            }

            textBoxStatus.AppendText($"Column {columnIndex} set as default sort column {System.Environment.NewLine}");
        }
    }
}