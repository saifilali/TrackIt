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
    public partial class Form2 : Form
    {
        int FoundinFileSystem = 0;
        int DeletedFiles = 0;
        int NotDeleted = 0;
        int TotalFiles = 0;
        public Form2()
        {
            InitializeComponent();
            lblConnection.Text = getConnectionString;
        }

        public string getConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["DMS"].ToString();

            }
        }

        private void ConnectToDataBase(string path)
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

                cmd.CommandText = String.Format(@"select count(*) FilePath  from tblAttachmentMaster where FilePath like'%{0}%'", path);
                cmd.CommandType = CommandType.Text;
                TotalFiles = Convert.ToInt32(cmd.ExecuteScalar());
                lblTotalFiles.Text = TotalFiles.ToString();

                cmd.CommandText = String.Format(@"select FilePath  from tblAttachmentMaster where FilePath like'%{0}%' order by attachmentMasterID desc ", path);
                cmd.CommandType = CommandType.Text;


                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                DataSet data = new DataSet();
                adapter.Fill(data, "tblAttachmentMaster");
                long lenght = data.Tables["tblAttachmentMaster"].Rows.Count;
                adapter.Dispose();

                foreach (DataRow row in data.Tables["tblAttachmentMaster"].Rows)

                {
                    FileExistance(row["FilePath"].ToString());

                }

                //reader = cmd.ExecuteReader();

                //while (reader.Read())
                //{
                //    FileExistance(reader["FilePath"].ToString());
                //}

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
                    cmd.Dispose();
                }
                if (reader != null)
                {
                    reader.Close();
                }
                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }

        }

        private void btnDo_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSourceFolder.Text))
            {
                MessageBox.Show("Select The path");
                return;
            }
            reset();
            btnDo.Enabled = false;
            ConnectToDataBase(txtSourceFolder.Text);
            log(txtSourceFolder.Text, "TotalFiles", TotalFiles.ToString());
            log(txtSourceFolder.Text, "Deleted Records", DeletedFiles.ToString());
            log(txtSourceFolder.Text, "Foundin FileSystem", FoundinFileSystem.ToString());

            btnDo.Enabled = true;
        }

        private void reset()
        {
            lblCount.Text = String.Empty;
            lblTotalFiles.Text = String.Empty;
            lblNotDeleted.Text = String.Empty;
            lblFoundInFileSystem.Text = String.Empty;
            lblDeletedCount.Text = String.Empty;

            DeletedFiles = 0;
            NotDeleted = 0;
            FoundinFileSystem = 0;
            listBox1.Items.Clear();
        }

        private void FileExistance(string filename)
        {
            if (!File.Exists(filename))
            {
                if (DeleteRecordFromDB(filename) < 1)
                {
                    NotDeleted++;
                    lblNotDeleted.Text = NotDeleted.ToString();
                    AddListBox(filename, "Not Deleted");
                    log(txtSourceFolder.Text, filename, "Not Deleted");
                }
                else
                {

                    DeletedFiles++;
                    lblDeletedCount.Text = DeletedFiles.ToString();
                    AddListBox(filename, "Deleted");
                    log(txtSourceFolder.Text, filename, "Deleted");
                }
                log(txtSourceFolder.Text, filename, "Not Found");

            }
            else
            {
                FoundinFileSystem++;
                lblFoundInFileSystem.Text = FoundinFileSystem.ToString();
                AddListBox(filename, "Found In FileSystem");
                log(txtSourceFolder.Text, filename, "Found In FileSystem");
            }
        }

        private void AddListBox(string file, string status)
        {
            listBox1.Items.Add(file + "  " + status);
            lblCount.Text = listBox1.Items.Count.ToString();
            Application.DoEvents();

        }

        private int DeleteRecordFromDB(string path)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = new SqlConnection(getConnectionString);
                cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = String.Format(@"select AttachmentMasterID from tblAttachmentMaster where FilePath like'%{0}%'", path);
                cmd.CommandType = CommandType.Text;
                long AttachmentMasterID = Convert.ToInt64(cmd.ExecuteScalar());
                cmd.CommandText = String.Format("exec dbo.FileAttachment_Delete {0}", AttachmentMasterID);
                cmd.CommandType = CommandType.Text;
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
        private void log(string foldrName, string filename, string status)
        {

            if (String.IsNullOrEmpty(filename)) return;
            string fName = new DirectoryInfo(foldrName).Name;
            string root = String.Format(@"C:\Migration\UnusedRecords\{0}", fName);

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

    }
}
