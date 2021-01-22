using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories.Contracts;
using Services.Contracts;

namespace XSOFT_WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModalitePaiementController : ControllerBase
    {
        IModalitePaiementService _ModalitePaiementService;

        public ModalitePaiementController(IModalitePaiementService mdt)
        {
            _ModalitePaiementService = mdt;
        }
        [HttpGet]
        public List<ModalitePaiement> GetAll()
        {
            return _ModalitePaiementService.GetAll();

        }
        [HttpGet("{Numero}")]
        public ModalitePaiement GetById(int id)
        {
            return _ModalitePaiementService.GetById(id);

        }
        [HttpPost]
        public ModalitePaiement Post([FromBody]ModalitePaiement mdt)
        {
            if (ModelState.IsValid)
                _ModalitePaiementService.Add(mdt);
            return mdt;

        }
        [HttpPut("{Numero}")]
        public ModalitePaiement Put([FromBody]ModalitePaiement mdt)
        {


            if (ModelState.IsValid)
                _ModalitePaiementService.Update(mdt);
            return mdt;

        }
        [HttpDelete("{numero}")]
        public bool Delete(int id)
        {
          
            bool res = false;

            if (_ModalitePaiementService.CheckMDT_ExistClient(id)==false)
            {
                _ModalitePaiementService.Delete(id);
                res = true;

            }

            return res;

        }
    }
}