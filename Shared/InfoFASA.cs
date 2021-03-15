using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWASM_SignalR.Shared
{
    public class InfoFASA
    {

        [Key]
        public int IfFASA_id { get; set; }

        //Data Entry Details
        public DateTime? IDT_00 { get; set; }
        public string UserID_00 { get; set; }

        //From MySQL
        public DateTime? Prod_IDT { get; set; }
        public string Proj { get; set; }
        public string SA_SN { get; set; }
        public string SA_PN { get; set; }
        public string PName { get; set; }
        public string SA_SO { get; set; }
        public string Prod_Line { get; set; }
        public string Prod_Station { get; set; }
        public string Prod_Def { get; set; }
        public string Prod_ToolID { get; set; }
        public string Prod_OprID { get; set; }
        public DateTime? Dt_Scrap { get; set; }
        public string Scrap_Status { get; set; }


        //Failure Analysis
        public DateTime? IDT_01 { get; set; }
        public string UserID_01 { get; set; }
        public string DetDefect { get; set; }
        public string DefArea { get; set; }
        public string FsRefScrap_Id { get; set; }
        public string Remarks_01 { get; set; }


        //CAPA - Corrective & preventive action
        public DateTime? IDT_02 { get; set; }
        public string UserID_02 { get; set; }


        //Material, Man, Machine, method, mother-nature
        public string M6 { get; set; }
        public string DefStation { get; set; }
        public string DefEmpID { get; set; }
        public string FsRefAct_Id { get; set; }
        public string Remarks_02 { get; set; }


        //Closure
        public DateTime? IDT_03 { get; set; }
        public string UserID_03 { get; set; }
        public string FsRefFol_Id { get; set; }
        public string StaFollow { get; set; }
        public string Remarks_03 { get; set; }
    }
}
