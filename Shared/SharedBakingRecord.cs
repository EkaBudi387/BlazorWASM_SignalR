using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWASM_SignalR.Shared
{
    public class SharedBakingRecord
    {
        [Key]

        public string SN { get; set; }

        public string Bin_Code { get; set; }
    }
}
