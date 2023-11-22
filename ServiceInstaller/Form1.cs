using System;
using System.Linq;
using System.Windows.Forms;
using System.Configuration.Install;
using System.ServiceProcess;
using System.Management;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32;
using System.Data;
using System.Reflection;
using System.Drawing;

using AssemblyInfo;
using System.Collections.Generic;

namespace ServiceInstaller
{
    public partial class Form1 : Form
    {
        private const string mServiceName = "RemoveRegisterKeyService";
        private DataTableInfo dtInfo = new DataTableInfo();
        private DataTableLog dtLog = new DataTableLog();

        public Form1()
        {
            InitializeComponent();
            refreshStatus();
            dataGridView1.DataSource = dtInfo;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            dataGridView1.AllowUserToAddRows = false;

            dataGridView2.DataSource = dtLog;
            dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView2.Columns[1].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            dataGridView2.AllowUserToAddRows = false;

            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            var linkTimeLocal = Utils.GetLinkerTime(assembly);
            lblVersion.Text = "Ver. " + fvi.FileVersion + ", Build Date: " + linkTimeLocal;
        }

        private void refreshLog(int limit = -1)
        {
            string logName = "RemoveRegisterKeyServiceLog";
            dtLog.Clear();
            Application.DoEvents();
            if (!EventLog.Exists(logName))
            {
                MessageBox.Show(logName + " is not exists.");
                return;
            }
            try
            {
                EventLog log = new EventLog(logName);
                var seq = 0;
                var entries = log.Entries.Cast<EventLogEntry>()
                                            .Select(x => new
                                            {
                                                SequenceNo = ++seq,
                                                x.TimeGenerated,
                                                x.Message
                                            }).ToList()
                                            .OrderByDescending(x => x.TimeGenerated)
                                            .AsQueryable();
                if (limit > 0)
                    entries = entries.Take(limit);

                foreach (var entry in entries)
                {
                    dtLog.AddRow(entry.SequenceNo, entry.TimeGenerated, entry.Message);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error!");
            }
        }

        private Dictionary<ServiceControllerStatus, string> ServiceControllerStatusDict = new Dictionary<ServiceControllerStatus, string>
        {
            {ServiceControllerStatus.ContinuePending, "ContinuePending"},
            {ServiceControllerStatus.Paused, "Paused"},
            {ServiceControllerStatus.PausePending, "PausePending"},
            {ServiceControllerStatus.Running, "Running"},
            {ServiceControllerStatus.StartPending, "StartPending"},
            {ServiceControllerStatus.Stopped, "Stopped"},
            {ServiceControllerStatus.StopPending, "StopPending"},
        };

        private Dictionary<ServiceStartMode, string> ServiceStartModeDict = new Dictionary<ServiceStartMode, string>
        {
            {ServiceStartMode.Manual, "Manual"},
            {ServiceStartMode.Automatic, "Automatic"},
            {ServiceStartMode.Disabled, "Disabled"},
            {ServiceStartMode.Boot, "Boot"},
            {ServiceStartMode.System, "System"},
        };

        private void refreshStatus()
        {
            enableButtons(false);
            dtInfo.Clear();
            Application.DoEvents();
            ServiceController sc = getServiceConstroller(mServiceName);
            if (sc != null)
            {
                dtInfo.AddRow("Installation Status", "Installed");

                DateTime? regdate = RegistryHelper.GetDateModified(RegistryHive.LocalMachine, "SYSTEM\\CurrentControlSet\\Services\\" + mServiceName);
                if(regdate != null)
                    dtInfo.AddRow("Installed Date", regdate.ToString());

                btnUninstall.Enabled = true;
                string path = GetExecutePath(mServiceName);
                txtPath.Text = path;

                dtInfo.AddRow("Service Status", ServiceControllerStatusDict[sc.Status]);
                if(sc.Status == ServiceControllerStatus.Running)
                {
                    string filename = System.IO.Path.GetFileNameWithoutExtension(path);
                    DateTime? startTime = GetStartTime(filename);
                    if (startTime != null)
                        dtInfo.AddRow("Service Start Date", startTime.ToString());
                }

                dtInfo.AddRow("Service Start Mode", ServiceStartModeDict[sc.StartType]);

                if (sc.Status == ServiceControllerStatus.Running)
                {
                    btnStopService.Enabled = true;
                }
                else if (sc.Status == ServiceControllerStatus.Stopped)
                {
                    btnStartService.Enabled = true;
                }
            }
            else
            {
                dtInfo.AddRow("Installation Status", "Not Install");
                btnInstall.Enabled = true;
            }

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Exe Files (*.exe)|*.exe" 
                + "|All Files(*.*) | *.*";
            dialog.Multiselect = false;
            dialog.InitialDirectory = Application.ExecutablePath;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filename = dialog.FileName;
                txtPath.Text = filename;
            }
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            installService(true);
        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Install the service, OK?", "Confirm", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                return;

            installService(false);
        }

        private void installService(bool install)
        {
            var path = txtPath.Text;
            if (path.Length <= 0)
            {
                MessageBox.Show("Please specify the file.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!System.IO.File.Exists(path))
            {
                MessageBox.Show("Cannot found the file.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (install)
                    ManagedInstallerClass.InstallHelper(new string[] { path });
                else
                    ManagedInstallerClass.InstallHelper(new string[] { "/u", path });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            finally
            {
                refreshStatus();
            }
        }

        private ServiceController getServiceConstroller(string serviceName)
        {
            ServiceController[] services = ServiceController.GetServices();
            var service = services.FirstOrDefault(s => s.ServiceName == serviceName);
            return service;
        }

        private void enableButtons(bool en)
        {
            btnInstall.Enabled = en;
            btnUninstall.Enabled = en;
            btnStartService.Enabled = en;
            btnStopService.Enabled = en;
        }

        private void btnStartService_Click(object sender, EventArgs e)
        {
            ServiceController sc = getServiceConstroller(mServiceName);
            if (sc != null)
                sc.Start();
            refreshStatus();
        }

        private void btnStopService_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Stop the service, OK?", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                return;

            ServiceController sc = getServiceConstroller(mServiceName);
            if (sc != null)
                sc.Stop();
            refreshStatus();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshStatus();
        }

        private string GetExecutePath(string name)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Service");
            var collection = searcher.Get().Cast<ManagementBaseObject>()
                .Where(mbo => mbo.GetPropertyValue("StartMode") != null)
                .Select(mbo => Tuple.Create(mbo.GetPropertyValue("Name").ToString(), mbo.GetPropertyValue("PathName").ToString()));
            foreach (var obj in collection)
            {
                if (obj.Item1 == name)
                    return obj.Item2.Trim('"');
            }
            return string.Empty;
        }

        private static DateTime? GetStartTime(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            DateTime retVal = DateTime.Now;
            foreach (Process p in processes)
                if (p.StartTime < retVal)
                    retVal = p.StartTime;

            if (processes.Length > 0)
                return retVal;
            else
                return null;
        }

        private void btnRefreshLog_Click(object sender, EventArgs e)
        {
            int limit = -1;
            if (chkLastLog100.Checked)
                limit = 100;
            refreshLog(limit);
        }

        private void btnAssemblyInfo_Click(object sender, EventArgs e)
        {
            var path = txtPath.Text;
            if (path.Length <= 0)
            {
                MessageBox.Show("Please specify the file.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!System.IO.File.Exists(path))
            {
                MessageBox.Show("Cannot found the file.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var inspector = new AssemblyInspector();
            var info = new AssemlyInfoWindow(path, inspector);
            info.Show();
        }

        private void clearAllLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear all the logs, OK?", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                return;

            EventLog log = new EventLog("RemoveRegisterKeyServiceLog");
            log.Clear();
            refreshLog();
        }
    }

    public class DataTableInfo : DataTable
    {
        public DataTableInfo()
        {
            Columns.Add(new DataColumn("Property", typeof(string)));
            Columns.Add(new DataColumn("Value", typeof(string)));
        }

        public void AddRow(string name, string value)
        {
            DataRow row = NewRow();
            row["Property"] = name;
            row["Value"] = value;
            Rows.Add(row);
        }
    }

    public class DataTableLog : DataTable
    {
        public DataTableLog()
        {
            Columns.Add(new DataColumn("No", typeof(int)));
            Columns.Add(new DataColumn("DateTime", typeof(DateTime)));
            Columns.Add(new DataColumn("Message", typeof(string)));
        }

        public void AddRow(int id, DateTime datetime, string msg)
        {
            DataRow row = NewRow();
            row["No"] = id;
            row["DateTime"] = datetime;
            row["Message"] = msg;
            Rows.Add(row);
        }

    }

}
