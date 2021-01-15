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
    public class CategorieTarifController : ControllerBase
    {
        ICategorieTarifRepository _CategorieTarifRepository;

        public CategorieTarifController(ICategorieTarifRepository cat)
        {
            _CategorieTarifRepository = cat;
        }
        [HttpGet]
        public List<CategorieTarif> GetAll()
        {
            return _CategorieTarifRepository.GetAll();

        }
        [HttpGet("{code}")]
        public CategorieTarif GetById(string id)
        {
            return _CategorieTarifRepository.GetById(id);

        }
        [HttpPost]
        public void Post([FromBody]CategorieTarif frs)
        {
            if (ModelState.IsValid)
                _CategorieTarifRepository.Add(frs);

        }
        [HttpPut]
        public void Put([FromBody]CategorieTarif ft)
        {


            if (ModelState.IsValid)
                _CategorieTarifRepository.Update(ft);

        }
        [HttpDelete("{code}")]
        public void Delete(string id)
        {

            _CategorieTarifRepository.Delete(id);

        }
    }
}