using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    public class ArticleGeneriqueMvcController : Controller
    {
        public IActionResult Index()
        {
            var lga = GetLGAAPI();
            return View(lga);

            
        }

        private List<ArticleGenerique> GetLGAAPI()
        {
            try
            {
                var resultList = new List<ArticleGenerique>();
                var client = new HttpClient();
                var getDataTask = client.GetAsync("https://localhost:44395/api/articlegenerique")
                    .ContinueWith(response => {
                        var result = response.Result;
                        if (result.StatusCode ==System.Net.HttpStatusCode.OK)
                        {
                            var readResult = result.Content.ReadAsAsync<List<ArticleGenerique>>();
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