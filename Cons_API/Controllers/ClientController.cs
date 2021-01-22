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

        public IActionResult Add(int i)
        {

            return View(new Client());
        }
        [HttpPost]
        public IActionResult Add(Client clt)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Client", clt).Result;

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int i)
        {

            return View(new Client());
        }
        [HttpPut]
        public IActionResult Edit(Client clt)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Client", clt).Result;
           
            return RedirectToAction("Index");
        }
    }
}