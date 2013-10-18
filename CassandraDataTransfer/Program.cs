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

/*
 * Author: Joseph Bozarth
 * Date Created: 10-16-2013
 * Description: This application makes use of the Datastax C# Appache Cassandra API
 *  and is meant to be used to transfer data between cassandra instances and/or tables.
 *  For example one might need to move data between a development and a production
 *  enviroment.
 *  
 *  The version of the Datastax api that is being used is a modified version. The current
 *  main branch does not support connecting to multiple databases but this was a simple
 *  fix that I implemented in a branch of the github. This source code can be found
 *  here: https://github.com/BozarthPrime/csharp-driver
 */

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
        public static TransferResultsInfo TransferData(string sourceSvr, string sourceKeySp, string sourceQry, string destSvr, string destKeySp, string destClmFam)
        {
            TransferResultsInfo info = new TransferResultsInfo(); 
            List<dynamic> sourceData;
            bool gotSourceData;
            GetSourceData(sourceSvr, sourceKeySp, sourceQry, info, out gotSourceData, out sourceData);

            if (gotSourceData)
            {
                InsertIntoDest(destSvr, destKeySp, destClmFam, sourceData, info);

                info.Message = string.Format("Sucess!\r\n\r\nSource Count: {0}\r\nOrigional Destination Count: {1}\r\nAfter Destination Count: {2}", 
                                    info.SourceCount, 
                                    info.OriginalDestCount, 
                                    info.AfterDestCount);
            }

            return info;
        }

        /// <summary>
        /// Run the provided query against the source database to get the data to be moved.
        /// </summary>
        /// <param name="server">ip or name of the source database</param>
        /// <param name="keyspace">name of the keyspace to use for the source query</param>
        /// <param name="query">query to get source data</param>
        /// <param name="gotSourceData">Data retrieved</param>
        /// <param name="sourceData">indicator of if an error was thrown</param>
        private static void GetSourceData(string server, string keyspace, string query, TransferResultsInfo info, out bool gotSourceData, out List<dynamic> sourceData)
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

                info.SourceCount = sourceData.Count;

                //cleanup
                srcCmd.Connection.Close();
                srcCmd.Connection.Dispose();
                srcCmd.Dispose();
            }
            catch (Exception ex)
            {
                info.Message = "Error getting source data: \r\n" + ex.Message;
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
        private static void InsertIntoDest(string server, string keyspace, string columnFamily, List<dynamic> sourceData, TransferResultsInfo info)
        {
            try
            {
                CqlConnection destConn = new CqlConnection("Contact Points=" + server, server);
                CqlCommand destCmd = new CqlCommand();

                destConn.Open();
                destConn.ChangeDatabase(keyspace);
                destCmd.Connection = destConn;

                destCmd.CommandText = "SELECT COUNT(*) FROM " + columnFamily;
                info.OriginalDestCount = Convert.ToInt32(destCmd.ExecuteScalar());

                destCmd.InsertDynamicList(sourceData, columnFamily);

                destCmd.CommandText = "SELECT COUNT(*) FROM " + columnFamily;
                info.AfterDestCount = Convert.ToInt32(destCmd.ExecuteScalar());

                //cleanup
                destCmd.Connection.Close();
                destCmd.Connection.Dispose();
                destCmd.Dispose();
            }
            catch (Exception ex)
            {
                info.Message = "Error writting to destination: \r\n" + ex.Message;
            }
        }
    }
}
