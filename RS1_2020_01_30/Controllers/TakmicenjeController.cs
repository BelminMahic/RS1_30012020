using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2020_01_30.EF;
using RS1_2020_01_30.EntityModels;
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

            if (model.RazredID != null)
                choose.rows = choose.rows.Where(x => x.Razred.ToString() == model.RazredID).ToList();

            foreach (var item in choose.rows)
            {
                var best = db.TakmicenjeUcesnik.Where(x => x.TakmicenjeId == item.TakmicenjeId)
                                             .Include(x => x.OdjeljenjeStavka.Ucenik)
                                             .Include(x => x.OdjeljenjeStavka.Odjeljenje.Skola)
                                             .Include(x => x.OdjeljenjeStavka.Odjeljenje)
                                             .FirstOrDefault();

                if(best!=null)
                {
                    item.NajboljiUcesnikSkola = best.OdjeljenjeStavka.Odjeljenje.Skola.Naziv;
                    item.NajboljiUcesnikOdjeljenje = best.OdjeljenjeStavka.Odjeljenje.Oznaka;
                    item.NajboljiUcesnikImePrezime = best.OdjeljenjeStavka.Ucenik.ImePrezime;
                }
            }

            return View(choose);
        }
        public IActionResult Add(int id)
        {
            var skola = db.Skola.Find(id); //moram dohvatiti koja je skola
            var Razred = new List<int> { 1, 2, 3, 4 }; // kao sto je bilo sa stringom razreda, ovdje dodajem ciste intove jer je string bio opcionalan
            var add = new TakmicenjeAddVM
            {
                SkolaId = id,
                SkolaNaziv = skola.Naziv,
                predmeti = db.Predmet.GroupBy(i=>i.Naziv)
                            .Select(i=>i.First())
                            .Select(
                    x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                    {
                        Value = x.Naziv,
                        Text = x.Naziv
                    }
                    ).ToList(),
                razredi=Razred.ConvertAll(
                    x=>
                    {
                        return new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                        {
                            Text = x.ToString(),
                            Value = x.ToString(),
                            Selected = false
                        };
                    }
                    ),
                Datum=DateTime.Now
            };

            return View(add);
        }


        public IActionResult Save(TakmicenjeAddVM model)
        {
            var predmet = db.Predmet.Where(x => x.Naziv.Contains(model.PredmetId) && x.Razred==model.RazredID)
                                    .FirstOrDefault();

            var spasi = new Takmicenje
            {
                SkolaId=model.SkolaId,
                PredmetId=predmet.Id,
                Datum=model.Datum,
                Razred=model.RazredID,
                IsPristupio=false //ovo je izZakljucano 
            };
            db.Add(spasi);
            db.SaveChanges();

            //ovdje smo pronalazili sve odlicne u razredu za odredjeni predmet
            var odlicniIzPredmeta = db.DodjeljenPredmet
                                  .Where(x => x.ZakljucnoKrajGodine == 5 && x.Predmet.Id == predmet.Id)
                                  .Select(t => new TakmicenjeUcesnik
                                  {
                                      OdjeljenjeStavkaId=t.OdjeljenjeStavkaId,
                                      UcesnikIsPristupio=false,
                                      Bodovi=0
                                  }).ToList();

            foreach (var item in odlicniIzPredmeta)
            {
                //ovdje smo trazili koji sve to ucesnici imaju prosjecnu ocjenu vecu od 4.
                bool manjeOdCetiri = db.DodjeljenPredmet
                                   .Where(x => x.OdjeljenjeStavkaId == item.OdjeljenjeStavkaId && x.OdjeljenjeStavka.Odjeljenje.Razred == spasi.Razred)
                                   .Select(i => i.ZakljucnoKrajGodine)
                                   .Average() > 4;

                if(manjeOdCetiri)
                {
                    var takmicar = new TakmicenjeUcesnik
                    {
                        TakmicenjeId = spasi.Id,
                        OdjeljenjeStavkaId = item.OdjeljenjeStavkaId,
                        Bodovi = 0,
                        UcesnikIsPristupio = false
                    };

                    db.Add(takmicar);
                    db.SaveChanges();
                }


            }

            return RedirectToAction("Index","Takmicenje");//ne zaboravi Redirect!
        }
    }
}
