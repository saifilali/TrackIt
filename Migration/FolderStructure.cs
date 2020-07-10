using DMS.AppCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace Migration
{
    public partial class FolderStructure : Form
    {
        private Dictionary<long, TableInfo> list = new Dictionary<long, TableInfo>();

        #region Important Declarations

        private static long attachmentTypeId = 1618;
        private string nameOfChopper = "APVOUCHERS";
        private static long filesToProcess = 99999;
        private static string startDate = "2016-1-1 00:00:00.000";
        private static string endDate = "2019-12-1 00:00:00.000";
        private long LastFileProcess = -1; //5271257;

        #endregion

        #region Other Declarations
        private long TotalFilesProcessed = 0;
        private long TotalFilesCopied = 0;
        private long TotalFilesDeleted = 0;
        private long TotalBadFiles = 0;
        private long TotalGoodFiles = 0;
        private long TotalFilesDoesNotExists = 0;
        private long TotalConflictedFilePathUpdatedInDb = 0;
        private long TotalFilesRemainingToBeProcessed = 0;
        private long TotalFilesMisplaced = 0;
        private long TotalFilesAlreadyProcessed = 0;
        private long OriginalTotalFilesRemainingToBeProcessed = 0;
        private long OriginalTotalFilesAlreadyProcessed = 0;
        private long OriginalTotalFilesDoesNotExists = 0;

        private enum Type { BadFileFound = 0, GoodFileFound = 1, FileNotFound = 2, MisplacedFileFound = 4, FileWithEmptyGoodPath = 6, DeletedFilesLogging = 10 }
        #endregion

        #region Constructor & Properties
        public string getConnectionString => System.Configuration.ConfigurationManager.ConnectionStrings["DMS"].ToString();

        public FolderStructure()
        {
            InitializeComponent();
            DictionaryofAttachmentType();
            TotalCountOfFiles();
            SetInitialLoadUIElements();
        }

        #endregion

        #region Click Events
        private void btnStart_Click(object sender, EventArgs e)
        {
            btnReset.Enabled = false;
            btnStart.Enabled = false;
            StartProcessingFiles(attachmentTypeId);

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetUI();
        }

        #endregion

        #region Methods        

        private void TotalCountOfFiles()
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            try
            {

                string countDynamicQueryForAllFiles = string.Format(@" select
                                                                (select count(*) from tblAttachmentMaster where AttachmentTypeID = {0} and IsGoodPath is null and IsOnCloud != 1 and CreatedDate >= '{1}' and CreatedDate < '{2}') as 'TotalFilesRemaining',
                                                                (select count(*) from tblAttachmentMaster where AttachmentTypeID = {0} and (IsGoodPath is not null and IsGoodPath != 3 and IsGoodPath != 5) and CreatedDate >= '{1}' and CreatedDate < '{2}') as 'TotalFilesAlreadyProcessed',
                                                                (select count(*) from tblAttachmentMaster where AttachmentTypeID = {0} and IsGoodPath = 0 and IsOnCloud != 1 and CreatedDate >= '{1}' and CreatedDate < '{2}') as 'TotalConflictedFilesFound',
                                                                (select count(*) from tblAttachmentMaster where AttachmentTypeID = {0} and IsGoodPath = 1 and CreatedDate >= '{1}' and CreatedDate < '{2}') as 'TotalNotConflictedFilesFound',
                                                                (select count(*) from tblAttachmentMaster where AttachmentTypeID = {0} and IsGoodPath = 2 and CreatedDate >= '{1}' and CreatedDate < '{2}') as 'TotalFilesNotFound',
                                                                (select count(*) from tblAttachmentMaster where AttachmentTypeID = {0} and IsGoodPath = 4 and CreatedDate >= '{1}' and CreatedDate < '{2}') as 'TotalMisplacedFilesFound'",
                                                                attachmentTypeId, startDate, endDate);



                conn = new SqlConnection(getConnectionString);
                cmd = new SqlCommand
                {
                    Connection = conn
                };

                conn.Open();
                conn = new SqlConnection(getConnectionString);
                cmd = new SqlCommand
                {
                    Connection = conn
                };

                conn.Open();

                cmd.CommandText = countDynamicQueryForAllFiles;
                cmd.CommandType = CommandType.Text;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TotalFilesRemainingToBeProcessed = Convert.ToInt64(reader["TotalFilesRemaining"].ToString());
                    TotalFilesAlreadyProcessed = Convert.ToInt64(reader["TotalFilesAlreadyProcessed"].ToString());
                    TotalFilesDoesNotExists = Convert.ToInt64(reader["TotalFilesNotFound"].ToString());
                    TotalBadFiles = Convert.ToInt64(reader["TotalConflictedFilesFound"].ToString());
                    TotalGoodFiles = Convert.ToInt64(reader["TotalNotConflictedFilesFound"].ToString());
                    TotalFilesMisplaced = Convert.ToInt64(reader["TotalMisplacedFilesFound"].ToString());
                }

                OriginalTotalFilesRemainingToBeProcessed = TotalFilesRemainingToBeProcessed;
                OriginalTotalFilesAlreadyProcessed = TotalFilesAlreadyProcessed;
                OriginalTotalFilesDoesNotExists = TotalFilesDoesNotExists;
            }

            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseAndResetConnection(conn, cmd, reader);
            }
        }

        private void SetInitialLoadUIElements()
        {
            counterTotalFilesRemainingToProcessed.Text = TotalFilesRemainingToBeProcessed.ToString();
            counterTotalFilesAlreadyProcessed.Text = TotalFilesAlreadyProcessed.ToString();
            counterFilesNotFound.Text = TotalFilesDoesNotExists.ToString();
            counterFilesWithConflicts.Text = TotalBadFiles.ToString();
            counterFilesWithoutConflicts.Text = TotalGoodFiles.ToString();
            lblConnection.Text = getConnectionString;
            btnReset.Enabled = false;
            btnStart.Enabled = true;
            lblLastFileProcessed.Text = LastFileProcess.ToString();
            lblTimer.Text = "00:00:00";
        }

        private void StartProcessingFiles(long attachmentTypeId)
        {
            timer1.Enabled = true;
            long attachmentMasterID;
            string middlePath = string.Empty;
            string prefixPath = @"\\DESKTOP\SAIFILATTACH\" + nameOfChopper; //CHANGE DESKTOP\SAIFILATTACH to Actual Path
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            try
            {

                string selectDynamicQuery = string.Format(@"select top {0} * from tblattachmentmaster with(nolock) where AttachmentTypeID = {1}
                                                    and AttachmentMasterID > {2}
                                                    and IsGoodPath is null
                                                    and IsOnCloud != 1 
                                                    and CreatedDate >= '{3}'
                                                    and CreatedDate < '{4}'
                                                    order by AttachmentMasterID asc",
                                                    filesToProcess, attachmentTypeId, LastFileProcess, startDate, endDate);

                conn = new SqlConnection(getConnectionString);
                cmd = new SqlCommand
                {
                    Connection = conn
                };

                conn.Open();

                cmd.CommandText = selectDynamicQuery;
                cmd.CommandType = CommandType.Text;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string oldPathWithFileName = reader["FilePath"].ToString();
                    string oldPathWithoutFileName = Path.GetDirectoryName(oldPathWithFileName);
                    int indexOfChopper = oldPathWithoutFileName.IndexOf(nameOfChopper);
                    int lengthOfChopper = nameOfChopper.Length + 1;

                    if (indexOfChopper >= 0)
                    {
                        if (indexOfChopper + lengthOfChopper - 1 == oldPathWithoutFileName.Length)
                        {
                            middlePath = string.Empty;
                        }
                        else
                        {
                            middlePath = oldPathWithoutFileName.Substring(indexOfChopper + lengthOfChopper, oldPathWithoutFileName.Length - (indexOfChopper + lengthOfChopper));
                        }
                    }

                    else
                    {
                        middlePath = oldPathWithFileName;
                    }

                    attachmentMasterID = Convert.ToInt64(reader["AttachmentMasterID"]);
                    LastFileProcess = attachmentMasterID;
                    bool doesPathExistsInFileSystem = File.Exists(oldPathWithFileName);

                    if (doesPathExistsInFileSystem == false)
                    {
                        bool IsUpdated = UpdateDatabase(attachmentMasterID, Type.FileNotFound);
                        if (IsUpdated)
                        {
                            ComputeTotalCounters(Type.FileNotFound);
                        }

                        //LoadToListView(attachmentMasterID, oldPathWithFileName, Type.FileNotFound);
                        Logger(Type.FileNotFound, attachmentMasterID, oldPathWithFileName);
                    }
                    else
                    {
                        PathCorrectionAndUpdate(attachmentMasterID, middlePath, prefixPath, reader, oldPathWithFileName, oldPathWithoutFileName);
                    }
                    TotalFilesProcessed++;
                    UpdateUI();
                }

                bool result = ProcessMoreOrExit();

                if (result == true)
                {
                    StartProcessingFiles(attachmentTypeId);
                }
                else
                {
                    MessageBox.Show("Operation Completed Successfully.");
                }
            }

            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseAndResetConnection(conn, cmd, reader);
            }
        }

        private void PathCorrectionAndUpdate(long attachmentMasterID, string middlePath, string prefixPath, SqlDataReader reader, string oldPathWithFileName, string oldPathWithoutFileName)
        {
            bool IsFileCopied = false;
            bool IsDbUpdated = false;
            bool IsFileDeleted = false;

            long attachmentType = Convert.ToInt64(reader["attachmentTypeID"].ToString());
            long sourceId = Convert.ToInt64(reader["AssociatedSourceID"].ToString());
            string docNo = FindeDocNobyFileName(attachmentType, sourceId);

            if (string.IsNullOrEmpty(docNo))
            {
                bool IsUpdated = UpdateDatabase(attachmentMasterID, Type.MisplacedFileFound);
                if (IsUpdated)
                {
                    ComputeTotalCounters(Type.MisplacedFileFound);
                }

                //LoadToListView(attachmentMasterID, oldPathWithFileName, Type.MisplacedFileFound);
                Logger(Type.MisplacedFileFound, attachmentMasterID, oldPathWithFileName);
                return;
            }

            DocumentType type = GetDocumentType(docNo);
            string goodPath = PathGenerator.GeneratedFilePath(docNo, type, true);



            if (string.IsNullOrEmpty(goodPath) || ValidateGoodPath(type, goodPath) == false)
            {
                bool IsUpdated = UpdateDatabase(attachmentMasterID, Type.FileWithEmptyGoodPath);
                if (IsUpdated)
                {
                    ComputeTotalCounters(Type.FileWithEmptyGoodPath);
                }

                //LoadToListView(attachmentMasterID, oldPathWithFileName, Type.FileWithEmptyGoodPath);
                Logger(Type.FileWithEmptyGoodPath, attachmentMasterID, oldPathWithFileName);
                return;
            }

            if (middlePath.Equals(goodPath))
            {
                bool IsUpdated = UpdateDatabase(attachmentMasterID, Type.GoodFileFound);
                if (IsUpdated)
                {
                    ComputeTotalCounters(Type.GoodFileFound);
                }

                //LoadToListView(attachmentMasterID, oldPathWithFileName, Type.GoodFileFound, "N/A", goodPath);
                Logger(Type.GoodFileFound, attachmentMasterID);
                return;
            }


            string currentsourceFileName = CheckGuidAndCreatePath(oldPathWithFileName, docNo);
            string newDBPath = prefixPath + "\\" + goodPath + "\\" + currentsourceFileName;
            newDBPath = newDBPath.Replace("'", "");
            IsFileCopied = CopyFile(oldPathWithoutFileName, newDBPath, oldPathWithFileName);

            if (IsFileCopied)
            {
                IsDbUpdated = UpdateDatabase(attachmentMasterID, Type.BadFileFound, newDBPath);

            }
            if (IsDbUpdated)
            {
                IsFileDeleted = DeleteFile(oldPathWithFileName);
            }

            if (IsFileDeleted)
            {
                Logger(Type.DeletedFilesLogging, attachmentMasterID);
            }

            if (IsDbUpdated)
            {
                ComputeTotalCounters(Type.BadFileFound);
            }

            //LoadToListView(attachmentMasterID, oldPathWithFileName, Type.BadFileFound, newDBPath, goodPath, middlePath);
            Logger(Type.BadFileFound, attachmentMasterID, oldPathWithFileName, goodPath, middlePath, newDBPath);
            Logger(Type.GoodFileFound, attachmentMasterID);
        }

        private string CheckGuidAndCreatePath(string oldPathWithFileName, string docNo)
        {

            string[] splittedArray = oldPathWithFileName.Split('_');

            if (splittedArray.Count() > 1)
            {
                return docNo + "_" + Guid.NewGuid() + "_" + splittedArray.Last();
            }

            return docNo + "_" + Guid.NewGuid() + "_" + Path.GetFileName(oldPathWithFileName);
        }

        private bool ValidateGoodPath(DocumentType type, string goodPath)
        {
            if (type == DocumentType.Number)
            {
                return true;
            }

            string[] splittedArray = goodPath.Split('\\');

            if (splittedArray.Count() != 6)
            {
                return false;
            }

            return true;
        }

        private bool CopyFile(string sourceFolder, string destinationFileNameWithPath, string sourceFileNameWithPath)
        {
            try
            {

                if (!Directory.Exists(sourceFolder))
                {
                    return false;
                }

                if (!Directory.Exists(Path.GetDirectoryName(destinationFileNameWithPath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(destinationFileNameWithPath));
                }

                if (File.Exists(sourceFileNameWithPath))
                {
                    File.Copy(sourceFileNameWithPath, destinationFileNameWithPath, true);
                    TotalFilesCopied++;
                    counterFilesWithoutConflicts.Text = TotalFilesCopied.ToString();
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;

            }
        }

        private bool DeleteFile(string sourceFileNameWithPath)
        {
            try
            {
                File.Delete(sourceFileNameWithPath);
                TotalFilesDeleted++;
                return true;

            }
            catch (Exception)
            {
                return false;

            }
        }

        private bool UpdateDatabase(long attachmentMasterID, Type updateType, string newfilePath = "")
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataReader reader = null;
            string dynamicQueryForUpdate = string.Empty;

            try
            {
                if (updateType == Type.BadFileFound)
                {
                    //dynamicQueryForUpdate = string.Format(@"update tblattachmentmaster set ModifiedDate = GETDATE(), IsGoodPath = 0  where AttachmentMasterID = {0}", attachmentMasterID);
                    //IF UN COMMENT BELOW LINE THAN IT WILL UPDATE BAD FILE PATH IN DB WITH THE GOOD PATH
                    dynamicQueryForUpdate = string.Format(@"update tblattachmentmaster set ModifiedDate = GETDATE(), IsGoodPath = 1, FilePath = '{1}'  where AttachmentMasterID = {0}", attachmentMasterID, newfilePath);
                }

                else if (updateType == Type.GoodFileFound)
                {
                    dynamicQueryForUpdate = string.Format(@"update tblattachmentmaster set ModifiedDate = GETDATE(), IsGoodPath = 1  where AttachmentMasterID = {0}", attachmentMasterID);
                }

                else if (updateType == Type.FileNotFound)
                {
                    dynamicQueryForUpdate = string.Format(@"update tblattachmentmaster set ModifiedDate = GETDATE(), IsGoodPath = 2  where AttachmentMasterID = {0}", attachmentMasterID);
                }
                else if (updateType == Type.MisplacedFileFound)
                {
                    dynamicQueryForUpdate = string.Format(@"update tblattachmentmaster set ModifiedDate = GETDATE(), IsGoodPath = 4  where AttachmentMasterID = {0}", attachmentMasterID);
                }
                else if (updateType == Type.FileWithEmptyGoodPath)
                {
                    dynamicQueryForUpdate = string.Format(@"update tblattachmentmaster set ModifiedDate = GETDATE(), IsGoodPath = 6  where AttachmentMasterID = {0}", attachmentMasterID);
                }

                conn = new SqlConnection(getConnectionString);
                cmd = new SqlCommand
                {
                    Connection = conn
                };

                conn.Open();

                cmd.CommandText = dynamicQueryForUpdate;
                cmd.CommandType = CommandType.Text;
                reader = cmd.ExecuteReader();
                return true;
            }

            catch (Exception)
            {
                return false;
            }

            finally
            {
                CloseAndResetConnection(conn, cmd, reader);
            }
        }

        #endregion

        #region Other UI Related Methods

        private void LoadToListView(long attachmentMasterID, string oldDBPath, Type updateType, string newDBPath = "", string goodPath = "", string badPath = "")
        {
            AllFilesList.View = View.Details;

            if (updateType == Type.BadFileFound)
            {
                ListViewItem li = new ListViewItem(new string[] { attachmentMasterID.ToString(), goodPath, badPath, oldDBPath, newDBPath })
                {
                    BackColor = System.Drawing.Color.DarkRed,
                    ForeColor = System.Drawing.Color.White
                };
                AllFilesList.Items.Add(li);
            }

            else if (updateType == Type.GoodFileFound)
            {
                ListViewItem li = new ListViewItem(new string[] { attachmentMasterID.ToString(), goodPath, "N/A", oldDBPath, "N/A" })
                {
                    BackColor = System.Drawing.Color.DarkGreen,
                    ForeColor = System.Drawing.Color.White
                };
                AllFilesList.Items.Add(li);
            }

            else if (updateType == Type.FileNotFound)
            {
                ListViewItem li = new ListViewItem(new string[] { attachmentMasterID.ToString(), "N/A", "N/A", oldDBPath, "N/A" })
                {
                    BackColor = System.Drawing.Color.Purple,
                    ForeColor = System.Drawing.Color.White
                };
                AllFilesList.Items.Add(li);
            }

            else if (updateType == Type.MisplacedFileFound)
            {
                ListViewItem li = new ListViewItem(new string[] { attachmentMasterID.ToString(), "N/A", "N/A", oldDBPath, "N/A" })
                {
                    BackColor = System.Drawing.Color.DarkOrange,
                    ForeColor = System.Drawing.Color.White
                };
                AllFilesList.Items.Add(li);
            }

            else if (updateType == Type.FileWithEmptyGoodPath)
            {
                ListViewItem li = new ListViewItem(new string[] { attachmentMasterID.ToString(), goodPath, "N/A", oldDBPath, "N/A" })
                {
                    BackColor = System.Drawing.Color.DarkSlateBlue,
                    ForeColor = System.Drawing.Color.White
                };
            }

            Application.DoEvents();

        }

        private void ComputeTotalCounters(Type counterType)
        {
            if (counterType == Type.BadFileFound)
            {
                TotalConflictedFilePathUpdatedInDb++;
                TotalGoodFiles++;
                TotalBadFiles++;
                TotalFilesRemainingToBeProcessed--;
                TotalFilesAlreadyProcessed++;
            }

            else if (counterType == Type.GoodFileFound)
            {
                TotalGoodFiles++;
                TotalFilesRemainingToBeProcessed--;
                TotalFilesAlreadyProcessed++;
            }

            else if (counterType == Type.FileNotFound)
            {
                TotalFilesDoesNotExists++;
                TotalFilesRemainingToBeProcessed--;
                TotalFilesAlreadyProcessed++;
            }
            else if (counterType == Type.MisplacedFileFound)
            {
                TotalFilesMisplaced++;
                TotalFilesRemainingToBeProcessed--;
                TotalFilesAlreadyProcessed++;
            }
            else if (counterType == Type.FileWithEmptyGoodPath)
            {
                TotalBadFiles++;
                TotalFilesRemainingToBeProcessed--;
                TotalFilesAlreadyProcessed++;
            }
        }

        private bool ProcessMoreOrExit()
        {
            timer1.Enabled = false;
            SystemSounds.Beep.Play();

            DialogResult dialogResult = MessageBox.Show("Do you want to process more " + filesToProcess + " records. ", "Continue/Exit", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                btnReset.Enabled = false;
                btnStart.Enabled = true;
                return true;
            }
            else if (dialogResult == DialogResult.No)
            {
                btnReset.Enabled = true;
                btnStart.Enabled = false;
                return false;
            }

            return false;
        }

        private void UpdateUI()
        {
            countertotalFilesProcessed.Text = TotalFilesProcessed.ToString();
            counterTotalFilesRemainingToProcessed.Text = TotalFilesRemainingToBeProcessed.ToString();
            counterTotalFilesAlreadyProcessed.Text = TotalFilesAlreadyProcessed.ToString();
            counterFilesNotFound.Text = TotalFilesDoesNotExists.ToString();
            counterMisplacedFiles.Text = TotalFilesMisplaced.ToString();
            counterFilesWithConflicts.Text = TotalBadFiles.ToString();
            counterFilesWithoutConflicts.Text = TotalGoodFiles.ToString();
            counterFilesCopied.Text = TotalFilesCopied.ToString();
            counterFilesDeleted.Text = TotalFilesDeleted.ToString();
            counterTotalRecordsUpdatedInDb.Text = TotalConflictedFilePathUpdatedInDb.ToString();
            lblLastFileProcessed.Text = LastFileProcess.ToString();


            counterFilesWithoutConflicts.ForeColor = System.Drawing.Color.DarkGreen;
            counterFilesWithConflicts.ForeColor = System.Drawing.Color.DarkRed;
            counterMisplacedFiles.ForeColor = System.Drawing.Color.DarkOrange;
            counterFilesNotFound.ForeColor = System.Drawing.Color.Purple;

            Application.DoEvents();
        }

        private void ResetUI()
        {
            countertotalFilesProcessed.Text = "0";
            counterFilesCopied.Text = "0";
            counterFilesDeleted.Text = "0";
            counterTotalRecordsUpdatedInDb.Text = "0";
            counterMisplacedFiles.Text = "0";
            lblLastFileProcessed.Text = "0";

            counterMisplacedFiles.ForeColor = System.Drawing.Color.Black;
            counterFilesWithConflicts.ForeColor = System.Drawing.Color.Black;
            counterFilesWithoutConflicts.ForeColor = System.Drawing.Color.Black;
            counterFilesCopied.ForeColor = System.Drawing.Color.Black;
            counterFilesDeleted.ForeColor = System.Drawing.Color.Black;
            counterTotalRecordsUpdatedInDb.ForeColor = System.Drawing.Color.Black;
            lblLastFileProcessed.ForeColor = System.Drawing.Color.Black;
            counterFilesNotFound.ForeColor = System.Drawing.Color.Black;

            TotalFilesProcessed = 0;
            TotalFilesCopied = 0;
            TotalFilesDeleted = 0;
            TotalConflictedFilePathUpdatedInDb = 0;
            TotalBadFiles = 0;
            TotalFilesRemainingToBeProcessed = OriginalTotalFilesRemainingToBeProcessed;
            TotalFilesAlreadyProcessed = OriginalTotalFilesAlreadyProcessed;
            TotalFilesDoesNotExists = OriginalTotalFilesDoesNotExists;
            TotalFilesMisplaced = 0;
            second = 0;
            minute = 0;
            hour = 0;
            lblTimer.Text = "00:00:00";
            timer1.Enabled = false;

            btnReset.Enabled = true;
            btnStart.Enabled = true;
            AllFilesList.Items.Clear();
            TotalCountOfFiles();
            counterFilesWithConflicts.Text = TotalBadFiles.ToString();
            counterFilesWithoutConflicts.Text = TotalGoodFiles.ToString();
            counterTotalFilesRemainingToProcessed.Text = OriginalTotalFilesRemainingToBeProcessed.ToString();
            counterTotalFilesAlreadyProcessed.Text = OriginalTotalFilesAlreadyProcessed.ToString();
            counterFilesNotFound.Text = OriginalTotalFilesDoesNotExists.ToString();
            counterMisplacedFiles.Text = TotalFilesMisplaced.ToString();
            Application.DoEvents();
        }

        #endregion

        #region Helper Methods
        private void Logger(Type logType, long attachmentMasterID, string oldDBPath = "", string goodPath = "", string badPath = "", string newDBPath = "")
        {
            string folderName = DateTime.Today.Year.ToString() + "-" + DateTime.Today.Month.ToString();
            string root = string.Format(@"C:\FolderStructureLogs\{0}", folderName);

            if (logType == Type.BadFileFound)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }

                string fileName = folderName + "-" + DateTime.Today.Day.ToString() + "_BadFiles.txt";

                root += @"\" + fileName;

                using (StreamWriter streamWriter = new StreamWriter(root, true))
                {
                    streamWriter.WriteLine("               Time: \t\t" + DateTime.Now.ToString());
                    streamWriter.WriteLine("AttachmentMasterID : \t\t" + attachmentMasterID);
                    streamWriter.WriteLine("          Bad Path : \t\t" + badPath);
                    streamWriter.WriteLine("         Good Path : \t\t" + goodPath);
                    streamWriter.WriteLine("          Old Path : \t\t" + oldDBPath);
                    streamWriter.WriteLine("          New Path : \t\t" + newDBPath + "\n");
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }

            else if (logType == Type.GoodFileFound)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }

                string fileName = folderName + "-" + DateTime.Today.Day.ToString() + "_GoodFiles.txt";

                root += @"\" + fileName;

                using (StreamWriter streamWriter = new StreamWriter(root, true))
                {
                    streamWriter.WriteLine("               Time: \t\t" + DateTime.Now.ToString());
                    streamWriter.WriteLine("AttachmentMasterID : \t\t" + attachmentMasterID + "\n");
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }

            else if (logType == Type.FileNotFound)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }

                string fileName = folderName + "-" + DateTime.Today.Day.ToString() + "_NotFoundFiles.txt";

                root += @"\" + fileName;

                using (StreamWriter streamWriter = new StreamWriter(root, true))
                {
                    streamWriter.WriteLine("               Time: \t\t" + DateTime.Now.ToString());
                    streamWriter.WriteLine("AttachmentMasterID : \t\t" + attachmentMasterID);
                    streamWriter.WriteLine("Bad Path : \t\t" + oldDBPath + "\n");
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }
            else if (logType == Type.MisplacedFileFound)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }

                string fileName = folderName + "-" + DateTime.Today.Day.ToString() + "_MisplacedFoundFiles.txt";

                root += @"\" + fileName;

                using (StreamWriter streamWriter = new StreamWriter(root, true))
                {
                    streamWriter.WriteLine("               Time: \t\t" + DateTime.Now.ToString());
                    streamWriter.WriteLine("AttachmentMasterID : \t\t" + attachmentMasterID);
                    streamWriter.WriteLine("Bad Path : \t\t" + oldDBPath + "\n");
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }

            else if (logType == Type.FileWithEmptyGoodPath)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }

                string fileName = folderName + "-" + DateTime.Today.Day.ToString() + "_EmptyGoodPathFoundFiles.txt";

                root += @"\" + fileName;

                using (StreamWriter streamWriter = new StreamWriter(root, true))
                {
                    streamWriter.WriteLine("               Time: \t\t" + DateTime.Now.ToString());
                    streamWriter.WriteLine("AttachmentMasterID : \t\t" + attachmentMasterID);
                    streamWriter.WriteLine("Bad Path : \t\t" + oldDBPath + "\n");
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }
            else if (logType == Type.DeletedFilesLogging)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }

                string fileName = folderName + "-" + DateTime.Today.Day.ToString() + "_DeletedFiles.txt";

                root += @"\" + fileName;

                using (StreamWriter streamWriter = new StreamWriter(root, true))
                {
                    streamWriter.WriteLine("               Time: \t\t" + DateTime.Now.ToString() + "\t\tAttachmentMasterID: \t\t" + attachmentMasterID);
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }
        }
        private DocumentType GetDocumentType(string docNo)
        {
            string[] result = docNo.Split('-');
            if (result.Count() >= 4)
            {
                return DocumentType.NumberAndLetter;
            }
            else
            {
                return DocumentType.Number;
            }
        }
        private KeyValuePair<long, TableInfo> GetTableInfo(long attachmentType)
        {
            KeyValuePair<long, TableInfo> result = list.Where(d => d.Key == attachmentType).FirstOrDefault();
            return result;
        }
        private void DictionaryofAttachmentType()
        {
            //list.Add(1610, new TableInfo { tableName = "tblAPVoucher1", columnNameId = "APVoucherID", columnDocNo = "APVoucherNo" });
            //list.Add(1601, new TableInfo { tableName = "tblReceivingParts", columnNameId = "ReceivingPartsID", columnDocNo = "ReceivingPartsNo" });
            //list.Add(1606, new TableInfo { tableName = "tblPOParts", columnNameId = "POPartsID", columnDocNo = "POPartsNo" });
            //list.Add(1625, new TableInfo { tableName = "tblCashDeposit", columnNameId = "CashDepositID", columnDocNo = "CashDepositNo" });
            //list.Add(1612, new TableInfo { tableName = "tblPaymentVoucher", columnNameId = "PaymentVoucherID", columnDocNo = "PaymentVoucherNo" });   //DONE
            //list.Add(1640, new TableInfo { tableName = "tblCreditRelease", columnNameId = "CreditReleaseID", columnDocNo = "CreditReleaseID" });   //DONE
            //list.Add(1617, new TableInfo { tableName = "tblPartsTransfer", columnNameId = "PartsTransferID", columnDocNo = "PartsTransferNo" });   //DONE
            //list.Add(1624, new TableInfo { tableName = "tblCashReceipt", columnNameId = "CashReceiptID", columnDocNo = "CashReceiptNo" });   //DONE
            //list.Add(1608, new TableInfo { tableName = "tblExpenseVoucher", columnNameId = "ExpenseVoucherID", columnDocNo = "VoucherNo" });   //DONE
            //list.Add(1602, new TableInfo { tableName = "tblPODeptExpense", columnNameId = "PODeptExpenseID", columnDocNo = "PODeptExpenseNo" });   //DONE
            //list.Add(1605, new TableInfo { tableName = "tblPOSublets", columnNameId = "POSubletsID", columnDocNo = "POSubletsNo" });   //DONE
            //list.Add(1653, new TableInfo { tableName = "tblSupplier", columnNameId = "SupplierID", columnDocNo = "SupplierID" });   //DONE
            //list.Add(1652, new TableInfo { tableName = "tblCustomer", columnNameId = "CustomerID", columnDocNo = "CustomerID" });   //DONE
            //list.Add(1622, new TableInfo { tableName = "tblFixedAssetsMaster", columnNameId = "FixedAssetsMasterID", columnDocNo = "FixedAssetsMasterID" });   //DONE
            //list.Add(1647, new TableInfo { tableName = "tblPartsMaster", columnNameId = "PartsMasterID", columnDocNo = "PartsMasterID" });   //DONE
            //list.Add(1633, new TableInfo { tableName = "tblEmployee", columnNameId = "EmployeeID", columnDocNo = "EmployeeID" });   //DONE
            //list.Add(1603, new TableInfo { tableName = "tblReceivingDeptExpense", columnNameId = "ReceivingDeptExpenseID", columnDocNo = "ReceivingDeptExpenseNo" });   //DONE
            //list.Add(1626, new TableInfo { tableName = "tblJournalEntry", columnNameId = "JournalEntryID", columnDocNo = "JournalEntryID" });   //DONE
            //list.Add(1620, new TableInfo { tableName = "tblVehicleSales", columnNameId = "VehicleSalesID", columnDocNo = "VehicleSalesNo" });   //DONE
            //list.Add(1615, new TableInfo { tableName = "tblReceivingEquipment", columnNameId = "ReceivingEquipmentID", columnDocNo = "ReceivingEquipmentNo" });   //DONE
            //list.Add(1613, new TableInfo { tableName = "tblPOEquipment", columnNameId = "POEquipmentID", columnDocNo = "POEquipmentNo" });   //DONE
            //list.Add(1604, new TableInfo { tableName = "tblReceivingSublets", columnNameId = "ReceivingSubletsID", columnDocNo = "ReceivingSubletsNo" });   //DONE
            //list.Add(1643, new TableInfo { tableName = "tblBankReconciliation", columnNameId = "BankReconciliationID", columnDocNo = "BankReconciliationNo" });   //DONE
            //list.Add(1607, new TableInfo { tableName = "tblReceivingVehicle", columnNameId = "ReceivingVehicleID", columnDocNo = "ReceivingVehicleNo" });   //DONE
            //list.Add(1621, new TableInfo { tableName = "tblPartsAdjustments", columnNameId = "PartsAdjustmentsID", columnDocNo = "PartsAdjustmentsNo" });   //DONE
            //list.Add(1611, new TableInfo { tableName = "tblPOVehicle", columnNameId = "POVehicleID", columnDocNo = "POVehicleNo" });   //DONE
            //list.Add(1614, new TableInfo { tableName = "tblPOFixedAsset", columnNameId = "POFixedAssetID", columnDocNo = "POFixedAssetNo" }); //DONE
            //list.Add(1609, new TableInfo { tableName = "tblReceivingFixedAssets", columnNameId = "ReceivingFixedAssetsID", columnDocNo = "ReceivingFixedAssetsNo" });     //DONE            
            list.Add(1618, new TableInfo { tableName = "tblSalesFrontCounter", columnNameId = "SalesFrontCounterID", columnDocNo = "SalesFrontCounterNo" });     //IN PROGRESS
        }
        private string FindeDocNobyFileName(long attachmentType, long associatedSourceId)
        {
            string colDocNo = string.Empty;

            KeyValuePair<long, TableInfo> result = GetTableInfo(attachmentType);
            if (result.Key == 0)
            {
                return null;
            }
            string tableName = result.Value.tableName;
            string columnNameID = result.Value.columnNameId;
            colDocNo = result.Value.columnDocNo;

            SqlConnection conn1 = null;
            SqlCommand cmd1 = null;

            try
            {
                conn1 = new SqlConnection(getConnectionString);
                cmd1 = new SqlCommand
                {
                    Connection = conn1
                };
                conn1.Open();
                cmd1.CommandText = string.Format(@"select {0}  from {1} where {2}={3}", colDocNo, tableName, columnNameID, associatedSourceId);
                cmd1.CommandType = CommandType.Text;

                string docNo = cmd1.ExecuteScalar().ToString();

                if (string.IsNullOrEmpty(docNo))
                {
                    colDocNo = result.Value.columnDocNo;
                    cmd1.CommandText = string.Format(@"select {0}  from {1} where {2}={3}", colDocNo, tableName, columnNameID, associatedSourceId);
                    cmd1.CommandType = CommandType.Text;
                    docNo = cmd1.ExecuteScalar().ToString();
                }

                return docNo != null ? docNo : string.Empty;

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                CloseAndResetConnection(conn1, cmd1, null);
            }
        }

        private void CloseAndResetConnection(SqlConnection conn, SqlCommand cmd, SqlDataReader reader)
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

        #endregion

        private int second = 0;
        private int minute = 0;
        private int hour = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            second++;
            if (second == 60)
            {
                second = 0;
                minute++;
            }

            if (minute == 60)
            {
                minute = 0;
                hour++;
            }

            string secondString = second.ToString().PadLeft(2, '0');
            string minuteString = minute.ToString().PadLeft(2, '0');
            string hourString = hour.ToString().PadLeft(2, '0');

            lblTimer.Text = hourString + ":" + minuteString + ":" + secondString;
        }
    }
}