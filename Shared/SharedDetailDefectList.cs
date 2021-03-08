using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWASM_SignalR.Shared
{
    public class SharedDetailDefectList
    {
        [Key]

        public string DetailDefect { get; set; }

    }
}
