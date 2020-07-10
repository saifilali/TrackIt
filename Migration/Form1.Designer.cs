namespace Migration
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtSourceFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalFiles = new System.Windows.Forms.Label();
            this.lblDeletedCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFoundInDB = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblNotDeleted = new System.Windows.Forms.Label();
            this.lblConnection = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDeletedFilesFolder = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(127, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSourceFolder
            // 
            this.txtSourceFolder.Location = new System.Drawing.Point(127, 93);
            this.txtSourceFolder.Name = "txtSourceFolder";
            this.txtSourceFolder.Size = new System.Drawing.Size(1142, 20);
            this.txtSourceFolder.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "SourceFolder :";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(127, 119);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(1142, 355);
            this.listBox1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 493);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Total Files in the Folder :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 518);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = " Count :";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(166, 518);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(13, 13);
            this.lblCount.TabIndex = 8;
            this.lblCount.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(169, 520);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 9;
            // 
            // lblTotalFiles
            // 
            this.lblTotalFiles.AutoSize = true;
            this.lblTotalFiles.Location = new System.Drawing.Point(246, 494);
            this.lblTotalFiles.Name = "lblTotalFiles";
            this.lblTotalFiles.Size = new System.Drawing.Size(13, 13);
            this.lblTotalFiles.TabIndex = 10;
            this.lblTotalFiles.Text = "0";
            // 
            // lblDeletedCount
            // 
            this.lblDeletedCount.AutoSize = true;
            this.lblDeletedCount.Location = new System.Drawing.Point(399, 494);
            this.lblDeletedCount.Name = "lblDeletedCount";
            this.lblDeletedCount.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedCount.TabIndex = 11;
            this.lblDeletedCount.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(328, 494);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Deleted :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(328, 519);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Found In DB :";
            // 
            // lblFoundInDB
            // 
            this.lblFoundInDB.AutoSize = true;
            this.lblFoundInDB.Location = new System.Drawing.Point(399, 519);
            this.lblFoundInDB.Name = "lblFoundInDB";
            this.lblFoundInDB.Size = new System.Drawing.Size(13, 13);
            this.lblFoundInDB.TabIndex = 14;
            this.lblFoundInDB.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(493, 493);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "NotDeleted :";
            // 
            // lblNotDeleted
            // 
            this.lblNotDeleted.AutoSize = true;
            this.lblNotDeleted.Location = new System.Drawing.Point(558, 493);
            this.lblNotDeleted.Name = "lblNotDeleted";
            this.lblNotDeleted.Size = new System.Drawing.Size(13, 13);
            this.lblNotDeleted.TabIndex = 16;
            this.lblNotDeleted.Text = "0";
            // 
            // lblConnection
            // 
            this.lblConnection.AutoSize = true;
            this.lblConnection.Location = new System.Drawing.Point(314, 26);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(35, 13);
            this.lblConnection.TabIndex = 17;
            this.lblConnection.Text = "label8";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Deleterd Files Folder :";
            // 
            // txtDeletedFilesFolder
            // 
            this.txtDeletedFilesFolder.Location = new System.Drawing.Point(127, 64);
            this.txtDeletedFilesFolder.Name = "txtDeletedFilesFolder";
            this.txtDeletedFilesFolder.Size = new System.Drawing.Size(341, 20);
            this.txtDeletedFilesFolder.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 549);
            this.Controls.Add(this.txtDeletedFilesFolder);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblConnection);
            this.Controls.Add(this.lblNotDeleted);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblFoundInDB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblDeletedCount);
            this.Controls.Add(this.lblTotalFiles);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSourceFolder);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delete UnusedFiles From FileSystem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSourceFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotalFiles;
        private System.Windows.Forms.Label lblDeletedCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFoundInDB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblNotDeleted;
        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDeletedFilesFolder;
    }
}

