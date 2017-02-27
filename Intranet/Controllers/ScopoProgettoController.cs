﻿using Intranet.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Intranet.Controllers
{
    public class ScopoProgettoController : Controller
    {

        public ActionResult Index()
        {
            int min = DateTime.Now.Minute;

            using (var db = new ApplicationDbContext())
            {
                var _r = db.ScopoProgetto.Where(m => m.RangeOrario >= min).OrderBy(r => r.RangeOrario).First();

                ScopoProgettoViewModels result = new ScopoProgettoViewModels
                {
                    Titolo = _r.Titolo,
                    Descrizione = _r.Descrizione,
                    toRefresh = ((_r.RangeOrario + 1) - min) * 60 * 1000 //rangeOrario +1 fa si che non abbia mai 0 come risultato finale
                };

                return View(result);
            }
        }
    }
}