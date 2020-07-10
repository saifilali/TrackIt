using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Migration
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 oform = new Form2();
            oform.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 oform = new Form1();
            oform.Show();
        }

        private void UpdateTblAttachmentMaster_Click(object sender, EventArgs e)
        {
            UpdateAttachmentMaster oUpdateAttachmentMaster = new UpdateAttachmentMaster();
            oUpdateAttachmentMaster.Show();
        }

        private void btnDeleteWithoutSourceId_Click(object sender, EventArgs e)
        {
            DeleteWithoutSourceID oDeleteWithoutSourceID = new DeleteWithoutSourceID();
            oDeleteWithoutSourceID.Show();
        }

        private void MoveFileWithDocumentNo_Click(object sender, EventArgs e)
        {
            MoveFilesWithDocNo oMoveFilesWithDocNo = new MoveFilesWithDocNo();
            oMoveFilesWithDocNo.Show();
        }

        private void MoveFilesWitouthDocNo_Click(object sender, EventArgs e)
        {
            MoveFilesWithoutDocNo oMoveFilesWithoutDocNo = new MoveFilesWithoutDocNo();
            oMoveFilesWithoutDocNo.Show();
        }

        private void CopyFolderStructure_Click(object sender, EventArgs e)
        {
            CopyFolderAndFiles oCopyFolderAndFiles = new CopyFolderAndFiles();
            oCopyFolderAndFiles.Show();


        }

        private void btnFolderStructure_Click(object sender, EventArgs e)
        {            
            FolderStructure oFolderStructure = new FolderStructure();            
            oFolderStructure.Show();
        }
    }
}
