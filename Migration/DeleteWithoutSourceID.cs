using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Migration
{
    public partial class DeleteWithoutSourceID : Form
    {
        int TotalCount = 0;
        int DeletedFromDB = 0;
        int DidnotDeletedFromDB = 0;
        int DidnotDeletedFromFileSystem = 0;
        int DeletedFromFileSystem = 0;
        Dictionary<long, TableInfo> list = new Dictionary<long, TableInfo>();

        public DeleteWithoutSourceID()
        {
            InitializeComponent();
            DictionaryofAttachmentType();
            lblConnection.Text = getConnectionString;
        }

        public string getConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["DMS"].ToString();
            }
        }
        private void btnSatart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSourceFolder.Text)) return;
            FindRecordsbyFilePath(txtSourceFolder.Text);
        }

        private void AddListBox(string file, string status)
        {
            listBox1.Items.Add(file + "  " + status);
            lblCount.Text = listBox1.Items.Count.ToString();
            Application.DoEvents();

        }
        private void FindRecordsbyFilePath(string path)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataReader reader = null;
            try
            {
                conn = new SqlConnection(getConnectionString);
                cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = String.Format(@"select Count(*)  from tblattachmentMaster where filePath like '%{0}%' ", path);
                cmd.CommandType = CommandType.Text;
                TotalCount = Convert.ToInt32(cmd.ExecuteScalar());
                lblTotalFiles.Text = TotalCount.ToString();

                cmd.CommandText = String.Format(
                    "select * from tblattachmentmaster where filePath like '%{0}%'", path);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    long attachmentType = Convert.ToInt64(reader["attachmentTypeID"].ToString());
                    long sourceId = Convert.ToInt64(reader["AssociatedSourceID"].ToString());
                    string filePath = reader["FilePath"].ToString();
                    long attachmentMasterID = Convert.ToInt64(reader["AttachmentMasterID"]);
                    int result = AttachementExistance(attachmentType, sourceId);

                    if (result == -2)
                    {
                        MessageBox.Show(String.Format("Could not file tableinfo by attachmentType = {0}", attachmentType));
                        return;
                    }

                   else if (result< 0)
                    {
                        //log did not find should be deleted
                       if( DeleteRecordFromDB(attachmentMasterID)<1)
                        {
                            DidnotDeletedFromDB++;
                            lblNoDeletedFromDB.Text = DidnotDeletedFromDB.ToString();
                            AddListBox(filePath, "Did not Deleted from DB");
                            log(txtSourceFolder.Text, filePath, "Did not Deleted from DB");
                        }
                       else
                        {
                            DeletedFromDB++;
                            lblDeletedFromDB.Text = DeletedFromDB.ToString();
                            AddListBox(filePath, "Deleted From DB");
                            log(txtSourceFolder.Text, filePath, "Deleted From DB");
                        }

                       if(DeleteFileFromFileSystem(filePath))
                        {
                            DeletedFromFileSystem++;
                            lblDeletedFromFileSystem.Text = DeletedFromFileSystem.ToString();
                            AddListBox(filePath, "Deleted From FileSystem");
                            log(txtSourceFolder.Text, filePath, "Deleted From FileSystem");
                        }
                       else
                        {
                            DidnotDeletedFromFileSystem++;
                            lblNotDeletedFromFileSystem.Text = DidnotDeletedFromFileSystem.ToString();
                            AddListBox(filePath, "Did not Deleted From FileSystem");
                            log(txtSourceFolder.Text, filePath, "Did not Deleted From FileSystem");
                        }
              
                    }
                   
                    else if(result>0)
                    {
                        AddListBox(filePath, "Found in DB");
                        log(txtSourceFolder.Text, filePath, "Found In DB");
                    }
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                    conn = null;
                }
                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }
        }

        private void log(string foldrName, string filename, string status)
        {

            if (String.IsNullOrEmpty(filename)) return;
            string fName = new DirectoryInfo(foldrName).Name;
            string root = String.Format(@"C:\Migration\DeletedWithoutSourceID\{0}", fName);

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }

            root += @"\" + fName + ".txt";

            using (StreamWriter streamWriter = new StreamWriter(root, true))
            {
                streamWriter.WriteLine(filename + " : " + status);
                streamWriter.Close();
                streamWriter.Dispose();
            }
        }
        
        private int DeleteRecordFromDB(long attchmentMasterID)
        {
            return 1;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = new SqlConnection(getConnectionString);
                cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = String.Format("exec [dbo].[FileAttachment_Delete] {0}", attchmentMasterID);
                cmd.CommandType = CommandType.StoredProcedure;
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                    conn = null;
                }
                if (cmd != null)
                    cmd.Dispose();
            }
        }
        private bool DeleteFileFromFileSystem(string filePath)
        {
            return true;
            //try
            //{
            //    File.Delete(filePath);
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}

        }

        private int AttachementExistance(long attachmentType, long sourceId)
        {
            KeyValuePair<long, TableInfo> result = GetTableInfo(attachmentType);
            if(result.Key==0 )
            {
                return -2;
            }
            string tableName = result.Value.tableName;
            string columnNameID = result.Value.columnNameId;

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = new SqlConnection(getConnectionString);
                cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = String.Format(@"select Count(*)  from {0} where {1}={2}  ", tableName, columnNameID, sourceId);
                cmd.CommandType = CommandType.Text;
                int r = Convert.ToInt32(cmd.ExecuteScalar());
                return r;

            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                    conn = null;
                }
                if (cmd != null)
                {
                    cmd.Dispose();
                    cmd = null;
                }
            }

        }

        private KeyValuePair<long, TableInfo> GetTableInfo(long attachmentType)
        {
            KeyValuePair<long, TableInfo> result = list.Where(d => d.Key == attachmentType).FirstOrDefault();
            return result;
        }

        private void DictionaryofAttachmentType()
        {
            list.Add(1618, new TableInfo { tableName = "tblSalesFrontCounter", columnNameId = "SalesFrontCounterID" });
        }
    }
    public class TableInfo
    {
        public string tableName { get; set; }
        public string columnNameId { get; set; }
        public string columnDocNo { get; set; }

    }
}
