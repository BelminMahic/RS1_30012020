using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2020_01_30.ViewModels
{
    public class TakmicenjeIndexVM
    {
        public List<SelectListItem> domacini { get; set; }
        public int SkolaId { get; set; }
        public List<SelectListItem> razredi { get; set; }
        public string RazredID { get; set; } //cisto jer mi je lakse zamisliti da je sve kao id
    }
}
