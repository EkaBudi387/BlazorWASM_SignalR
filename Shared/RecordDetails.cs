using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWASM_SignalR.Shared
{
    public class RecordDetails
    {

        [Key]

        public int No { get; set; }

        public DateTime DateIn { get; set; }

        public string SA_SN { get; set; }

        public string SA_PN { get; set; }

        public string Defect_Item { get; set; }

        public string Detail_Defect { get; set; }


    }
}
