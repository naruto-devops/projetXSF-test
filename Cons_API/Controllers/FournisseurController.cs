using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Cons_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cons_API.Controllers
{
    public class FournisseurController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<Fournisseur> listeFournisseurs;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Fournisseur").Result;
            listeFournisseurs = response.Content.ReadAsAsync<IEnumerable<Fournisseur>>().Result;

            return View(listeFournisseurs);
        }

    }
}