using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWASM_SignalR.Shared
{
    public class List_ProdStation
    {
        [Key]
        public int Id_ProdSt { get; set; }
        public string Proj { get; set; }
        public string Process { get; set; }
        public string ProdStation { get; set; }
        public string Remarks { get; set; }
    }
}
