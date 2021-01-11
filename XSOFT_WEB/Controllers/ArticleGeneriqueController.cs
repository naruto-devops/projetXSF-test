using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Repositories.Contracts;

namespace XSOFT_WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleGeneriqueController : ControllerBase
    {
        IArticleGeneriqueRepository _articlegeneriqueRepository;

        public ArticleGeneriqueController(IArticleGeneriqueRepository agr)
        {
            _articlegeneriqueRepository = agr;
        }
        [HttpGet]
        public List<ArticleGenerique> GetAll()
        {
            return _articlegeneriqueRepository.GetAll();

        }
        [HttpGet("{Id}")]
        public ArticleGenerique GetById(int id)
        {
            return _articlegeneriqueRepository.GetById(id);

        }
        //[HttpGet()]
        //public JsonResult GetAll()
        //{
        //    var res = _articlegeneriqueRepository.GetAll();
        //    return Json(res);
        //}




    }
}