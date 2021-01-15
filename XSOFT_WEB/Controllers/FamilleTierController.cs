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
    public class FamilleTierController : ControllerBase
    {
        IFamilleTierRepository _FamilleTierRepository;

        public FamilleTierController(IFamilleTierRepository frs)
        {
            _FamilleTierRepository = frs;
        }
        [HttpGet]
        public List<FamilleTier> GetAll()
        {
            return _FamilleTierRepository.GetAll();

        }
        [HttpGet("{code}")]
        public FamilleTier GetById(string id)
        {
            return _FamilleTierRepository.GetById(id);

        }
        [HttpPost]
        public void Post([FromBody]FamilleTier frs)
        {
            if (ModelState.IsValid)
                _FamilleTierRepository.Add(frs);

        }
        [HttpPut]
        public void Put([FromBody]FamilleTier ft)
        {
            

            if (ModelState.IsValid)
                _FamilleTierRepository.Update(ft);

        }
        [HttpDelete("{code}")]
        public void Delete(string id)
        {

            _FamilleTierRepository.Delete(id);

        }
    }
}