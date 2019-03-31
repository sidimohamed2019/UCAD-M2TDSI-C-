using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeritageProjetGrp6.Controllers
{
    public class BibliothequeController : Controller
    {
        // GET: Bibliotheque
        public ActionResult Bibliotheque()
        {
            return View();
        }
    }
        
}