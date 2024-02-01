using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task01.Dal;
using Task01.Models;

namespace Task01.Forms
{
    public partial class MainForm : Form
    {
        private List<Database> databases;
        private DataTable dataTable;

        private enum TagType
        {
            Databases, Tables, Views, Procedures
        }

        public MainForm()
        {
            InitializeComponent();
            databases = new List<Database>(Repository.GetDatabases());
            dataTable = new DataTable();
            dgvResults.DataSource = dataTable;

            InitTreeView();
            ClearForm();
        }



        private void InitTreeView()
        {
            var databaseNode = new TreeNode(TagType.Databases.ToString(), new[] { new TreeNode() }) { Tag = TagType.Databases };
            tvServer.Nodes.Add(databaseNode);
        }

        private Database? database; // selected
        private List<Table> tables;
        private Table? table; // selected
        private List<Column> columns;
        private List<Procedure> procedures;
        private List<DBView> views;

        private void tvServer_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e is null || databases is null)
            {
                return;
            }
            ClearForm();
            tvServer.BeginUpdate();
            switch (e.Node)
            {
                case { Tag: TagType.Databases }:
                    e.Node.Nodes.Clear();

                    databases
                        .ForEach(db => e.Node.Nodes.Add(
                            new TreeNode(db.ToString(), new[] { new TreeNode() }) { Tag = db }
                            ));
                    break;

                case { Tag: Database db }:
                    database = db;
                    e.Node.Nodes.Clear();

                    e.Node.Nodes.Add(new TreeNode(TagType.Tables.ToString(), new[] { new TreeNode() }) { Tag = TagType.Tables });
                    e.Node.Nodes.Add(new TreeNode(TagType.Views.ToString(), new[] { new TreeNode() }) { Tag = TagType.Views });
                    e.Node.Nodes.Add(new TreeNode(TagType.Procedures.ToString(), new[] { new TreeNode() }) { Tag = TagType.Procedures });

                    break;

                case { Tag: TagType.Tables }:
                    e.Node.Nodes.Clear();
                    tables = new List<Table>(Repository.GetTables(database));

                    tables.ForEach(tb => e.Node.Nodes.Add(
                            new TreeNode(tb.ToString(), new[] { new TreeNode() }) { Tag = tb }
                        ));

                    break;

                case { Tag: Table tb }:
                    e.Node.Nodes.Clear();
                    table = tb;
                    columns = new List<Column>(Repository.GetColumns(database, table));

                    dataTable.Clear();
                    dataTable.Rows.Clear();
                    dataTable.Columns.Clear();

                    columns.ForEach(col =>
                    {
                        e.Node.Nodes.Add(new TreeNode(col.ToString()) { });
                        dataTable.Columns.Add(col.Name, typeof(string));
                    });

                    List<Result> results = new List<Result>(Repository.GetQuery(database, table));
                    results.ForEach(r =>
                    {
                        dataTable.Rows.Add(r.Values);
                    });

                    break;
                case { Tag: TagType.Procedures }:
                    e.Node.Nodes.Clear();
                    procedures = new List<Procedure>(Repository.GetProcedures(database));

                    procedures.ForEach(p =>
                    {
                        e.Node.Nodes.Add(new TreeNode(p.ToString(), new[] { new TreeNode() }) { Tag = p });
                    });

                    break;

                case { Tag: Procedure proc }:
                    e.Node.Nodes.Clear();
                    tbContent.Text = proc.Definition;

                    dataTable.Clear();
                    dataTable.Rows.Clear();
                    dataTable.Columns.Clear();

                    dataTable.Columns.Add(nameof(Parameter.Name));
                    dataTable.Columns.Add(nameof(Parameter.Mode));
                    dataTable.Columns.Add(nameof(Parameter.DataType));

                    List<Parameter> parameters = new List<Parameter>(Repository.GetParameters(database, proc));

                    parameters.ForEach(p =>
                    {
                        dataTable.Rows.Add(new object[] { p.Name, p.Mode, p.DataType });
                    });

                    break;

                case { Tag: TagType.Views }:
                    e.Node.Nodes.Clear();

                    views = new List<DBView>(Repository.GetViews(database));
                    views.ForEach(v =>
                    {
                        e.Node.Nodes.Add(new TreeNode(v.ToString(), new[] { new TreeNode() }) { Tag = v });
                    });

                    break;

                case { Tag: DBView view }:
                    e.Node.Nodes.Clear();

                    tbContent.Text = view.Definition;

                    break;

            }
            tvServer.EndUpdate();

        }

        private void ClearForm()
        {
            tbContent.Text = string.Empty;

            dataTable.Clear();
            dataTable.Rows.Clear();
            dataTable.Columns.Clear();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tsbRun_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbContent.Text))
            {
                MessageBox.Show("Nothing to run");
                return;
            }

            if (database == null)
            {
                MessageBox.Show("Please select a database.");
                return;
            }

            using SqlConnection connection = Repository.GetConnection(database);
            using SqlCommand command = connection.CreateCommand();
            command.CommandText = tbContent.Text;
            using SqlDataReader dr = command.ExecuteReader();

            dataTable.Clear();
            dataTable.Rows.Clear();
            dataTable.Columns.Clear();

            if (!dr.HasRows) return;

            dr.Read();
            List<DbColumn> columns = new List<DbColumn>(dr.GetColumnSchema());
            columns.ForEach(col =>
            {
                dataTable.Columns.Add(col.ColumnName, typeof(string));
            });

            do
            {
                object[] values = new object[dr.FieldCount];
                dr.GetValues(values);
                dataTable.Rows.Add(values);
            } while (dr.Read());
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {

        }
    }
}
