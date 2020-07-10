using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Migration
{
    public partial class Form1 : Form
    {

        int FoundinDB = 0;
        int DeletedFiles = 0;
        int NotDeleted = 0;
        int TotalFiles;

        public Form1()
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

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (String.IsNullOrEmpty(txtDeletedFilesFolder.Text))
                {
                    MessageBox.Show("Deleted files folder did not determined");
                    return;
                }

                if (!Directory.Exists(txtDeletedFilesFolder.Text))
                {
                    Directory.CreateDirectory(txtDeletedFilesFolder.Text);
                }

                button1.Enabled = false;
                reset();
                string[] fileList = ReadFile(txtSourceFolder.Text);
              if (fileList == null || fileList.Length == 0)
                {
                    MessageBox.Show("Threre is no file in the folder");
                    return;
                }

                TotalFiles = fileList.Length;
                lblTotalFiles.Text = TotalFiles.ToString();

                foreach (string file in fileList)
                {
                    int result = ConnectToDataBase(Path.GetFileName(file));
                    if (result != 1)
                    {
                        bool r = FileMove(file);
                        if (r == false)
                        {
                            NotDeleted++;
                            lblNotDeleted.Text = NotDeleted.ToString();
                            AddListBox(file, "Not Deleted");
                            log(txtSourceFolder.Text, file, "Not Deleted");

                        }
                        else
                        {
                            DeletedFiles++;
                            lblDeletedCount.Text = DeletedFiles.ToString();
                            AddListBox(file, "Deleted");
                            log(txtSourceFolder.Text, file, "Deleted");

                        }

                    }
                    else
                    {
                        FoundinDB++;
                        lblFoundInDB.Text = FoundinDB.ToString();
                        AddListBox(file, "Found in Database");
                        log(txtSourceFolder.Text, file, "Found in Database");

                    }
                }

                log(txtSourceFolder.Text, String.Format("TotalFiles : {0} DeleteFiles : {1} NotDeleted : {2} FoundInDatabase : {3}", TotalFiles, DeletedFiles, NotDeleted, FoundinDB), "Finished");
            }

            catch (Exception ex)
            {

            }
            finally
            {
                button1.Enabled = true;
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
            string root = String.Format(@"C:\Migration\UnusedFiles\{0}", fName);

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

        private void reset()
        {
            lblCount.Text = String.Empty;
            lblTotalFiles.Text = String.Empty;
            lblNotDeleted.Text = String.Empty;
            lblFoundInDB.Text = String.Empty;
            lblDeletedCount.Text = String.Empty;

            DeletedFiles = 0;
            NotDeleted = 0;
            FoundinDB = 0;

            listBox1.Items.Clear();
        }
        private string[] ReadFile(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                MessageBox.Show("Directory does not exist");
                return null;
            }

            string[] filelist = Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories);
            return filelist;
        }

        private bool FileMove(string path)
        {
            return true;
            //try
            //{
            //    string desfileName = Path.GetFileName(path);
            //    File.Move(path, txtDeletedFilesFolder.Text + @"\" + desfileName);
            //    return true;

            //}
            //catch
            //{
            //    return false;
            //}

            //try
            //{
            //    File.Delete(path);
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}
        }

        private int ConnectToDataBase(string fileName)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = new SqlConnection(getConnectionString);
                cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = String.Format(@"select Count(*)  from tblAttachmentMaster where FilePath like'%{0}%'", fileName);
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
                {
                    cmd.Dispose();
                }
            }

        }
    }
}
