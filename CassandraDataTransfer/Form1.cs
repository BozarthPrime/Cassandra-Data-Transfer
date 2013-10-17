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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cassandra;
using Cassandra.Data;

namespace CassandraDataTransfer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            StartBtn.Enabled = false;

            if (!String.IsNullOrWhiteSpace(SourceSvr.Text) &&
                !String.IsNullOrWhiteSpace(SourceKeySp.Text) &&
                !String.IsNullOrWhiteSpace(SourceQry.Text) &&
                !String.IsNullOrWhiteSpace(DestSvr.Text) &&
                !String.IsNullOrWhiteSpace(DestClmFam.Text) &&
                !String.IsNullOrWhiteSpace(DestKeySp.Text))
            {
                ProcessingLbl.Visible = true;

                List<dynamic> sourceData;
                bool gotSourceData;
                GetSourceData(SourceSvr.Text, SourceKeySp.Text, SourceQry.Text, out gotSourceData, out sourceData);

                if (gotSourceData)
                    InsertIntoDest(DestSvr.Text, DestKeySp.Text, DestClmFam.Text, sourceData);
            }
            else
            {
                MessageBox.Show("All fields are required.");
            }

            ProcessingLbl.Visible = false;
            StartBtn.Enabled = true;
            
        }

        private void GetSourceData(string server, string keyspace, string query, out bool gotSourceData, out List<dynamic> sourceData)
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

        private void InsertIntoDest(string server, string keyspace, string columnFamily, List<dynamic> sourceData)
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
