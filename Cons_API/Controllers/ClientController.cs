using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Cons_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cons_API.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<Client> listeclients;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Client").Result;
            listeclients = response.Content.ReadAsAsync<IEnumerable<Client>>().Result;

            return View(listeclients);
        }
    }
}