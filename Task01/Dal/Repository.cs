using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Task01.Models;

namespace Task01.Dal
{
    static class Repository
    {
        #region constants
        private const string ConnectionString = "Server={0};Uid={1};Pwd={2}";
        private const string UseDatabase = "{0};Database={1}";
        private const string SelectDatabases = "SELECT name As Name FROM sys.databases";
        private const string SelectEntities = "SELECT TABLE_SCHEMA AS [Schema], TABLE_NAME AS Name FROM {0}.INFORMATION_SCHEMA.{1}S";
        private const string SelectProcedures = "SELECT SPECIFIC_NAME as Name, ROUTINE_DEFINITION as Definition FROM {0}.INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = 'PROCEDURE'";
        private const string SelectColumns = "SELECT COLUMN_NAME as Name, DATA_TYPE as DataType FROM {0}.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{1}'";
        private const string SelectProcedureParameters = "SELECT PARAMETER_NAME as Name, PARAMETER_MODE as Mode, DATA_TYPE as DataType FROM {0}.INFORMATION_SCHEMA.PARAMETERS WHERE SPECIFIC_NAME='{1}'";
        private const string SelectQuery = "SELECT * FROM {0}.{1}.{2}";
        private const string SelectViews = "SELECT TABLE_NAME as Name, VIEW_DEFINITION as Definition FROM {0}.INFORMATION_SCHEMA.VIEWS";
        #endregion

        private static string? cs;
        internal static void Login(string server, string username, string password)
        {
            using SqlConnection con = new SqlConnection(
                string.Format(ConnectionString, server, username, password));
            cs = con.ConnectionString;
            con.Open();
        }

        internal static SqlConnection GetConnection(Database database)
        {
            SqlConnection con = new(string.Format(UseDatabase, cs, database.Name));
            con.Open();
            return con;
        }

        internal static IEnumerable<Database> GetDatabases()
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = SelectDatabases;
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                yield return new Database()
                {
                    Name = dr[nameof(Database.Name)].ToString()
                };
            }
        }

        internal static IEnumerable<DBView> GetViews(Database database)
        {
            using SqlConnection con = new(string.Format(UseDatabase, cs, database.Name));
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = string.Format(SelectViews, database.Name);
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                yield return new DBView()
                {
                    Name = dr[nameof(DBView.Name)].ToString(),
                    Definition = dr[nameof(DBView.Definition)].ToString()
                };
            }
        }
        
        internal static IEnumerable<Procedure> GetProcedures(Database database)
        {
            using SqlConnection con = new(string.Format(UseDatabase, cs, database.Name));
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = string.Format(SelectProcedures, database.Name);
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                yield return new Procedure()
                {
                    Name = dr[nameof(Procedure.Name)].ToString(),
                    Definition = dr[nameof(Procedure.Definition)].ToString()
                };
            }
        }

        internal static IEnumerable<Parameter> GetParameters(Database database, Procedure procedure)
        {
            using SqlConnection con = new(string.Format(UseDatabase, cs, database.Name));
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = string.Format(SelectProcedureParameters, database.Name, procedure.Name);
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                yield return new Parameter()
                {
                    Name = dr[nameof(Parameter.Name)].ToString(),
                    Mode = dr[nameof(Parameter.Mode)].ToString(),
                    DataType = dr[nameof(Parameter.DataType)].ToString()
                };
            }
        }

        internal static IEnumerable<Table> GetTables(Database database)
        {
            using SqlConnection con = new(string.Format(UseDatabase, cs, database.Name));
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = string.Format(SelectEntities, database.Name, "TABLE");
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                yield return new Table()
                {
                    Schema = dr[nameof(Table.Schema)].ToString(),
                    Name = dr[nameof(Table.Name)].ToString()
                };
            }
        }

        internal static IEnumerable<Column> GetColumns(Database database, Table table)
        {
            using SqlConnection con = new(string.Format(UseDatabase, cs, database.Name));
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = string.Format(SelectColumns, database.Name, table.Name);
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                yield return new Column()
                {
                    Name = dr[nameof(Column.Name)].ToString(),
                    DataType = dr[nameof(Column.DataType)].ToString()
                };
            }
        }

        // Won't lazy load
        internal static IEnumerable<Result> GetQuery(Database database, Table table)
        {
            using SqlConnection con = new(string.Format(UseDatabase, cs, database.Name));
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = string.Format(SelectQuery, database.Name, table.Schema, table.Name);
            using SqlDataReader dr = cmd.ExecuteReader();

            List<Result> list = new List<Result>();


            while (dr.Read())
            {
                object[] values = new object[dr.FieldCount];
                dr.GetValues(values);

                list.Add(new Result()
                {
                    Values = values
                });
            }

            return list;
        }
    }
}
