using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlazorWASM_SignalR.Shared
{
    public class List_M6
    {
        [Key]
        public int Id_M6 { get; set; }
        public string M6_Analysis { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
    }
}
