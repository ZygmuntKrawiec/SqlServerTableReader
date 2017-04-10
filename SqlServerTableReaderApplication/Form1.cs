using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using SqlTableReaderProvider;
using System.Data;
using System.Drawing;

namespace SqlServerTableReaderApplication
{
    public partial class Form1 : Form
    {
        Broker broker;
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Reads names of all running Sql Server instances names and displays them in a combobox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_ConnectToServer_Click(object sender, EventArgs e)
        {
            if (broker == null)
            {
                Task loadingSqlServerNames = new Task(() => broker = new Broker());
                loadingSqlServerNames.Start();
                lbl_Info.Text = "Connecting to Sql Server.";
                gbx_Server.Enabled = false;
                gbx_Database.Enabled = false;
                gbx_Table.Enabled = false;
                await loadingSqlServerNames;
                gbx_Server.Enabled = true;
                gbx_Database.Enabled = true;
                gbx_Table.Enabled = true;
                lbl_Info.ForeColor = Color.Black;
                
                cmb_Server.DataSource = broker.SelectSqlServersNames();
                if (cmb_Server.Items.Count == 0)
                {
                    lbl_Info.Text = "Cannot connect to Sql Server.";
                    broker = null;
                }
                else
                {
                    lbl_Info.Text = "Connected.";
                    btn_ConnectToServer.Text = "Disconnect";                  
                }
            }
            else
            {

                btn_ConnectToServer.Text = "Connect";
                lbl_Info.ForeColor = Color.Black;
                lbl_Info.Text = "";
                cmb_Server.DataSource = null;
                cmb_Database.DataSource = null;
                cmb_Table.DataSource = null;
                dgv_TableContent.DataSource = null;
                broker = null;
            }
        }

        /// <summary>
        /// Reads names of all available databases on a chosen sql server instance and displays them in a combobox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_Server_SelectedValueChanged(object sender, EventArgs e)
        {

            int chosenServerIndex = ((ComboBox)sender).SelectedIndex;
            if (chosenServerIndex >= 0)
            {
                var listOfDatabaseNames = broker.SelectSqlDatabasesNames(chosenServerIndex, 0);
                if (listOfDatabaseNames != null && listOfDatabaseNames.Count != 0)
                {
                    cmb_Database.DataSource = listOfDatabaseNames;
                }
                else
                {
                    lbl_Info.ForeColor = Color.Red;
                    lbl_Info.Text = "Cannot connect to a Sql Server";
                }
            }
        }

        /// <summary>
        /// Reads names of all available tables in a chosen database and displays them in a combobox. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_Database_SelectedValueChanged(object sender, EventArgs e)
        {
            int chosenDatabaseIndex = ((ComboBox)sender).SelectedIndex;
            int chosenServerIndex = cmb_Server.SelectedIndex;
            if (chosenDatabaseIndex >= 0 && chosenServerIndex >= 0)
            {

                cmb_Table.DataSource = broker.SelectSqlTablesNames(chosenServerIndex, chosenDatabaseIndex);
                if (cmb_Table.Items.Count == 0)
                {
                    cmb_Table.DataSource = null;
                    cmb_Table.Items.Clear();
                    dgv_TableContent.DataSource = null;
                    lbl_Info.Text = $"Cannot connect to {cmb_Database.SelectedItem.ToString()} database.";
                }
            }
        }

        /// <summary>
        /// Reads a chosen table and displays it on a DataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_Table_SelectedValueChanged(object sender, EventArgs e)
        {
            int chosenTableIndex = ((ComboBox)sender).SelectedIndex;
            int chosenDatabaseIndex = cmb_Database.SelectedIndex;
            if (chosenTableIndex >= 0 && chosenDatabaseIndex >= 0)
            {
                dgv_TableContent.DataSource = broker.ReadSqlTableContent(chosenDatabaseIndex, chosenTableIndex);
                if (dgv_TableContent.DataSource == null)
                {
                    lbl_Info.Text = $"Cannot read the {cmb_Table.SelectedItem.ToString()} table.";
                }
            }
        }

        /// <summary>
        /// Refresh a table content displays on DataGridView. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            int chosenTableIndex = cmb_Table.SelectedIndex;
            int chosenDatabaseIndex = cmb_Database.SelectedIndex;
            if (chosenTableIndex >= 0 && chosenDatabaseIndex >= 0)
            {
                dgv_TableContent.DataSource = broker.ReadSqlTableContent(chosenDatabaseIndex, chosenTableIndex);
            }
        }
    }
}

