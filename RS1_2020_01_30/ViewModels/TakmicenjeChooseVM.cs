using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2020_01_30.ViewModels
{
    public class TakmicenjeChooseVM
    {
        public int SkolaID { get; set; }
        public string SkolaNaziv { get; set; }
        public string RazredNaziv { get; set; } //da mi se lakse snaci

        public List<Rows> rows { get; set; }

        public class Rows
        {
            public int TakmicenjeId { get; set; }
            public int PredmetId { get; set; }
            public string PredmetNaziv { get; set; }
            public int Razred { get; set; }
            public string Datum { get; set; }
            public int BrojUcesnikaKojiNisuPristupili { get; set; }
            public int NajboljiUcesnikId { get; set; }
            public string NajboljiUcesnikSkola { get; set; }
            public string NajboljiUcesnikOdjeljenje{ get; set; }
            public string NajboljiUcesnikImePrezime{ get; set; }

        }
    }
}
