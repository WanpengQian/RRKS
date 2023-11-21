using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace RemoveRegisterKeyService
{
    public partial class RemoveRegisterKeyService : ServiceBase
    {
        private long counter = Properties.Settings.Default.Interval;

        public RemoveRegisterKeyService()
        {
            InitializeComponent();
            eventLog1 = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("RemoveRegisterKeyServiceSource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "RemoveRegisterKeyServiceSource", "RemoveRegisterKeyServiceLog");
            }
            eventLog1.Source = "RemoveRegisterKeyServiceSource";
            eventLog1.Log = "RemoveRegisterKeyServiceLog";
        }

        protected override void OnStart(string[] args)
        {
            Timer timer = new Timer();
            timer.Interval = 60000; // 60 seconds
            timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            timer.Start();
            eventLog1.WriteEntry("Service Started.");
            eventLog1.WriteEntry("Interval: " + Properties.Settings.Default.Interval + " minutes");
            eventLog1.WriteEntry("Key: " + Properties.Settings.Default.Key);
        }

        public void OnTimer(object sender, ElapsedEventArgs args)
        {
            eventLog1.WriteEntry("Timer");
            counter--;
            if(counter <= 0)
            {
                counter = Properties.Settings.Default.Interval;
                RemoveRegisterKey();
            }
        }

        private void RemoveRegisterKey()
        {
            string keyName = Properties.Settings.Default.Key;
            eventLog1.WriteEntry("Check values of register key [ " + keyName + " ] and removed it.");
            RegistryKey localMachine = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey key64Bit = localMachine.OpenSubKey(keyName, true);

            if (key64Bit != null)
            {
                int count = 0;
                var namesArray = key64Bit.GetValueNames();
                foreach (string valueName in namesArray)
                {
                    try
                    {
                        key64Bit.DeleteValue(valueName);
                        eventLog1.WriteEntry(valueName + " is removed.");
                        count++;
                    }
                    catch (Exception e)
                    {
                        eventLog1.WriteEntry(e.ToString());
                    }
                }
                if( count > 0)
                {
                    try
                    {
                        this.RestartWindowsService("TermService");
                        eventLog1.WriteEntry("TermService is restarted.");
                    }
                    catch (Exception e)
                    {
                        eventLog1.WriteEntry(e.ToString());
                    }
                }
            }
        }

        private void RestartWindowsService(string serviceName)
        {
            ServiceController serviceController = new ServiceController(serviceName);
            try
            {
                if ((serviceController.Status.Equals(ServiceControllerStatus.Running)) || (serviceController.Status.Equals(ServiceControllerStatus.StartPending)))
                {
                    serviceController.Stop();
                }
                serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
                serviceController.Start();
                serviceController.WaitForStatus(ServiceControllerStatus.Running);
            }
            catch(Exception e) 
            {
                eventLog1.WriteEntry(e.ToString());
            }
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("Service Stopped.");
        }
    }
}
