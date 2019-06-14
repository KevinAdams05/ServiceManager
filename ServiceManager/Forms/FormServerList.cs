using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceManager
{
    public partial class FormServerList : Form
    {
        public FormServerList()
        {
            InitializeComponent();

            Servers = Utility.LoadServerList();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AutoSize = true;
            dataGridView1.DataSource = Servers;
            ResizeColumns();
        }

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

        private void RefreshDataSource()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Servers;
            ResizeColumns();
        }

        private void ResizeColumns()
        {
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
    }
}
