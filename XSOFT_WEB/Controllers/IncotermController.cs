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
    public class IncotermController : ControllerBase
    {
        IIncotermRepository _IncotermRepository;

        public IncotermController(IIncotermRepository mlt)
        {
            _IncotermRepository = mlt;
        }
        [HttpGet]
        public List<Incoterm> GetAll()
        {
            return _IncotermRepository.GetAll();

        }
        [HttpGet("{Numero}")]
        public Incoterm GetById(int id)
        {
            return _IncotermRepository.GetById(id);

        }
        [HttpPost]
        public void Post([FromBody]Incoterm mlt)
        {
            if (ModelState.IsValid)
                _IncotermRepository.Add(mlt);

        }
        [HttpPut]
        public void Put([FromBody]Incoterm mlt)
        {


            if (ModelState.IsValid)
                _IncotermRepository.Update(mlt);

        }
        [HttpDelete("{numero}")]
        public void Delete(int id)
        {

            _IncotermRepository.Delete(id);

        }
    }
}