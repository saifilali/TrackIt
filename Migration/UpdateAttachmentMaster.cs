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
    public partial class UpdateAttachmentMaster : Form
    {
        int TotalCount = 0;
        int Count=0;
        int Updated = 0;
        int DidnotUpdated = 0;
        public UpdateAttachmentMaster()
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

        private void btnSatart_Click(object sender, EventArgs e)
        {

            ConnectToDataBase(txtFileTableName.Text);
        }

        private int UpdatetblAttachmentMaster(string id, string newFileName, string fileName)
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
                     set tblAttachmentMaster.FileTableID='{0}',tblAttachmentMaster.FilePath='{1}'
                     where tblAttachmentMaster.FilePath like '%{2}%' and FileTableID is null", id, newFileName, fileName);
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

        private void AddListBox(string file, string status)
        {
            listBox1.Items.Add(file + "====>" + status);
            lblCount.Text = listBox1.Items.Count.ToString();
            Application.DoEvents();
        }

        private void log(string filename, string status)
        {
            if (String.IsNullOrEmpty(filename)) return;
            string root = @"C:\Migration\UpdateTblAttachment\UpdateTblAttachment.txt";

            if (!Directory.Exists(@"C:\Migration\UpdateTblAttachment"))
            {
                Directory.CreateDirectory(@"C:\Migration\UpdateTblAttachment");
            }

            using (StreamWriter streamWriter = new StreamWriter(root, true))
            {
                streamWriter.WriteLine(filename + " : " + status);
                streamWriter.Close();
                streamWriter.Dispose();
            }
        }

        private bool ConnectToDataBase(string fileTable)
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
                cmd.CommandText = String.Format(@"select Count(*)  from {0} where is_directory=0 ", fileTable);
                cmd.CommandType = CommandType.Text;
                TotalCount = Convert.ToInt32(cmd.ExecuteScalar());
                lblTotalFiles.Text = TotalCount.ToString();

                cmd.CommandText = String.Format(
                    "select stream_id,FileTableRootPath() +[file_stream].GetFileNamespacePath() as newFilePath,name as fileName from {0} where is_directory=0 ", fileTable);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string id = reader["stream_id"].ToString();
                    string newFilePath = reader["newFilePath"].ToString();
                    string filename = reader["fileName"].ToString();
                    if (UpdatetblAttachmentMaster(id, newFilePath, filename) <=0)
                    {
                        //log did not update
                        DidnotUpdated++;
                        lblNotUpdated.Text = DidnotUpdated.ToString();
                        AddListBox(newFilePath, "Did not Update");
                        log(newFilePath, "Did not Update");
                        
                    }
                   else
                    {
                        // log Updated
                        Updated++;
                        lblUpdatedCount.Text = Updated.ToString();
                        AddListBox(newFilePath, "Updated");
                        log(newFilePath, "Updated");
                       
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
    }

}
