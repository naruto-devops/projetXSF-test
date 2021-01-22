using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Cons_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cons_API.Controllers
{
    public class ArticleGeneriqueController : Controller
    {
       
            public IActionResult Index()
            {
                IEnumerable<ArticleGenerique> listearticles;
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("ArticleGenerique").Result;
                listearticles = response.Content.ReadAsAsync<IEnumerable<ArticleGenerique>>().Result;

                return View(listearticles);
            
        }
    }
}