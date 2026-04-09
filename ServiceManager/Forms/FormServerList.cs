using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Krypton.Toolkit;

namespace ServiceManager
{
    public partial class FormServerList : KryptonForm
    {
        public FormServerList()
        {
            InitializeComponent();

            Icon appIcon = Utility.GetApplicationIcon();

            if (appIcon != null)
            {
                this.Icon = appIcon;
            }

            Servers = Utility.LoadServerList();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSize = true;
            SetupServerListColumns();
            dataGridView1.DataSource = Servers;
            ResizeColumns();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Server> Servers { get; set; }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            Utility.UpdateServerList(Servers);
            Close();
            DialogResult = DialogResult.OK;
        }

        private void ButtonDiscard_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.Cancel;
        }

        private void ButtonAddRow_Click(object sender, EventArgs e)
        {
            Server newServer = new Server();
            Servers.Add(newServer);
            RefreshDataSource();
        }

        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex != -1 && e.ColumnIndex != -1)
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[e.RowIndex].Selected = true;

                    Point relativeMousePosition = dataGridView1.PointToClient(Cursor.Position);
                    contextMenuStrip1.Show(dataGridView1, relativeMousePosition);
                }
            }
        }

        private void ContextMenuItemRemoveServer_Click(object sender, EventArgs e)
        {
            int rowToDelete = dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            Servers.RemoveAt(rowToDelete);
            RefreshDataSource();
        }

        private void SetupServerListColumns()
        {
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Environment",
                DataPropertyName = "EnvironmentName",
                Name = "EnvironmentName"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Server",
                DataPropertyName = "ServerName",
                Name = "ServerName"
            });

            DataGridViewComboBoxColumn serverTypeColumn = new DataGridViewComboBoxColumn();
            serverTypeColumn.HeaderText = "Server Type";
            serverTypeColumn.DataPropertyName = "ServerType";
            serverTypeColumn.Name = "ServerType";
            serverTypeColumn.DataSource = Enum.GetValues(typeof(ServerTypes));
            dataGridView1.Columns.Add(serverTypeColumn);

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Service Name",
                DataPropertyName = "ServiceName",
                Name = "ServiceName"
            });
        }

        private void RefreshDataSource()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Servers;
            ResizeColumns();
        }

        private void ResizeColumns()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
    }
}
