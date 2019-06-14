using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceManager
{
    public enum ServerTypes
    {
        Service,
        WebServer
    }

    [Serializable]
    public class Server
    {
        public string EnvironmentName { get; set; }

        public string ServerName { get; set; }

        public ServerTypes ServerType { get; set; }

        public string ServiceName { get; set; }
    }
}
