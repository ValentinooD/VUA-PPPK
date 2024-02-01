using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Task04.Models;

namespace Task04.Dal
{
    public class Repository
    {
        private static readonly string cs =
            ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public static IList<StorageBlob> GetPictures()
        {
            IList<StorageBlob> list = new List<StorageBlob>();

            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr[nameof(StorageBlob.IDFile)].GetType() != typeof(DBNull)) {
                    StorageBlob blob = ReadStorageBlob(dr);

                    if (dr[nameof(StorageBlob.IDDirectory)].GetType() != typeof(DBNull)) {
                        blob.IDDirectory = (int)dr[nameof(StorageBlob.IDDirectory)];
                        blob.Directory = new BlobDirectory()
                        {
                            IDDirectory = blob.IDDirectory,
                            Name = (string)dr[nameof(BlobDirectory.Name)]
                        };
                    }

                    list.Add(blob);
                }
            }

            return list;
        }

        public static IList<BlobDirectory> GetDirectories()
        {
            IList<BlobDirectory> list = new List<BlobDirectory>();

            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(new BlobDirectory()
                {
                    IDDirectory = (int)dr[nameof(BlobDirectory.IDDirectory)],
                    Name = (string)dr[nameof(BlobDirectory.Name)]
                });
            }

            return list;
        }

        public static void AddPicture(StorageBlob blob)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(StorageBlob.FileName), blob.FileName);
            cmd.Parameters.AddWithValue(nameof(StorageBlob.ContentType), blob.ContentType);
            cmd.Parameters.AddWithValue(nameof(StorageBlob.DateCreated), blob.DateCreated);
            cmd.Parameters.Add(
                new SqlParameter(nameof(StorageBlob.Data), System.Data.SqlDbType.Binary, blob.Data!.Length)
                {
                    Value = blob.Data
                });
            var id = new SqlParameter(nameof(StorageBlob.IDFile), System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };
            cmd.Parameters.Add(id);
            cmd.ExecuteNonQuery();
            blob.IDFile = (int)id.Value;
        }

        private static StorageBlob ReadStorageBlob(SqlDataReader dr)
            => new()
            {
                IDFile = (int)dr[nameof(StorageBlob.IDFile)],
                FileName = (string)dr[nameof(StorageBlob.FileName)],
                ContentType = (string)dr[nameof(StorageBlob.ContentType)],
                DateCreated = (DateTime)dr[nameof(StorageBlob.DateCreated)],
                Data = (byte[])dr[nameof(StorageBlob.Data)],
            };

        public static void CreatePicture(string dir, StorageBlob blob)
        {
            BlobDirectory directory = AddDirectory(dir);
            AddPicture(blob);
            InsertIntoDirectory(directory, blob);
        }

        private static void InsertIntoDirectory(BlobDirectory directory, StorageBlob blob)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(StorageBlob.IDFile), blob.IDFile);
            cmd.Parameters.AddWithValue(nameof(BlobDirectory.IDDirectory), directory.IDDirectory);
            cmd.ExecuteNonQuery();
            blob.IDDirectory = directory.IDDirectory;
        }

        public static BlobDirectory AddDirectory(string dir)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(BlobDirectory.Name), dir);
            var id = new SqlParameter(nameof(BlobDirectory.IDDirectory), System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };
            cmd.Parameters.Add(id);
            cmd.ExecuteNonQuery();

            return new()
            {
                IDDirectory = (int)id.Value,
                Name = dir
            };
        }

        public static void DeletePicture(StorageBlob blob)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(StorageBlob.IDFile), blob.IDFile);
            cmd.ExecuteNonQuery();
        }
    }
}
