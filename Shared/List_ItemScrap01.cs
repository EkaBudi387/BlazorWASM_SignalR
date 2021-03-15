using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWASM_SignalR.Shared
{
    public class List_ItemScrap01
    {
        [Key]
        public int Id_ItemScrap01 { get; set; }
        public string ProjName { get; set; }
        public string ScrapItem { get; set; }
        public string Unit { get; set; }
        public string CostVer { get; set; }
    }
}
