namespace Migration
{
    partial class StartForm
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
            this.button2 = new System.Windows.Forms.Button();
            this.UpdateTblAttachmentMaster = new System.Windows.Forms.Button();
            this.btnDeleteWithoutSourceId = new System.Windows.Forms.Button();
            this.MoveFileWithDocumentNo = new System.Windows.Forms.Button();
            this.MoveFilesWitouthDocNo = new System.Windows.Forms.Button();
            this.CopyFolderStructure = new System.Windows.Forms.Button();
            this.btnFolderStructure = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(287, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "DeleteUnusedFiles";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 105);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(287, 44);
            this.button2.TabIndex = 1;
            this.button2.Text = "DeleteUnusedRecords";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // UpdateTblAttachmentMaster
            // 
            this.UpdateTblAttachmentMaster.Location = new System.Drawing.Point(12, 155);
            this.UpdateTblAttachmentMaster.Name = "UpdateTblAttachmentMaster";
            this.UpdateTblAttachmentMaster.Size = new System.Drawing.Size(287, 45);
            this.UpdateTblAttachmentMaster.TabIndex = 2;
            this.UpdateTblAttachmentMaster.Text = "UpdatetblAttachmentMaster";
            this.UpdateTblAttachmentMaster.UseVisualStyleBackColor = true;
            this.UpdateTblAttachmentMaster.Click += new System.EventHandler(this.UpdateTblAttachmentMaster_Click);
            // 
            // btnDeleteWithoutSourceId
            // 
            this.btnDeleteWithoutSourceId.Location = new System.Drawing.Point(12, 13);
            this.btnDeleteWithoutSourceId.Name = "btnDeleteWithoutSourceId";
            this.btnDeleteWithoutSourceId.Size = new System.Drawing.Size(287, 39);
            this.btnDeleteWithoutSourceId.TabIndex = 3;
            this.btnDeleteWithoutSourceId.Text = "Delete Records without SourceId";
            this.btnDeleteWithoutSourceId.UseVisualStyleBackColor = true;
            this.btnDeleteWithoutSourceId.Click += new System.EventHandler(this.btnDeleteWithoutSourceId_Click);
            // 
            // MoveFileWithDocumentNo
            // 
            this.MoveFileWithDocumentNo.Location = new System.Drawing.Point(12, 206);
            this.MoveFileWithDocumentNo.Name = "MoveFileWithDocumentNo";
            this.MoveFileWithDocumentNo.Size = new System.Drawing.Size(287, 45);
            this.MoveFileWithDocumentNo.TabIndex = 4;
            this.MoveFileWithDocumentNo.Text = "Move Files With DocNo";
            this.MoveFileWithDocumentNo.UseVisualStyleBackColor = true;
            this.MoveFileWithDocumentNo.Click += new System.EventHandler(this.MoveFileWithDocumentNo_Click);
            // 
            // MoveFilesWitouthDocNo
            // 
            this.MoveFilesWitouthDocNo.Location = new System.Drawing.Point(12, 257);
            this.MoveFilesWitouthDocNo.Name = "MoveFilesWitouthDocNo";
            this.MoveFilesWitouthDocNo.Size = new System.Drawing.Size(287, 45);
            this.MoveFilesWitouthDocNo.TabIndex = 5;
            this.MoveFilesWitouthDocNo.Text = "Move Files Without DocNo";
            this.MoveFilesWitouthDocNo.UseVisualStyleBackColor = true;
            this.MoveFilesWitouthDocNo.Click += new System.EventHandler(this.MoveFilesWitouthDocNo_Click);
            // 
            // CopyFolderStructure
            // 
            this.CopyFolderStructure.Location = new System.Drawing.Point(12, 308);
            this.CopyFolderStructure.Name = "CopyFolderStructure";
            this.CopyFolderStructure.Size = new System.Drawing.Size(287, 45);
            this.CopyFolderStructure.TabIndex = 6;
            this.CopyFolderStructure.Text = "Copy Folder Structure";
            this.CopyFolderStructure.UseVisualStyleBackColor = true;
            this.CopyFolderStructure.Click += new System.EventHandler(this.CopyFolderStructure_Click);
            // 
            // btnFolderStructure
            // 
            this.btnFolderStructure.Location = new System.Drawing.Point(12, 359);
            this.btnFolderStructure.Name = "btnFolderStructure";
            this.btnFolderStructure.Size = new System.Drawing.Size(287, 47);
            this.btnFolderStructure.TabIndex = 7;
            this.btnFolderStructure.Text = "Folder Structure";
            this.btnFolderStructure.UseVisualStyleBackColor = true;
            this.btnFolderStructure.Click += new System.EventHandler(this.btnFolderStructure_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 454);
            this.Controls.Add(this.btnFolderStructure);
            this.Controls.Add(this.CopyFolderStructure);
            this.Controls.Add(this.MoveFilesWitouthDocNo);
            this.Controls.Add(this.MoveFileWithDocumentNo);
            this.Controls.Add(this.btnDeleteWithoutSourceId);
            this.Controls.Add(this.UpdateTblAttachmentMaster);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "StartForm";
            this.Text = "StartFormcs";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button UpdateTblAttachmentMaster;
        private System.Windows.Forms.Button btnDeleteWithoutSourceId;
        private System.Windows.Forms.Button MoveFileWithDocumentNo;
        private System.Windows.Forms.Button MoveFilesWitouthDocNo;
        private System.Windows.Forms.Button CopyFolderStructure;
        private System.Windows.Forms.Button btnFolderStructure;
    }
}