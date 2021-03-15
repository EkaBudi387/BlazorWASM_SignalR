using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWASM_SignalR.Shared
{
    public class List_Proj
    {
        [Key]
        public int Id_Proj { get; set; }
        public string Proj_Name { get; set; }
        public string Remarks { get; set; }
    }
}
