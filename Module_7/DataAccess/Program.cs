using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DataAccess
{
    class Program
    {
        static string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AzureStorageEmulatorDb510;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        static void Main(string[] args)
        {
            ProviderClassen();

        }

        private static void ProviderClassen()
        {
            DbConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            con.Open();
            DbCommand comm = new SqlCommand();
            comm.Connection = con;
            comm.CommandText = "SELECT * FROM dbo.Blob";
            comm.CommandType = CommandType.Text;

            DbDataReader rdr = comm.ExecuteReader();
            List<Blob> blobs = new List<Blob>();
            while (rdr.Read())
            {
                Blob b = new Blob
                {
                    AccountName = rdr.GetString(0),
                    ContainerName = rdr.GetString(1),
                    BlobName = rdr.GetString(2),
                    BlobType = rdr.GetInt32(4),
                    CreationTime = rdr.GetDateTime(5)
                };
                blobs.Add(b);
            }

            foreach(Blob b in blobs)
            {
                Console.WriteLine($"{b.AccountName}, {b.BlobName}");
            }
            

            con.Close();
        }
    }
}
