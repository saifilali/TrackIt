namespace Migration
{
    partial class Form2
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
            this.txtSourceFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDo = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lblNotDeleted = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblFoundInFileSystem = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDeletedCount = new System.Windows.Forms.Label();
            this.lblTotalFiles = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblConnection = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSourceFolder
            // 
            this.txtSourceFolder.Location = new System.Drawing.Point(94, 46);
            this.txtSourceFolder.Name = "txtSourceFolder";
            this.txtSourceFolder.Size = new System.Drawing.Size(1071, 20);
            this.txtSourceFolder.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Source Folder :";
            // 
            // btnDo
            // 
            this.btnDo.Location = new System.Drawing.Point(94, 12);
            this.btnDo.Name = "btnDo";
            this.btnDo.Size = new System.Drawing.Size(117, 28);
            this.btnDo.TabIndex = 2;
            this.btnDo.Text = "Start";
            this.btnDo.UseVisualStyleBackColor = true;
            this.btnDo.Click += new System.EventHandler(this.btnDo_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(94, 72);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(1071, 420);
            this.listBox1.TabIndex = 3;
            // 
            // lblNotDeleted
            // 
            this.lblNotDeleted.AutoSize = true;
            this.lblNotDeleted.Location = new System.Drawing.Point(525, 517);
            this.lblNotDeleted.Name = "lblNotDeleted";
            this.lblNotDeleted.Size = new System.Drawing.Size(13, 13);
            this.lblNotDeleted.TabIndex = 27;
            this.lblNotDeleted.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(460, 517);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "NotDeleted :";
            // 
            // lblFoundInFileSystem
            // 
            this.lblFoundInFileSystem.AutoSize = true;
            this.lblFoundInFileSystem.Location = new System.Drawing.Point(395, 543);
            this.lblFoundInFileSystem.Name = "lblFoundInFileSystem";
            this.lblFoundInFileSystem.Size = new System.Drawing.Size(13, 13);
            this.lblFoundInFileSystem.TabIndex = 25;
            this.lblFoundInFileSystem.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(281, 543);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Found In FileSystem :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(281, 518);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Deleted :";
            // 
            // lblDeletedCount
            // 
            this.lblDeletedCount.AutoSize = true;
            this.lblDeletedCount.Location = new System.Drawing.Point(395, 518);
            this.lblDeletedCount.Name = "lblDeletedCount";
            this.lblDeletedCount.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedCount.TabIndex = 22;
            this.lblDeletedCount.Text = "0";
            // 
            // lblTotalFiles
            // 
            this.lblTotalFiles.AutoSize = true;
            this.lblTotalFiles.Location = new System.Drawing.Point(213, 518);
            this.lblTotalFiles.Name = "lblTotalFiles";
            this.lblTotalFiles.Size = new System.Drawing.Size(13, 13);
            this.lblTotalFiles.TabIndex = 21;
            this.lblTotalFiles.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(136, 544);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 20;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(133, 542);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(13, 13);
            this.lblCount.TabIndex = 19;
            this.lblCount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 542);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = " Count :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 517);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Total Files in the Folder :";
            // 
            // lblConnection
            // 
            this.lblConnection.AutoSize = true;
            this.lblConnection.Location = new System.Drawing.Point(244, 20);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(35, 13);
            this.lblConnection.TabIndex = 28;
            this.lblConnection.Text = "label8";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 579);
            this.Controls.Add(this.lblConnection);
            this.Controls.Add(this.lblNotDeleted);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblFoundInFileSystem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblDeletedCount);
            this.Controls.Add(this.lblTotalFiles);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnDo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSourceFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delet Unused Records From Database";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSourceFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDo;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lblNotDeleted;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblFoundInFileSystem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDeletedCount;
        private System.Windows.Forms.Label lblTotalFiles;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblConnection;
    }
}