using DMS.AppCommon;
using System;
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
    public partial class MoveFilesWithoutDocNo : Form
    {

        int TotalCount = 0;
        int Count = 0;
        int Updated = 0;
        int DidnotUpdated = 0;

        Dictionary<long, TableInfo> list = new Dictionary<long, TableInfo>();

        private List<FileInforMation> _FileList;

        public List<FileInforMation> FileList
        {
            get
            {
                if (_FileList == null)
                    _FileList = new List<FileInforMation>();

                return _FileList;
            }
            set
            {
                _FileList = value;
            }

        }

        public string getConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["DMS"].ToString();
            }
        }
        public MoveFilesWithoutDocNo()
        {
            InitializeComponent();
            lblConnection.Text = getConnectionString;
            DictionaryofAttachmentType();
        }

        private string[] ReadFile(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                MessageBox.Show("Directory does not exist");
                return null;
            }

            string[] filelist = Directory.GetFiles(directoryPath, "*.*", SearchOption.TopDirectoryOnly);
            return filelist;
        }

        private KeyValuePair<long, TableInfo> GetTableInfo(long attachmentType)
        {
            KeyValuePair<long, TableInfo> result = list.Where(d => d.Key == attachmentType).FirstOrDefault();
            return result;
        }

        private string FindeDocNobyFileName(long attachmentType, long sourceId)
        {
            KeyValuePair<long, TableInfo> result = GetTableInfo(attachmentType);
            if (result.Key == 0)
            {
                return null;
            }
            string tableName = result.Value.tableName;
            string columnNameID = result.Value.columnNameId;
            string colDocNo = result.Value.columnDocNo;

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = new SqlConnection(getConnectionString);
                cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = String.Format(@"select {0}  from {1} where {2}={3}", colDocNo, tableName, columnNameID, sourceId);
                cmd.CommandType = CommandType.Text;
                string docNo = cmd.ExecuteScalar().ToString();
                return docNo;

            }
            catch (Exception ex)
            {
                return null;
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

        private string GetDocNo(string originalFilePath)
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
                cmd.CommandText = String.Format(@"select * from tblattachmentmaster where filePath like '%{0}%'", originalFilePath);
                cmd.CommandType = CommandType.Text;
                reader = cmd.ExecuteReader();
                string docNo = null;

                while (reader.Read())
                {
                    long attachmentType = Convert.ToInt64(reader["attachmentTypeID"].ToString());
                    long sourceId = Convert.ToInt64(reader["AssociatedSourceID"].ToString());
                    string filePath = reader["FilePath"].ToString();
                    long attachmentMasterID = Convert.ToInt64(reader["AttachmentMasterID"]);
                    docNo = FindeDocNobyFileName(attachmentType, sourceId);

                    if (string.IsNullOrEmpty(docNo))
                    {
                        MessageBox.Show(String.Format("Could not file tableinfo by attachmentType = {0}", attachmentType));
                        return null;
                    }
                }

                return docNo;
            }


            catch (Exception ex)
            {
                return null;
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
                if (reader != null)
                {
                    reader.Close();
                }
            }


        }

        private void DictionaryofAttachmentType()
        {
            list.Add(1618, new TableInfo { tableName = "tblSalesFrontCounter", columnNameId = "SalesFrontCounterID", columnDocNo = "SalesFrontCounterNo" });
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            lblConnection.Text = getConnectionString;

            btnStart.Enabled = false;
            reset();

            string[] fileList = ReadFile(txtSourceFolder.Text);
            if (fileList == null || fileList.Length == 0)
            {
                MessageBox.Show("Threre is no file in the folder");
                return;
            }

            foreach (string fileName in fileList)
            {
                AddFileWithoutDocNo(fileName);
            }

            TotalCount = fileList.Count();
            lblTotalFiles.Text = TotalCount.ToString();
            MovingFiles();
            btnStart.Enabled = true;
        }

        private bool CopyFile(string sourcFileName, string destinationFileName)
        {
            try
            {
                FileInfo f1 = new FileInfo(sourcFileName);
                if (f1.Exists)
                {
                    if (!Directory.Exists(System.IO.Path.GetDirectoryName(destinationFileName)))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(System.IO.Path.GetDirectoryName(destinationFileName));
                    }
                    if (sourcFileName != destinationFileName)
                    {
                        File.Copy(sourcFileName, destinationFileName, true);

                    }
                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        private bool ConnectToDataBase(string fileTable, string newfileName, string originalFilePath)
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
                cmd.CommandText = String.Format(
                    "select stream_id,FileTableRootPath() +[file_stream].GetFileNamespacePath() as newFilePath,name as fileName from {0} where name='{1}' ", fileTable, newfileName);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string id = reader["stream_id"].ToString();
                    string newFilePath = reader["newFilePath"].ToString();
                    string filename = reader["fileName"].ToString();
                    if (UpdatetblAttachmentMaster( newFilePath, originalFilePath) <= 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
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

        private int UpdatetblAttachmentMaster(string newFilePath, string originalfilePath)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = new SqlConnection(getConnectionString);
                cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = String.Format(
                    @"update tblAttachmentMaster 
                     set tblAttachmentMaster.FilePath='{0}'
                     where tblAttachmentMaster.FilePath like '%{1}%'", newFilePath, originalfilePath);
                cmd.CommandType = CommandType.Text;
                int result = Convert.ToInt32(cmd.ExecuteNonQuery());
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
                {
                    cmd.Dispose();
                }
            }
        }

        private bool FileMove(string path)
        {
            try
            {
                string desfileName = Path.GetFileName(path);
                File.Move(path, txtDeletedFilesFolder.Text + @"\" + desfileName);
                return true;

            }
            catch
            {
                return false;
            }
        }


        private bool FileDelete(string path)
        {
            try
            {
                File.Delete(path);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        private void AddListBox(string file, string status)
        {
            listBox1.Items.Add(file + "  " + status);
            lblCount.Text = listBox1.Items.Count.ToString();
            Application.DoEvents();

        }

        private void log(string foldrName, string filename, string status)
        {
            if (String.IsNullOrEmpty(filename)) return;
            string fName = new DirectoryInfo(foldrName).Name;
            string root = String.Format(@"C:\Migration\MoveFilesWithoutDocNo\{0}", fName);

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }


            root += @"\" + fName + ".txt";

            //if(!File.Exists(root))
            //{
            //    File.Create(root);
            //}

            using (StreamWriter streamWriter = new StreamWriter(root, true))
            {
                streamWriter.WriteLine(filename + " : " + status);
                streamWriter.Close();
                streamWriter.Dispose();
            }
        }

        private  DocumentType GetDocumentType(string docNo)
        {
            string[] result = docNo.Split('-');
            if (result.Count() >= 4) return DocumentType.NumberAndLetter;
            else return DocumentType.Number; 
        }

        private void MovingFiles()
        {
            try
            {
                
                foreach (FileInforMation fileinfo in FileList)
                {
                    string docNo = GetDocNo(fileinfo.originalFilpath);
                    if(String.IsNullOrEmpty(docNo))
                    {
                        throw new Exception("docNo not found");
                    }
                    fileinfo.docNo = docNo;

                    DocumentType type = GetDocumentType(docNo);

                    string path = PathGenerator.GeneratedFilePath(fileinfo.docNo,type,true);
                    string prefix = getPrefixByAttachmentType(fileinfo.originalFilpath);
                    if (string.IsNullOrEmpty(prefix))
                    {
                        throw new Exception("Prefix not found");
                    }
                    string destinationFileName = fileinfo.docNo + "_" + Guid.NewGuid() + "_" + fileinfo.OriginalFileName;
                    string destinationPath = prefix + @"\" + path + @"\" + destinationFileName;

                    bool result = CopyFile(fileinfo.originalFilpath, destinationPath);
                    if (result == false)
                    {
                        throw new Exception("Could not Copy The file", new Exception(fileinfo.originalFilpath));
                    }

                    if (UpdatetblAttachmentMaster(destinationPath, fileinfo.originalFilpath) <= 0)
                    {
                        FileDelete(destinationPath);
                        DidnotUpdated++;
                        lblNotUpdated.Text = DidnotUpdated.ToString();
                        AddListBox(fileinfo.originalFilpath, "Did not Updated");
                        log(txtSourceFolder.Text, fileinfo.originalFilpath, "Did not Updated");
                        throw new Exception("Could Not Update tblAttachmentMaster", new Exception(fileinfo.originalFilpath));
                    }
                   
                    bool filedeleted = FileMove(fileinfo.originalFilpath);
                    if (filedeleted)
                    {
                        log(txtSourceFolder.Text, fileinfo.originalFilpath, "Moved");
                    }
                    else
                        log(txtSourceFolder.Text, fileinfo.originalFilpath, "Not Moved");

                    Updated++;
                    lblUpodateCount.Text = Updated.ToString();
                    AddListBox(fileinfo.originalFilpath, "Updated");
                    log(txtSourceFolder.Text, fileinfo.originalFilpath, "Updated");
                }
            }
            catch (Exception ex)
            {
                log(txtSourceFolder.Text, ex.InnerException.Message, ex.Message);
                MessageBox.Show(ex.Message);
            }

        }

        private string getPrefixByAttachmentType(string filePath)

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
                cmd.CommandText = String.Format(
                    "select AttachmentTypeID from tblAttachmentMaster where FilePath like '%{0}%' ", filePath);
                cmd.CommandType = CommandType.Text;
                long attachmentTypeId = Convert.ToInt64(cmd.ExecuteScalar());
                cmd.CommandText = String.Format("select AdditionalDesc1 from tblReferenceMapping where ReferenceType='ATTACHMENTTYPEID' and ReferenceMappingID={0}", attachmentTypeId);
                string result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch (Exception ex)
            {
                return null;
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

        private void AddFileWithoutDocNo(string fileName)
        {
            if (Path.GetFileName(fileName).StartsWith("-"))
            {
                FileList.Add(new FileInforMation() { originalFilpath = fileName });
            }
        }

        private void reset()
        {
            lblCount.Text = String.Empty;
            lblTotalFiles.Text = String.Empty;
            lblNotUpdated.Text = String.Empty;
            lblUpodateCount.Text = String.Empty;

             TotalCount = 0;
             Count = 0;
             Updated = 0;
             DidnotUpdated = 0;

            listBox1.Items.Clear();
        }
    }
}
