using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWASM_SignalR.Shared
{
    public class List_PN
    {
        [Key]
        public int Id_PN { get; set; }
        public string PN { get; set; }
        public string PNname { get; set; }
        public string Remarks { get; set; }
    }
}
