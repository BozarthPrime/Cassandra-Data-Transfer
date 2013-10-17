using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Cassandra;
using Cassandra.Data;

namespace CassandraDataTransfer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        public static void TransferData(string sourceSvr, string sourceKeySp, string sourceQry, string destSvr, string destKeySp, string destClmFam)
        {
            List<dynamic> sourceData;
            bool gotSourceData;
            GetSourceData(sourceSvr, sourceKeySp, sourceQry, out gotSourceData, out sourceData);

            if (gotSourceData)
                InsertIntoDest(destSvr, destKeySp, destClmFam, sourceData);
        }

        private static void GetSourceData(string server, string keyspace, string query, out bool gotSourceData, out List<dynamic> sourceData)
        {
            sourceData = new List<dynamic>();
            gotSourceData = true;

            try
            {
                CqlConnection srcConn = new CqlConnection("Contact Points=" + server, server);
                CqlCommand srcCmd = new CqlCommand();
                srcConn.Open();
                srcConn.ChangeDatabase(keyspace);
                srcCmd.Connection = srcConn;

                srcCmd.CommandType = CommandType.Text;
                srcCmd.CommandText = query;

                sourceData = srcCmd.ExecuteDynamics();

                srcCmd.Connection.Close();

                //cleanup
                srcCmd.Connection.Close();
                srcCmd.Connection.Dispose();
                srcCmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting source data: \r\n" + ex.Message);
                gotSourceData = false;
            }
        }

        private static void InsertIntoDest(string server, string keyspace, string columnFamily, List<dynamic> sourceData)
        {
            try
            {
                CqlConnection destConn = new CqlConnection("Contact Points=" + server, server);
                CqlCommand destCmd = new CqlCommand();

                destConn.Open();
                destConn.ChangeDatabase(keyspace);
                destCmd.Connection = destConn;

                destCmd.InsertDynamicList(sourceData, columnFamily);

                //cleanup
                destCmd.Connection.Close();
                destCmd.Connection.Dispose();
                destCmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error writting to destination: \r\n" + ex.Message);
            }
        }
    }
}
