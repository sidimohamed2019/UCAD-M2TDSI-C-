using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeritageProjetGrp6.Controllers
{
    public class CalculController : Controller
    {
        // GET: Calcul
        public ActionResult Calcul()
        {
            return View();
        }
        // GET: CalculFemme
        public ActionResult CalculFemme()
        {
            return View();
        }
        // GET: info
        public ActionResult info()
        {
            return View();
        }


    }
}