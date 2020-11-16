using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2020_01_30.ViewModels
{
    public class AjaxStavkeIndexVM
    {
        public int TakmicenjeId { get; set; }
        public bool IsZakljucano { get; set; }

        public List<Rows> rows { get; set; }

        public class Rows
        {
            public int TakmicenjeUcesnikId { get; set; }
            public int UcenikId { get; set; }
            public string Odjeljenje { get; set; }
            public int BrojUDnevniku { get; set; }
            public bool IsPristupio { get; set; }
            public int? Bodovi { get; set; }
        }
    }
}
