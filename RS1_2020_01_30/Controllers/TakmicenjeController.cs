using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RS1_2020_01_30.EF;
using RS1_2020_01_30.ViewModels;

namespace RS1_2020_01_30.Controllers
{
    public class TakmicenjeController : Controller
    {
        private readonly MojContext db;

        public TakmicenjeController(MojContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            //PROBLEM, moram dohvatiti razrede koji nemaju svoj id, posto se ID veze za OdjeljenjeID radi cega moram praviti stringove razreda

            var Razredi = new List<string> { "", "1", "2", "3", "4" };

            var index = new TakmicenjeIndexVM()
            {
                domacini = db.Skola.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem {
                    Value = x.Id.ToString(),
                    Text = x.Naziv
                }).OrderBy(x=>x.Text).ToList(),
               razredi=Razredi.ConvertAll(
                    i=>
                    {
                        return new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                        {
                            Text = i,
                            Value = i,
                            Selected = false
                        };
                    }
                   
                   
                   )
            };
            

            return View(index);
        }

        public IActionResult Choose(TakmicenjeIndexVM model)
        {
            var skola = db.Skola.Find(model.SkolaId);

            var choose = new TakmicenjeChooseVM
            {
                SkolaID = skola.Id,
                SkolaNaziv = skola.Naziv,
                RazredNaziv = model.RazredID,
                rows = db.Takmicenje.Where(x => x.Skola.Id == model.SkolaId).Select(
                    x => new TakmicenjeChooseVM.Rows
                    {
                        TakmicenjeId=x.Id,
                        PredmetId=x.PredmetId,
                        PredmetNaziv=x.Predmet.Naziv,
                        Razred=x.Predmet.Razred,
                        Datum=x.Datum.ToString("dd/MM/yyyy"),
                        BrojUcesnikaKojiNisuPristupili=db.TakmicenjeUcesnik
                                                        .Where(i=>i.TakmicenjeId==x.Id && x.IsPristupio==false).Count()

                    }
                    ).ToList()
            };

            return View(choose);
        }
    }
}
