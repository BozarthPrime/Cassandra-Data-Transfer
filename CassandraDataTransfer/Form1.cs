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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


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
                ProgressBar.Visible = true;

                TransferResultsInfo res = Program.TransferData(SourceSvr.Text, SourceKeySp.Text, SourceQry.Text, DestSvr.Text, DestKeySp.Text, DestClmFam.Text);

                ProgressBar.Visible = false;

                MessageBox.Show(res.Message);
            }
            else
            {
                MessageBox.Show("All fields are required.");
            }

            StartBtn.Enabled = true;
            
        }
    }
}
