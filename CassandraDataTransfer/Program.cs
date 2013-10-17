//Copyright 2013 TRICAST, inc.
//
//Licensed under the Apache License, Version 2.0 (the "License");
//you may not use this file except in compliance with the License.
//You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
//Unless required by applicable law or agreed to in writing, software
//distributed under the License is distributed on an "AS IS" BASIS,
//WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//See the License for the specific language governing permissions and
//limitations under the License. 

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

        /// <summary>
        /// Move the data specified from the source query to the destination column family
        /// </summary>
        /// <param name="sourceSvr">ip or the host name of the source database</param>
        /// <param name="sourceKeySp">name of the keyspace to use for the source query</param>
        /// <param name="sourceQry">query to get source data</param>
        /// <param name="destSvr">ip or the host name of the destination database</param>
        /// <param name="destKeySp">name of the keyspace to use for the destination insert</param>
        /// <param name="destClmFam">name of the column family to insert the source data into</param>
        public static void TransferData(string sourceSvr, string sourceKeySp, string sourceQry, string destSvr, string destKeySp, string destClmFam)
        {
            List<dynamic> sourceData;
            bool gotSourceData;
            GetSourceData(sourceSvr, sourceKeySp, sourceQry, out gotSourceData, out sourceData);

            if (gotSourceData)
                InsertIntoDest(destSvr, destKeySp, destClmFam, sourceData);
        }

        /// <summary>
        /// Run the provided query against the source database to get the data to be moved.
        /// </summary>
        /// <param name="server">ip or name of the source database</param>
        /// <param name="keyspace">name of the keyspace to use for the source query</param>
        /// <param name="query">query to get source data</param>
        /// <param name="gotSourceData">Data retrieved</param>
        /// <param name="sourceData">indicator of if an error was thrown</param>
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

        /// <summary>
        /// Insert retrived data into destination table
        /// </summary>
        /// <param name="server">ip or name of the destination database</param>
        /// <param name="keyspace">name of the keyspace to use for the insert</param>
        /// <param name="columnFamily">name of the column family for the insert</param>
        /// <param name="sourceData">data retrieved from the source</param>
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
