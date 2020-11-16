using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RS1_2020_01_30.EF;
using RS1_2020_01_30.ViewModels;

namespace RS1_2020_01_30.Controllers
{
    public class AjaxStavkeController : Controller
    {
        private readonly MojContext db;

        public AjaxStavkeController(MojContext db )
        {
            this.db = db;
        }
        public IActionResult Index(int id)
        {
            var takmicenje = db.Takmicenje.Find(id);

            var index = new AjaxStavkeIndexVM
            {
                TakmicenjeId = id,
                IsZakljucano = takmicenje.IsPristupio,
                rows = db.TakmicenjeUcesnik.Where(t=>t.TakmicenjeId==id)
                        .Select(
                        x => new AjaxStavkeIndexVM.Rows
                        {
                            TakmicenjeUcesnikId = x.Id,
                            UcenikId=x.OdjeljenjeStavka.Ucenik.Id,
                            Odjeljenje=x.OdjeljenjeStavka.Odjeljenje.Oznaka,
                            BrojUDnevniku=x.OdjeljenjeStavka.BrojUDnevniku,
                            Bodovi=x.Bodovi,
                            IsPristupio=x.UcesnikIsPristupio
                        }
                    ).ToList()

            };

            return View(index);
        }
    }
}
