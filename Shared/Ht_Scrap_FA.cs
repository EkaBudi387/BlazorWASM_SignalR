using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWASM_SignalR.Shared
{
    public class Ht_Scrap_FA
    {
        public int Id_Scrap_FA { get; set; }
        public DateTime? IDT_00 { get; set; }
        public string FsRefScrap_Id { get; set; }
        public string Scrap_item { get; set; }
        //Weight, meter, pcs
        public string Scrap_Unit { get; set; }
        //Quantity to be scrap
        public string Scrap_qty { get; set; }
    }
}
