using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Cons_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cons_API.Controllers
{
    public class FournisseurMVCController : Controller
    {

        public IActionResult Index()
        {
            var Fournisseurs = GetListAGfromAPI();

            return View(Fournisseurs);
        }

        private List<Fournisseur> GetListAGfromAPI()
        {
            try
            {
                var resultList = new List<Fournisseur>();
                var client = new HttpClient();
                var getDataTask = client.GetAsync("https://localhost:44395/api/Fournisseur")
                    .ContinueWith(Response =>
                    {
                        var result = Response.Result;
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var readResult = result.Content.ReadAsAsync<List<Fournisseur>>();
                            readResult.Wait();
                            resultList = readResult.Result;
                        }
                    });
                getDataTask.Wait();
                return resultList;

            }
            catch (Exception)
            {

                throw;
            }




        }
    }
}