namespace Migration
{
    partial class FolderStructure
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
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblConnection = new System.Windows.Forms.Label();
            this.counterFilesWithoutConflicts = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.countertotalFilesProcessed = new System.Windows.Forms.Label();
            this.lbltotalFilesProcessed = new System.Windows.Forms.Label();
            this.AllFilesList = new System.Windows.Forms.ListView();
            this.AttachmentMasterID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GoodFilePathName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BadFilePathName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PathInDBBefore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PathInDBAfter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblFilesWithoutConflicts = new System.Windows.Forms.Label();
            this.lblFilesWithConflicts = new System.Windows.Forms.Label();
            this.counterFilesWithConflicts = new System.Windows.Forms.Label();
            this.counterTotalRecordsUpdatedInDb = new System.Windows.Forms.Label();
            this.lblTotalRecordsUpdatedInDb = new System.Windows.Forms.Label();
            this.lblFilesDeleted = new System.Windows.Forms.Label();
            this.counterFilesDeleted = new System.Windows.Forms.Label();
            this.counterFilesCopied = new System.Windows.Forms.Label();
            this.lblFilesCopied = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblLastFileProcessed = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.counterTotalFilesRemainingToProcessed = new System.Windows.Forms.Label();
            this.lblTotalFilesRemainingToProcessed = new System.Windows.Forms.Label();
            this.counterTotalFilesAlreadyProcessed = new System.Windows.Forms.Label();
            this.lblTotalFilesAlreadyProcessed = new System.Windows.Forms.Label();
            this.lblFilesNotFound = new System.Windows.Forms.Label();
            this.counterFilesNotFound = new System.Windows.Forms.Label();
            this.counterMisplacedFiles = new System.Windows.Forms.Label();
            this.lblMisplacedFiles = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblTimer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(1694, 1413);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(291, 48);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblConnection
            // 
            this.lblConnection.AutoSize = true;
            this.lblConnection.Location = new System.Drawing.Point(1529, 1531);
            this.lblConnection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(51, 20);
            this.lblConnection.TabIndex = 49;
            this.lblConnection.Text = "label8";
            // 
            // counterFilesWithoutConflicts
            // 
            this.counterFilesWithoutConflicts.AutoSize = true;
            this.counterFilesWithoutConflicts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.counterFilesWithoutConflicts.Location = new System.Drawing.Point(950, 1253);
            this.counterFilesWithoutConflicts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.counterFilesWithoutConflicts.Name = "counterFilesWithoutConflicts";
            this.counterFilesWithoutConflicts.Size = new System.Drawing.Size(14, 13);
            this.counterFilesWithoutConflicts.TabIndex = 44;
            this.counterFilesWithoutConflicts.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(272, 1145);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 20);
            this.label4.TabIndex = 43;
            // 
            // countertotalFilesProcessed
            // 
            this.countertotalFilesProcessed.AutoSize = true;
            this.countertotalFilesProcessed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countertotalFilesProcessed.Location = new System.Drawing.Point(950, 1202);
            this.countertotalFilesProcessed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.countertotalFilesProcessed.Name = "countertotalFilesProcessed";
            this.countertotalFilesProcessed.Size = new System.Drawing.Size(14, 13);
            this.countertotalFilesProcessed.TabIndex = 42;
            this.countertotalFilesProcessed.Text = "0";
            // 
            // lbltotalFilesProcessed
            // 
            this.lbltotalFilesProcessed.AutoSize = true;
            this.lbltotalFilesProcessed.Location = new System.Drawing.Point(710, 1202);
            this.lbltotalFilesProcessed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltotalFilesProcessed.Name = "lbltotalFilesProcessed";
            this.lbltotalFilesProcessed.Size = new System.Drawing.Size(170, 20);
            this.lbltotalFilesProcessed.TabIndex = 41;
            this.lbltotalFilesProcessed.Text = "Total Files Completed :";
            // 
            // AllFilesList
            // 
            this.AllFilesList.AllowColumnReorder = true;
            this.AllFilesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AttachmentMasterID,
            this.GoodFilePathName,
            this.BadFilePathName,
            this.PathInDBBefore,
            this.PathInDBAfter});
            this.AllFilesList.FullRowSelect = true;
            this.AllFilesList.GridLines = true;
            this.AllFilesList.HideSelection = false;
            this.AllFilesList.HoverSelection = true;
            this.AllFilesList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AllFilesList.Location = new System.Drawing.Point(26, 14);
            this.AllFilesList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AllFilesList.Name = "AllFilesList";
            this.AllFilesList.Size = new System.Drawing.Size(2800, 1136);
            this.AllFilesList.TabIndex = 50;
            this.AllFilesList.TileSize = new System.Drawing.Size(1, 1);
            this.AllFilesList.UseCompatibleStateImageBehavior = false;
            // 
            // AttachmentMasterID
            // 
            this.AttachmentMasterID.Text = "Attachment Master ID";
            this.AttachmentMasterID.Width = 80;
            // 
            // GoodFilePathName
            // 
            this.GoodFilePathName.Text = "Good File Path Name";
            this.GoodFilePathName.Width = 200;
            // 
            // BadFilePathName
            // 
            this.BadFilePathName.Text = "Bad File Path Name";
            this.BadFilePathName.Width = 120;
            // 
            // PathInDBBefore
            // 
            this.PathInDBBefore.Text = "Path In DB Before";
            this.PathInDBBefore.Width = 700;
            // 
            // PathInDBAfter
            // 
            this.PathInDBAfter.Text = "Path In DB After";
            this.PathInDBAfter.Width = 700;
            // 
            // lblFilesWithoutConflicts
            // 
            this.lblFilesWithoutConflicts.AutoSize = true;
            this.lblFilesWithoutConflicts.Location = new System.Drawing.Point(746, 1253);
            this.lblFilesWithoutConflicts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilesWithoutConflicts.Name = "lblFilesWithoutConflicts";
            this.lblFilesWithoutConflicts.Size = new System.Drawing.Size(133, 20);
            this.lblFilesWithoutConflicts.TabIndex = 51;
            this.lblFilesWithoutConflicts.Text = "Total Good Files :";
            // 
            // lblFilesWithConflicts
            // 
            this.lblFilesWithConflicts.AutoSize = true;
            this.lblFilesWithConflicts.Location = new System.Drawing.Point(758, 1299);
            this.lblFilesWithConflicts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilesWithConflicts.Name = "lblFilesWithConflicts";
            this.lblFilesWithConflicts.Size = new System.Drawing.Size(122, 20);
            this.lblFilesWithConflicts.TabIndex = 52;
            this.lblFilesWithConflicts.Text = "Total Bad Files :";
            // 
            // counterFilesWithConflicts
            // 
            this.counterFilesWithConflicts.AutoSize = true;
            this.counterFilesWithConflicts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.counterFilesWithConflicts.Location = new System.Drawing.Point(950, 1309);
            this.counterFilesWithConflicts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.counterFilesWithConflicts.Name = "counterFilesWithConflicts";
            this.counterFilesWithConflicts.Size = new System.Drawing.Size(14, 13);
            this.counterFilesWithConflicts.TabIndex = 53;
            this.counterFilesWithConflicts.Text = "0";
            // 
            // counterTotalRecordsUpdatedInDb
            // 
            this.counterTotalRecordsUpdatedInDb.AutoSize = true;
            this.counterTotalRecordsUpdatedInDb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.counterTotalRecordsUpdatedInDb.Location = new System.Drawing.Point(950, 1359);
            this.counterTotalRecordsUpdatedInDb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.counterTotalRecordsUpdatedInDb.Name = "counterTotalRecordsUpdatedInDb";
            this.counterTotalRecordsUpdatedInDb.Size = new System.Drawing.Size(14, 13);
            this.counterTotalRecordsUpdatedInDb.TabIndex = 59;
            this.counterTotalRecordsUpdatedInDb.Text = "0";
            // 
            // lblTotalRecordsUpdatedInDb
            // 
            this.lblTotalRecordsUpdatedInDb.AutoSize = true;
            this.lblTotalRecordsUpdatedInDb.Location = new System.Drawing.Point(656, 1359);
            this.lblTotalRecordsUpdatedInDb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalRecordsUpdatedInDb.Name = "lblTotalRecordsUpdatedInDb";
            this.lblTotalRecordsUpdatedInDb.Size = new System.Drawing.Size(227, 20);
            this.lblTotalRecordsUpdatedInDb.TabIndex = 58;
            this.lblTotalRecordsUpdatedInDb.Text = "Total Records Updated In DB :";
            // 
            // lblFilesDeleted
            // 
            this.lblFilesDeleted.AutoSize = true;
            this.lblFilesDeleted.Location = new System.Drawing.Point(1196, 1253);
            this.lblFilesDeleted.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilesDeleted.Name = "lblFilesDeleted";
            this.lblFilesDeleted.Size = new System.Drawing.Size(149, 20);
            this.lblFilesDeleted.TabIndex = 57;
            this.lblFilesDeleted.Text = "Total Files Deleted :";
            // 
            // counterFilesDeleted
            // 
            this.counterFilesDeleted.AutoSize = true;
            this.counterFilesDeleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.counterFilesDeleted.Location = new System.Drawing.Point(1424, 1253);
            this.counterFilesDeleted.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.counterFilesDeleted.Name = "counterFilesDeleted";
            this.counterFilesDeleted.Size = new System.Drawing.Size(14, 13);
            this.counterFilesDeleted.TabIndex = 56;
            this.counterFilesDeleted.Text = "0";
            // 
            // counterFilesCopied
            // 
            this.counterFilesCopied.AutoSize = true;
            this.counterFilesCopied.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.counterFilesCopied.Location = new System.Drawing.Point(1424, 1202);
            this.counterFilesCopied.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.counterFilesCopied.Name = "counterFilesCopied";
            this.counterFilesCopied.Size = new System.Drawing.Size(14, 13);
            this.counterFilesCopied.TabIndex = 55;
            this.counterFilesCopied.Text = "0";
            // 
            // lblFilesCopied
            // 
            this.lblFilesCopied.AutoSize = true;
            this.lblFilesCopied.Location = new System.Drawing.Point(1202, 1202);
            this.lblFilesCopied.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilesCopied.Name = "lblFilesCopied";
            this.lblFilesCopied.Size = new System.Drawing.Size(143, 20);
            this.lblFilesCopied.TabIndex = 54;
            this.lblFilesCopied.Text = "Total Files Copied :";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(1136, 1413);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(291, 48);
            this.btnReset.TabIndex = 60;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblLastFileProcessed
            // 
            this.lblLastFileProcessed.AutoSize = true;
            this.lblLastFileProcessed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastFileProcessed.Location = new System.Drawing.Point(1976, 1209);
            this.lblLastFileProcessed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastFileProcessed.Name = "lblLastFileProcessed";
            this.lblLastFileProcessed.Size = new System.Drawing.Size(14, 13);
            this.lblLastFileProcessed.TabIndex = 62;
            this.lblLastFileProcessed.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1742, 1202);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 20);
            this.label5.TabIndex = 61;
            this.label5.Text = "Last Processed File ID :";
            // 
            // counterTotalFilesRemainingToProcessed
            // 
            this.counterTotalFilesRemainingToProcessed.AutoSize = true;
            this.counterTotalFilesRemainingToProcessed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.counterTotalFilesRemainingToProcessed.Location = new System.Drawing.Point(1976, 1256);
            this.counterTotalFilesRemainingToProcessed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.counterTotalFilesRemainingToProcessed.Name = "counterTotalFilesRemainingToProcessed";
            this.counterTotalFilesRemainingToProcessed.Size = new System.Drawing.Size(14, 13);
            this.counterTotalFilesRemainingToProcessed.TabIndex = 64;
            this.counterTotalFilesRemainingToProcessed.Text = "0";
            // 
            // lblTotalFilesRemainingToProcessed
            // 
            this.lblTotalFilesRemainingToProcessed.AutoSize = true;
            this.lblTotalFilesRemainingToProcessed.Location = new System.Drawing.Point(1622, 1253);
            this.lblTotalFilesRemainingToProcessed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalFilesRemainingToProcessed.Name = "lblTotalFilesRemainingToProcessed";
            this.lblTotalFilesRemainingToProcessed.Size = new System.Drawing.Size(298, 20);
            this.lblTotalFilesRemainingToProcessed.TabIndex = 63;
            this.lblTotalFilesRemainingToProcessed.Text = "Total Files Remaining To Be Processed : ";
            // 
            // counterTotalFilesAlreadyProcessed
            // 
            this.counterTotalFilesAlreadyProcessed.AutoSize = true;
            this.counterTotalFilesAlreadyProcessed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.counterTotalFilesAlreadyProcessed.Location = new System.Drawing.Point(1976, 1305);
            this.counterTotalFilesAlreadyProcessed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.counterTotalFilesAlreadyProcessed.Name = "counterTotalFilesAlreadyProcessed";
            this.counterTotalFilesAlreadyProcessed.Size = new System.Drawing.Size(14, 13);
            this.counterTotalFilesAlreadyProcessed.TabIndex = 66;
            this.counterTotalFilesAlreadyProcessed.Text = "0";
            // 
            // lblTotalFilesAlreadyProcessed
            // 
            this.lblTotalFilesAlreadyProcessed.AutoSize = true;
            this.lblTotalFilesAlreadyProcessed.Location = new System.Drawing.Point(1693, 1299);
            this.lblTotalFilesAlreadyProcessed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalFilesAlreadyProcessed.Name = "lblTotalFilesAlreadyProcessed";
            this.lblTotalFilesAlreadyProcessed.Size = new System.Drawing.Size(229, 20);
            this.lblTotalFilesAlreadyProcessed.TabIndex = 65;
            this.lblTotalFilesAlreadyProcessed.Text = "Total Files Already Processed : ";
            // 
            // lblFilesNotFound
            // 
            this.lblFilesNotFound.AutoSize = true;
            this.lblFilesNotFound.Location = new System.Drawing.Point(1177, 1299);
            this.lblFilesNotFound.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilesNotFound.Name = "lblFilesNotFound";
            this.lblFilesNotFound.Size = new System.Drawing.Size(168, 20);
            this.lblFilesNotFound.TabIndex = 68;
            this.lblFilesNotFound.Text = "Total Files Not Found :";
            // 
            // counterFilesNotFound
            // 
            this.counterFilesNotFound.AutoSize = true;
            this.counterFilesNotFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.counterFilesNotFound.Location = new System.Drawing.Point(1424, 1302);
            this.counterFilesNotFound.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.counterFilesNotFound.Name = "counterFilesNotFound";
            this.counterFilesNotFound.Size = new System.Drawing.Size(14, 13);
            this.counterFilesNotFound.TabIndex = 67;
            this.counterFilesNotFound.Text = "0";
            // 
            // counterMisplacedFiles
            // 
            this.counterMisplacedFiles.AutoSize = true;
            this.counterMisplacedFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.counterMisplacedFiles.Location = new System.Drawing.Point(1424, 1359);
            this.counterMisplacedFiles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.counterMisplacedFiles.Name = "counterMisplacedFiles";
            this.counterMisplacedFiles.Size = new System.Drawing.Size(14, 13);
            this.counterMisplacedFiles.TabIndex = 70;
            this.counterMisplacedFiles.Text = "0";
            // 
            // lblMisplacedFiles
            // 
            this.lblMisplacedFiles.AutoSize = true;
            this.lblMisplacedFiles.Location = new System.Drawing.Point(1172, 1359);
            this.lblMisplacedFiles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMisplacedFiles.Name = "lblMisplacedFiles";
            this.lblMisplacedFiles.Size = new System.Drawing.Size(164, 20);
            this.lblMisplacedFiles.TabIndex = 69;
            this.lblMisplacedFiles.Text = "Total Files Misplaced :";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.Color.Red;
            this.lblTimer.Location = new System.Drawing.Point(1975, 1352);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(57, 13);
            this.lblTimer.TabIndex = 71;
            this.lblTimer.Text = "00:00:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1805, 1352);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 72;
            this.label1.Text = "Time Elapsed : ";
            // 
            // FolderStructure
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(2414, 1049);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.counterMisplacedFiles);
            this.Controls.Add(this.lblMisplacedFiles);
            this.Controls.Add(this.lblFilesNotFound);
            this.Controls.Add(this.counterFilesNotFound);
            this.Controls.Add(this.counterTotalFilesAlreadyProcessed);
            this.Controls.Add(this.lblTotalFilesAlreadyProcessed);
            this.Controls.Add(this.counterTotalFilesRemainingToProcessed);
            this.Controls.Add(this.lblTotalFilesRemainingToProcessed);
            this.Controls.Add(this.lblLastFileProcessed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.counterTotalRecordsUpdatedInDb);
            this.Controls.Add(this.lblTotalRecordsUpdatedInDb);
            this.Controls.Add(this.lblFilesDeleted);
            this.Controls.Add(this.counterFilesDeleted);
            this.Controls.Add(this.counterFilesCopied);
            this.Controls.Add(this.lblFilesCopied);
            this.Controls.Add(this.counterFilesWithConflicts);
            this.Controls.Add(this.lblFilesWithConflicts);
            this.Controls.Add(this.lblFilesWithoutConflicts);
            this.Controls.Add(this.AllFilesList);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblConnection);
            this.Controls.Add(this.counterFilesWithoutConflicts);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.countertotalFilesProcessed);
            this.Controls.Add(this.lbltotalFilesProcessed);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FolderStructure";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Folder Cleanup Utility Tool";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.Label counterFilesWithoutConflicts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label countertotalFilesProcessed;
        private System.Windows.Forms.Label lbltotalFilesProcessed;
        private System.Windows.Forms.ListView AllFilesList;
        private System.Windows.Forms.ColumnHeader GoodFilePathName;
        private System.Windows.Forms.ColumnHeader BadFilePathName;
        private System.Windows.Forms.ColumnHeader PathInDBBefore;
        private System.Windows.Forms.ColumnHeader PathInDBAfter;
        private System.Windows.Forms.ColumnHeader AttachmentMasterID;
        private System.Windows.Forms.Label lblFilesWithoutConflicts;
        private System.Windows.Forms.Label lblFilesWithConflicts;
        private System.Windows.Forms.Label counterFilesWithConflicts;
        private System.Windows.Forms.Label counterTotalRecordsUpdatedInDb;
        private System.Windows.Forms.Label lblTotalRecordsUpdatedInDb;
        private System.Windows.Forms.Label lblFilesDeleted;
        private System.Windows.Forms.Label counterFilesDeleted;
        private System.Windows.Forms.Label counterFilesCopied;
        private System.Windows.Forms.Label lblFilesCopied;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblLastFileProcessed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label counterTotalFilesRemainingToProcessed;
        private System.Windows.Forms.Label lblTotalFilesRemainingToProcessed;
        private System.Windows.Forms.Label counterTotalFilesAlreadyProcessed;
        private System.Windows.Forms.Label lblTotalFilesAlreadyProcessed;
        private System.Windows.Forms.Label lblFilesNotFound;
        private System.Windows.Forms.Label counterFilesNotFound;
        private System.Windows.Forms.Label counterMisplacedFiles;
        private System.Windows.Forms.Label lblMisplacedFiles;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label label1;
    }
}