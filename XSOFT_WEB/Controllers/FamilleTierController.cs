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
    public class FamilleTierController : ControllerBase
    {
        IFamilleTierService _FamilleTierService;

        public FamilleTierController(IFamilleTierService fts)
        {
            _FamilleTierService = fts;
        }
        [HttpGet]
        public List<FamilleTier> GetAll()
        {
            return _FamilleTierService.GetAll();

        }
        [HttpGet("{code}")]
        public FamilleTier GetById(int id)
        {
            return _FamilleTierService.GetById(id);

        }
        [HttpPost]
        public FamilleTier Post([FromBody]FamilleTier ft)
        {
            if (ModelState.IsValid)
                _FamilleTierService.Add(ft);
            return ft;

        }
        [HttpPut]
        public FamilleTier Put([FromBody]FamilleTier ft)
        {
            

            if (ModelState.IsValid)
                _FamilleTierService.Update(ft);
            return ft;

        }
        [HttpDelete("{code}")]
        public bool Delete(int id)
        {
            bool res = false;

            if (_FamilleTierService.CheckFAT_ExistClient(id)==false)
            {
                _FamilleTierService.Delete(id);
                res = true;

            }

            return res;

        }
    }
}