using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlazorWASM_SignalR.Shared
{
    public class List_FA_DetDefect
    {
        [Key]
        public int Id_FA_DetDefect { get; set; }
        public string FA_DetDefect { get; set; }
    }
}
