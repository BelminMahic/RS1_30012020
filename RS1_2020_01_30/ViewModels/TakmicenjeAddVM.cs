using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2020_01_30.ViewModels
{
    public class TakmicenjeAddVM
    {
        public int SkolaId { get; set; }
        public string SkolaNaziv { get; set; }
        public List<SelectListItem> predmeti { get; set; }
        public string PredmetId { get; set; }
        public List<SelectListItem> razredi { get; set; }
        public int RazredID { get; set; }
        public DateTime Datum { get; set; }
    }
}
