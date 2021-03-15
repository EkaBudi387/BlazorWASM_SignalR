using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWASM_SignalR.Server.Models
{
    public class ServerModelMySql
    {
        public string SA_SN { get; set; }
        public string SA_PN { get; set; }
        public string State { get; set; }
        public string Line { get; set; }
        public string Staff { get; set; }
        public string Station { get; set; }
        public DateTime? Time { get; set; }
        public string Tool { get; set; }
        public string SO { get; set; }
    }
}
