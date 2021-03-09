﻿using System;
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

        public int Id { get; set; }

        public DateTime DateIn { get; set; }

        public string SN { get; set; }

        public string PN { get; set; }

        public string Last_Bin_Code { get; set; }
    }
}
