using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Cons_API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Cons_API.Controllers
{
    public class ArticleGeneriqueMVCController : Controller
    {

        public IActionResult Index()
        {
            var articles = GetListAGfromAPI();

            return View(articles);
        }

        private List<ArticleGenerique> GetListAGfromAPI()
        {
            try
            {
                var resultList = new List<ArticleGenerique>();
                var client = new HttpClient();
                var getDataTask = client.GetAsync("https://localhost:44395/api/articlegenerique")
                    .ContinueWith(Response =>
                    {
                        var result = Response.Result;
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
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
