using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace XSOFT_WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorieTarifController : ControllerBase
    {
        ICategorieTarifService _CategorieTarifService;

        public CategorieTarifController(ICategorieTarifService categorie)
        {
            _CategorieTarifService = categorie;
        }
        [HttpGet]
        public List<CategorieTarif> GetAll()
        {
            return _CategorieTarifService.GetAll();

        }
        [HttpGet("{code}")]
        public CategorieTarif GetById(int id)
        {
            return _CategorieTarifService.GetById(id);

        }
        [HttpPost]
        public CategorieTarif Post([FromBody]CategorieTarif categorie)
        {
            if (ModelState.IsValid)
                _CategorieTarifService.Add(categorie);
            return categorie;

        }
        [HttpPut]
        public CategorieTarif Put([FromBody]CategorieTarif categorie)
        {


            if (ModelState.IsValid)
                _CategorieTarifService.Update(categorie);
            return categorie;

        }
        [HttpDelete("{code}")]
        public bool Delete(int id)
        {

            bool res = false;

            if (_CategorieTarifService.CheckCategorie_ExistClient(id)==false)
            {
                _CategorieTarifService.Delete(id);
                res = true;

            }

            return res;


        }
    }
}