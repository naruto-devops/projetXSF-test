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
    public class IncotermController : ControllerBase
    {
        IIncotermService _IncotermService;

        public IncotermController(IIncotermService incoterm)
        {
            _IncotermService = incoterm;
        }
        [HttpGet]
        public List<Incoterm> GetAll()
        {
            return _IncotermService.GetAll();

        }
        [HttpGet("{Numero}")]
        public Incoterm GetById(int id)
        {
            return _IncotermService.GetById(id);

        }
        [HttpPost]
        public Incoterm Post([FromBody]Incoterm incoterm)
        {
            if (ModelState.IsValid)
                _IncotermService.Add(incoterm);
            return incoterm;
        }
        [HttpPut]
        public Incoterm Put([FromBody]Incoterm incoterm)
        {


            if (ModelState.IsValid)
                _IncotermService.Update(incoterm);
            return incoterm;
        }
        [HttpDelete("{numero}")]
        public bool Delete(int id)
        {
             bool res = false;

            if (_IncotermService.CheckIncoterm_ExistClient(id) == false)
            {
                _IncotermService.Delete(id);
                res = true;
            }
            return res;
        }
    }
}