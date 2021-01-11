using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Cons_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cons_API.Controllers
{
    public class ClientMVCController : Controller
    {

        public IActionResult Index()
        {
            var Clients = GetListAGfromAPI();

            return View(Clients);
        }

        private List<Client> GetListAGfromAPI()
        {
            try
            {
                var resultList = new List<Client>();
                var client = new HttpClient();
                var getDataTask = client.GetAsync("https://localhost:44395/api/client")
                    .ContinueWith(Response =>
                    {
                        var result = Response.Result;
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var readResult = result.Content.ReadAsAsync<List<Client>>();
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