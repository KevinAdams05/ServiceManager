using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceManager
{
    /// <summary>
    ///  This is my attempt to decouple the logic from the UI.
    ///  This will make it easier if I every want to make this a web app or mobile app.
    ///  Still a work in progress.
    /// </summary>
    public static class Utility
    {
        public static int GetSettingDefaultSortColumn()
        {
            int sortColumn = Convert.ToInt32(ConfigurationManager.AppSettings["DefaultSortColumn"]);

            return sortColumn;
        }

        public static void UpdateSettingDefaultSortColumn(int sortColumn)
        {
            UpdateSettingInAppConfig("DefaultSortColumn", sortColumn);
        }

        public static string GetSettingServerListFilePath()
        {
            string returnValue;

            // IF there is a ServerListFilePath THEN the application will use that ELSE it looks in the runtime directory
            string serverListPathFromConfig = ConfigurationManager.AppSettings["ServerListFilePath"];

            if (!string.IsNullOrEmpty(serverListPathFromConfig))
            {
                returnValue = serverListPathFromConfig;
            }
            else
            {
                const string fileName = "list.json";
                string folder = AppDomain.CurrentDomain.BaseDirectory;
                returnValue = folder + fileName;
            }

            return returnValue;
        }

        public static void UpdateServerList(List<Server> servers)
        {
            try
            {
                JsonSerialization.WriteToJsonFile(GetSettingServerListFilePath(), servers);
            }
            catch (Exception ex)
            {
                ErrorMessageDialog formServerList = new ErrorMessageDialog("Unable to update the server list", ex.ToString(), true);
                formServerList.ShowDialog();
            }
        }

        public static List<Server> LoadServerList(string path = null)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                path = GetSettingServerListFilePath();
            }

            List<Server> servers = new List<Server>();

            if (DoesServerListExist(path))
            {
                try
                {
                    servers = JsonSerialization.ReadFromJsonFile<List<Server>>(path);
                }
                catch (Exception ex)
                {
                    ErrorMessageDialog formServerList = new ErrorMessageDialog("Unable to load the server list", ex.ToString(), true);
                    formServerList.ShowDialog();
                }
            }
            else
            {
                ErrorMessageDialog formServerList = new ErrorMessageDialog($"Could not find server list file", path, true);
                formServerList.ShowDialog();
            }

            return servers;
        }

        public static void GenerateAndSaveTestServerList()
        {
            Server testServer = new Server();
            testServer.EnvironmentName = "TEST";
            testServer.ServerName = "TESTSERVER01";
            testServer.ServerType = ServerTypes.Service;
            testServer.ServiceName = "MSSQLSERVER";

            List<Server> serverList = new List<Server>();
            serverList.Add(testServer);

            UpdateServerList(serverList);
        }

        public static bool DoesServerListExist(string path)
        {
            return File.Exists(path);
        }

        /// <summary>
        /// Performs an IISReset on the specified server.
        /// </summary>
        /// <param name="computerName"></param>
        /// <param name="action"></param>
        public static void PerformWebServerAction(string computerName, string action)
        {
            if (!string.IsNullOrEmpty(action))
            {
                Process process = new Process();
                process.StartInfo.FileName = "iisreset.exe";
                process.StartInfo.Arguments = computerName;
                process.StartInfo.Arguments = process.StartInfo.Arguments + " /" + action;
                process.Start();
            }
        }

        public static string ServiceStop(string computerName, string serviceName)
        {
            ServiceController serviceController = new ServiceController();
            serviceController.ServiceName = serviceName;
            serviceController.MachineName = computerName;

            string result = serviceController.Status.ToString();

            if (serviceController.Status == ServiceControllerStatus.Running)
            {
                serviceController.Stop();
                serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
                result = serviceController.Status.ToString();
            }

            return result;
        }

        public static string ServiceStart(string computerName, string serviceName)
        {
            ServiceController serviceController = new ServiceController();
            serviceController.ServiceName = serviceName;
            serviceController.MachineName = computerName;
            string result = serviceController.Status.ToString();

            if (serviceController.Status == ServiceControllerStatus.Stopped)
            {
                serviceController.Start();
                serviceController.WaitForStatus(ServiceControllerStatus.Running);
                result = serviceController.Status.ToString();
            }

            return result;
        }

        public static string GetServiceStatus(string computerName, string serviceName)
        {
            ServiceController sc = new ServiceController();
            sc.ServiceName = serviceName;
            sc.MachineName = computerName;
            string result = sc.Status.ToString();

            return result;
        }

        private static void UpdateSettingInAppConfig(string setting, object value)
        {
            Configuration configurationManager = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            configurationManager.AppSettings.Settings.Remove(setting);
            configurationManager.AppSettings.Settings.Add(setting, value.ToString());
            configurationManager.Save(ConfigurationSaveMode.Minimal);
        }
    }
}