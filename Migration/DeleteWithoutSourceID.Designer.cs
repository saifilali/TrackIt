namespace Migration
{
    partial class DeleteWithoutSourceID
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
            this.lblConnection = new System.Windows.Forms.Label();
            this.btnSatart = new System.Windows.Forms.Button();
            this.txtSourceFolder = new System.Windows.Forms.TextBox();
            this.lblFileTableName = new System.Windows.Forms.Label();
            this.lblNoDeletedFromDB = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lblUpdatedCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalFiles = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.lblNotDeletedFromFileSystem = new System.Windows.Forms.Label();
            this.lblDeletedFromDB = new System.Windows.Forms.Label();
            this.lblDeletedFromFileSystem = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblConnection
            // 
            this.lblConnection.AutoSize = true;
            this.lblConnection.Location = new System.Drawing.Point(12, 9);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(97, 13);
            this.lblConnection.TabIndex = 36;
            this.lblConnection.Text = "Connection String :";
            // 
            // btnSatart
            // 
            this.btnSatart.Location = new System.Drawing.Point(711, 31);
            this.btnSatart.Name = "btnSatart";
            this.btnSatart.Size = new System.Drawing.Size(88, 28);
            this.btnSatart.TabIndex = 35;
            this.btnSatart.Text = "Start";
            this.btnSatart.UseVisualStyleBackColor = true;
            this.btnSatart.Click += new System.EventHandler(this.btnSatart_Click);
            // 
            // txtSourceFolder
            // 
            this.txtSourceFolder.Location = new System.Drawing.Point(102, 36);
            this.txtSourceFolder.Name = "txtSourceFolder";
            this.txtSourceFolder.Size = new System.Drawing.Size(603, 20);
            this.txtSourceFolder.TabIndex = 34;
            // 
            // lblFileTableName
            // 
            this.lblFileTableName.AutoSize = true;
            this.lblFileTableName.Location = new System.Drawing.Point(12, 39);
            this.lblFileTableName.Name = "lblFileTableName";
            this.lblFileTableName.Size = new System.Drawing.Size(79, 13);
            this.lblFileTableName.TabIndex = 33;
            this.lblFileTableName.Text = "Source Folder :";
            // 
            // lblNoDeletedFromDB
            // 
            this.lblNoDeletedFromDB.AutoSize = true;
            this.lblNoDeletedFromDB.Location = new System.Drawing.Point(564, 647);
            this.lblNoDeletedFromDB.Name = "lblNoDeletedFromDB";
            this.lblNoDeletedFromDB.Size = new System.Drawing.Size(13, 13);
            this.lblNoDeletedFromDB.TabIndex = 45;
            this.lblNoDeletedFromDB.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(423, 645);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 44;
            this.label7.Text = "NotDeletedFromDB :";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(244, 646);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(88, 13);
            this.lbl1.TabIndex = 43;
            this.lbl1.Text = "DeletedFromDB :";
            // 
            // lblUpdatedCount
            // 
            this.lblUpdatedCount.AutoSize = true;
            this.lblUpdatedCount.Location = new System.Drawing.Point(304, 646);
            this.lblUpdatedCount.Name = "lblUpdatedCount";
            this.lblUpdatedCount.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedCount.TabIndex = 42;
            this.lblUpdatedCount.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 674);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 41;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(55, 675);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(13, 13);
            this.lblCount.TabIndex = 40;
            this.lblCount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 674);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = " Count :";
            // 
            // lblTotalFiles
            // 
            this.lblTotalFiles.AutoSize = true;
            this.lblTotalFiles.Location = new System.Drawing.Point(134, 647);
            this.lblTotalFiles.Name = "lblTotalFiles";
            this.lblTotalFiles.Size = new System.Drawing.Size(13, 13);
            this.lblTotalFiles.TabIndex = 38;
            this.lblTotalFiles.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 646);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Total Files in FileTable :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 674);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "DeletedFromFileSystem :";
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Location = new System.Drawing.Point(423, 675);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(135, 13);
            this.lbl5.TabIndex = 47;
            this.lbl5.Text = "NotDeletedFromFileSytem :";
            // 
            // lblNotDeletedFromFileSystem
            // 
            this.lblNotDeletedFromFileSystem.AutoSize = true;
            this.lblNotDeletedFromFileSystem.Location = new System.Drawing.Point(564, 675);
            this.lblNotDeletedFromFileSystem.Name = "lblNotDeletedFromFileSystem";
            this.lblNotDeletedFromFileSystem.Size = new System.Drawing.Size(13, 13);
            this.lblNotDeletedFromFileSystem.TabIndex = 48;
            this.lblNotDeletedFromFileSystem.Text = "0";
            // 
            // lblDeletedFromDB
            // 
            this.lblDeletedFromDB.AutoSize = true;
            this.lblDeletedFromDB.Location = new System.Drawing.Point(338, 646);
            this.lblDeletedFromDB.Name = "lblDeletedFromDB";
            this.lblDeletedFromDB.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedFromDB.TabIndex = 49;
            this.lblDeletedFromDB.Text = "0";
            // 
            // lblDeletedFromFileSystem
            // 
            this.lblDeletedFromFileSystem.AutoSize = true;
            this.lblDeletedFromFileSystem.Location = new System.Drawing.Point(373, 675);
            this.lblDeletedFromFileSystem.Name = "lblDeletedFromFileSystem";
            this.lblDeletedFromFileSystem.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedFromFileSystem.TabIndex = 50;
            this.lblDeletedFromFileSystem.Text = "0";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(15, 77);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(1122, 524);
            this.listBox1.TabIndex = 51;
            // 
            // DeleteWithoutSourceID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 701);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lblDeletedFromFileSystem);
            this.Controls.Add(this.lblDeletedFromDB);
            this.Controls.Add(this.lblNotDeletedFromFileSystem);
            this.Controls.Add(this.lbl5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNoDeletedFromDB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.lblUpdatedCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTotalFiles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblConnection);
            this.Controls.Add(this.btnSatart);
            this.Controls.Add(this.txtSourceFolder);
            this.Controls.Add(this.lblFileTableName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DeleteWithoutSourceID";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delete Records Without Corresponding SourceId";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.Button btnSatart;
        private System.Windows.Forms.TextBox txtSourceFolder;
        private System.Windows.Forms.Label lblFileTableName;
        private System.Windows.Forms.Label lblNoDeletedFromDB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lblUpdatedCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalFiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.Label lblNotDeletedFromFileSystem;
        private System.Windows.Forms.Label lblDeletedFromDB;
        private System.Windows.Forms.Label lblDeletedFromFileSystem;
        private System.Windows.Forms.ListBox listBox1;
    }
}