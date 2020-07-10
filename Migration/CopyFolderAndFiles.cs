using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Migration
{
    public partial class CopyFolderAndFiles : Form
    {
        public CopyFolderAndFiles()
        {
            InitializeComponent();
            
        }

        int totalFiles = 0;
     
        private void btnStart_Click(object sender, EventArgs e)
        {
            
            try
            {
                btnStart.Enabled = false;
                btnReset.Enabled = false;
                if (!Directory.Exists(txtSourceFolder.Text))
                {
                    MessageBox.Show("Directory does not exist");
                    return;
                }

                string destinatioFolder = txtDestinationFolder.Text;

                if (!Directory.Exists(destinatioFolder))
                {
                    Directory.CreateDirectory(destinatioFolder);
                }

                GetDirectories(txtSourceFolder.Text);
                MessageBox.Show("Copy has finished successfuly");
                log(txtDestinationFolder.Text);
                
            }
            catch
            {
                reset();

            }
            finally
            {
                btnStart.Enabled = true;
                btnReset.Enabled = true;

            }
        }

        private void log(string foldrName)
        {
            
            string fName = new DirectoryInfo(foldrName).Name;
            string root = String.Format(@"C:\Migration\CopyFiles\{0}", fName);

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }

            root += @"\" + fName + ".txt";

            using (StreamWriter streamWriter = new StreamWriter(root, true))
            {
                streamWriter.WriteLine("Total Files : " + totalFiles);
                streamWriter.Close();
                streamWriter.Dispose();
            }
        }

        private void ShowFileName(string file)
        {
            lblFileName.Text = file;
            Application.DoEvents();
        }
        public string[] GetDirectories(string directoryPath)
        {
            string[] dirs = Directory.GetDirectories(directoryPath);
            if (dirs.Count() == 0)
            {
                string path = directoryPath.Replace(txtSourceFolder.Text, txtDestinationFolder.Text);
                Directory.CreateDirectory(path);
                return new string[] { };

            }

            foreach (string directory in dirs)
            {
                GetDirectories(directory);
                string[] filelist = Directory.GetFiles(directory, "*.*", SearchOption.TopDirectoryOnly);
                foreach (string fileName in filelist)
                {
                    CopyFiles(fileName, txtDestinationFolder.Text);
                }
            }

            return new string[] { };

        }

        public void CopyFiles(string sourceFileName, string destinationFileName)
        {

            if (File.Exists(sourceFileName))
            {
                string path= sourceFileName.Replace(txtSourceFolder.Text, txtDestinationFolder.Text);
                File.Copy(sourceFileName, path);
                totalFiles++;
                lblToralFiles.Text = totalFiles.ToString();
                ShowFileName(path);
            }
        }

        void reset()
        {
            txtDestinationFolder.Clear();
            txtSourceFolder.Clear();
            btnStart.Enabled = true;
            totalFiles = 0;
            lblToralFiles.Text = "0";
            lblFileName.Text = string.Empty;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }
    }
}
