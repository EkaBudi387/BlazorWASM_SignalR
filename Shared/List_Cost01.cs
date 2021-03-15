using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWASM_SignalR.Shared
{
    public class List_Cost01
    {
        [Key]
        public int Id_Cost01 { get; set; }
        public DateTime? IDT_01 { get; set; }
        public string UserID_01 { get; set; }
        public string Item { get; set; }
        public string Unit { get; set; }
        public string Weight { get; set; }
        public string Cost { get; set; }
        public string Version { get; set; }
        public string Remarks { get; set; }
    }
}
