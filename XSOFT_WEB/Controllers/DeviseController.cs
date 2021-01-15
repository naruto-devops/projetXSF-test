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
    public class DeviseController : ControllerBase
    {
        IDeviseRepository _DeviseRepository;

        public DeviseController(IDeviseRepository frs)
        {
            _DeviseRepository = frs;
        }
        [HttpGet]
        public List<Devise> GetAll()
        {
            return _DeviseRepository.GetAll();

        }
        [HttpGet("{code}")]
        public Devise GetById(string id)
        {
            return _DeviseRepository.GetById(id);

        }
        [HttpPost]
        public void Post([FromBody]Devise dvs)
        {
            if (ModelState.IsValid)
                _DeviseRepository.Add(dvs);

        }
        [HttpPut]
        public void Put([FromBody]Devise dvs)
        {


            if (ModelState.IsValid)
                _DeviseRepository.Update(dvs);

        }
        [HttpDelete("{code}")]
        public void Delete(string id)
        {

            _DeviseRepository.Delete(id);

        }
    }
}