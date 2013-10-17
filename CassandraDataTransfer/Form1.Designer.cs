namespace CassandraDataTransfer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SourceQry = new System.Windows.Forms.RichTextBox();
            this.SourceSvr = new System.Windows.Forms.TextBox();
            this.SourceSvrLbl = new System.Windows.Forms.Label();
            this.SourceQryLbl = new System.Windows.Forms.Label();
            this.SourceBox = new System.Windows.Forms.GroupBox();
            this.SourceKeySp = new System.Windows.Forms.TextBox();
            this.SourceKeySpLbl = new System.Windows.Forms.Label();
            this.DestinationBox = new System.Windows.Forms.GroupBox();
            this.DestClmFam = new System.Windows.Forms.TextBox();
            this.DestClmFamLbl = new System.Windows.Forms.Label();
            this.DestKeySp = new System.Windows.Forms.TextBox();
            this.DestKeySpLbl = new System.Windows.Forms.Label();
            this.DestSvr = new System.Windows.Forms.TextBox();
            this.DestSvrLbl = new System.Windows.Forms.Label();
            this.StartBtn = new System.Windows.Forms.Button();
            this.ProcessingLbl = new System.Windows.Forms.Label();
            this.SourceBox.SuspendLayout();
            this.DestinationBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SourceQry
            // 
            this.SourceQry.Location = new System.Drawing.Point(9, 71);
            this.SourceQry.Name = "SourceQry";
            this.SourceQry.Size = new System.Drawing.Size(407, 117);
            this.SourceQry.TabIndex = 3;
            this.SourceQry.Text = "";
            // 
            // SourceSvr
            // 
            this.SourceSvr.Location = new System.Drawing.Point(9, 32);
            this.SourceSvr.Name = "SourceSvr";
            this.SourceSvr.Size = new System.Drawing.Size(179, 20);
            this.SourceSvr.TabIndex = 1;
            // 
            // SourceSvrLbl
            // 
            this.SourceSvrLbl.AutoSize = true;
            this.SourceSvrLbl.Location = new System.Drawing.Point(6, 16);
            this.SourceSvrLbl.Name = "SourceSvrLbl";
            this.SourceSvrLbl.Size = new System.Drawing.Size(41, 13);
            this.SourceSvrLbl.TabIndex = 2;
            this.SourceSvrLbl.Text = "Server:";
            // 
            // SourceQryLbl
            // 
            this.SourceQryLbl.AutoSize = true;
            this.SourceQryLbl.Location = new System.Drawing.Point(6, 55);
            this.SourceQryLbl.Name = "SourceQryLbl";
            this.SourceQryLbl.Size = new System.Drawing.Size(38, 13);
            this.SourceQryLbl.TabIndex = 3;
            this.SourceQryLbl.Text = "Query:";
            // 
            // SourceBox
            // 
            this.SourceBox.Controls.Add(this.SourceKeySp);
            this.SourceBox.Controls.Add(this.SourceKeySpLbl);
            this.SourceBox.Controls.Add(this.SourceSvr);
            this.SourceBox.Controls.Add(this.SourceQry);
            this.SourceBox.Controls.Add(this.SourceQryLbl);
            this.SourceBox.Controls.Add(this.SourceSvrLbl);
            this.SourceBox.Location = new System.Drawing.Point(12, 12);
            this.SourceBox.Name = "SourceBox";
            this.SourceBox.Size = new System.Drawing.Size(422, 196);
            this.SourceBox.TabIndex = 4;
            this.SourceBox.TabStop = false;
            this.SourceBox.Text = "Source";
            // 
            // SourceKeySp
            // 
            this.SourceKeySp.Location = new System.Drawing.Point(194, 31);
            this.SourceKeySp.Name = "SourceKeySp";
            this.SourceKeySp.Size = new System.Drawing.Size(222, 20);
            this.SourceKeySp.TabIndex = 2;
            // 
            // SourceKeySpLbl
            // 
            this.SourceKeySpLbl.AutoSize = true;
            this.SourceKeySpLbl.Location = new System.Drawing.Point(191, 16);
            this.SourceKeySpLbl.Name = "SourceKeySpLbl";
            this.SourceKeySpLbl.Size = new System.Drawing.Size(57, 13);
            this.SourceKeySpLbl.TabIndex = 5;
            this.SourceKeySpLbl.Text = "Keyspace:";
            // 
            // DestinationBox
            // 
            this.DestinationBox.Controls.Add(this.DestClmFam);
            this.DestinationBox.Controls.Add(this.DestClmFamLbl);
            this.DestinationBox.Controls.Add(this.DestKeySp);
            this.DestinationBox.Controls.Add(this.DestKeySpLbl);
            this.DestinationBox.Controls.Add(this.DestSvr);
            this.DestinationBox.Controls.Add(this.DestSvrLbl);
            this.DestinationBox.Location = new System.Drawing.Point(440, 12);
            this.DestinationBox.Name = "DestinationBox";
            this.DestinationBox.Size = new System.Drawing.Size(221, 196);
            this.DestinationBox.TabIndex = 5;
            this.DestinationBox.TabStop = false;
            this.DestinationBox.Text = "Destination";
            // 
            // DestClmFam
            // 
            this.DestClmFam.Location = new System.Drawing.Point(6, 109);
            this.DestClmFam.Name = "DestClmFam";
            this.DestClmFam.Size = new System.Drawing.Size(209, 20);
            this.DestClmFam.TabIndex = 6;
            // 
            // DestClmFamLbl
            // 
            this.DestClmFamLbl.AutoSize = true;
            this.DestClmFamLbl.Location = new System.Drawing.Point(7, 93);
            this.DestClmFamLbl.Name = "DestClmFamLbl";
            this.DestClmFamLbl.Size = new System.Drawing.Size(77, 13);
            this.DestClmFamLbl.TabIndex = 4;
            this.DestClmFamLbl.Text = "Column Family:";
            // 
            // DestKeySp
            // 
            this.DestKeySp.Location = new System.Drawing.Point(7, 70);
            this.DestKeySp.Name = "DestKeySp";
            this.DestKeySp.Size = new System.Drawing.Size(208, 20);
            this.DestKeySp.TabIndex = 5;
            // 
            // DestKeySpLbl
            // 
            this.DestKeySpLbl.AutoSize = true;
            this.DestKeySpLbl.Location = new System.Drawing.Point(7, 54);
            this.DestKeySpLbl.Name = "DestKeySpLbl";
            this.DestKeySpLbl.Size = new System.Drawing.Size(57, 13);
            this.DestKeySpLbl.TabIndex = 2;
            this.DestKeySpLbl.Text = "Keyspace:";
            // 
            // DestSvr
            // 
            this.DestSvr.Location = new System.Drawing.Point(7, 31);
            this.DestSvr.Name = "DestSvr";
            this.DestSvr.Size = new System.Drawing.Size(208, 20);
            this.DestSvr.TabIndex = 4;
            // 
            // DestSvrLbl
            // 
            this.DestSvrLbl.AutoSize = true;
            this.DestSvrLbl.Location = new System.Drawing.Point(7, 15);
            this.DestSvrLbl.Name = "DestSvrLbl";
            this.DestSvrLbl.Size = new System.Drawing.Size(41, 13);
            this.DestSvrLbl.TabIndex = 0;
            this.DestSvrLbl.Text = "Server:";
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(579, 215);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(75, 23);
            this.StartBtn.TabIndex = 7;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // ProcessingLbl
            // 
            this.ProcessingLbl.AutoSize = true;
            this.ProcessingLbl.Location = new System.Drawing.Point(505, 220);
            this.ProcessingLbl.Name = "ProcessingLbl";
            this.ProcessingLbl.Size = new System.Drawing.Size(68, 13);
            this.ProcessingLbl.TabIndex = 7;
            this.ProcessingLbl.Text = "Processing...";
            this.ProcessingLbl.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 251);
            this.Controls.Add(this.ProcessingLbl);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.DestinationBox);
            this.Controls.Add(this.SourceBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Cassandra Data Transfer";
            this.SourceBox.ResumeLayout(false);
            this.SourceBox.PerformLayout();
            this.DestinationBox.ResumeLayout(false);
            this.DestinationBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox SourceQry;
        private System.Windows.Forms.TextBox SourceSvr;
        private System.Windows.Forms.Label SourceSvrLbl;
        private System.Windows.Forms.Label SourceQryLbl;
        private System.Windows.Forms.GroupBox SourceBox;
        private System.Windows.Forms.TextBox SourceKeySp;
        private System.Windows.Forms.Label SourceKeySpLbl;
        private System.Windows.Forms.GroupBox DestinationBox;
        private System.Windows.Forms.TextBox DestClmFam;
        private System.Windows.Forms.Label DestClmFamLbl;
        private System.Windows.Forms.TextBox DestKeySp;
        private System.Windows.Forms.Label DestKeySpLbl;
        private System.Windows.Forms.TextBox DestSvr;
        private System.Windows.Forms.Label DestSvrLbl;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Label ProcessingLbl;
    }
}

