using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
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
                ErrorMessageDialog errorMessageDialog = new ErrorMessageDialog("Unable to update the server list", ex.ToString(), true);
                errorMessageDialog.ShowDialog();
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
                    ErrorMessageDialog errorMessageDialog = new ErrorMessageDialog("Unable to load the server list", ex.ToString(), true);
                    errorMessageDialog.ShowDialog();
                }
            }
            else
            {
                ErrorMessageDialog errorMessageDialog = new ErrorMessageDialog($"Could not find server list file", path, true);
                errorMessageDialog.ShowDialog();
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
            ServiceController serviceController = new ServiceController();
            serviceController.ServiceName = serviceName;
            serviceController.MachineName = computerName;
            string result = serviceController.Status.ToString();

            return result;
        }

        public static string GetServiceMemoryUsage(string computerName, string serviceName)
        {
            try
            {
                ServiceController serviceController = new ServiceController(serviceName, computerName);

                if (serviceController.Status != ServiceControllerStatus.Running)
                {
                    return "-";
                }

                string query = $"SELECT ProcessId FROM Win32_Service WHERE Name='{serviceName}'";
                System.Management.ManagementScope scope = new System.Management.ManagementScope($"\\\\{computerName}\\root\\cimv2");
                System.Management.ObjectQuery objectQuery = new System.Management.ObjectQuery(query);
                System.Management.ManagementObjectSearcher searcher = new System.Management.ManagementObjectSearcher(scope, objectQuery);
                System.Management.ManagementObjectCollection results = searcher.Get();

                foreach (System.Management.ManagementObject obj in results)
                {
                    uint processId = (uint)obj["ProcessId"];

                    if (processId == 0)
                    {
                        return "-";
                    }

                    string processQuery = $"SELECT WorkingSetSize FROM Win32_Process WHERE ProcessId={processId}";
                    System.Management.ManagementObjectSearcher processSearcher = new System.Management.ManagementObjectSearcher(scope, new System.Management.ObjectQuery(processQuery));

                    foreach (System.Management.ManagementObject processObj in processSearcher.Get())
                    {
                        ulong workingSetBytes = (ulong)processObj["WorkingSetSize"];
                        double memoryMB = workingSetBytes / (1024.0 * 1024.0);

                        return memoryMB.ToString("F1");
                    }
                }
            }
            catch
            {
                return "N/A";
            }

            return "N/A";
        }

        public static int GetSettingAutoRefreshMinutes()
        {
            string value = ConfigurationManager.AppSettings["AutoRefreshMinutes"];

            if (int.TryParse(value, out int minutes) && minutes > 0)
            {
                return minutes;
            }

            return 5;
        }

        public static string GetSettingTheme()
        {
            string theme = ConfigurationManager.AppSettings["Theme"];

            return string.IsNullOrEmpty(theme) ? "LightGray" : theme;
        }

        public static void UpdateSettingTheme(string theme)
        {
            UpdateSettingInAppConfig("Theme", theme);
        }

        public static Icon GetApplicationIcon()
        {
            string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources and Examples", "Settings.ico");

            if (File.Exists(iconPath))
            {
                return new Icon(iconPath);
            }

            return null;
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