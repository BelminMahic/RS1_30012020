﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2020_01_30.EntityModels
{
    public class TakmicenjeUcesnik
    {
        public int Id { get; set; } //TakmicenjeUcesnikId
        public Takmicenje Takmicenje { get; set; }
        public int TakmicenjeId { get; set; }
        public OdjeljenjeStavka OdjeljenjeStavka { get; set; }
        public int OdjeljenjeStavkaId { get; set; }
        public int Bodovi { get; set; }
        public bool UcesnikIsPristupio { get; set; }
    }
}
