using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories.Contracts;

namespace XSOFT_WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModalitePaiementController : ControllerBase
    {
        IModalitePaiementRepository _ModalitePaiementRepository;

        public ModalitePaiementController(IModalitePaiementRepository frs)
        {
            _ModalitePaiementRepository = frs;
        }
        [HttpGet]
        public List<ModalitePaiement> GetAll()
        {
            return _ModalitePaiementRepository.GetAll();

        }
        [HttpGet("{Numero}")]
        public ModalitePaiement GetById(int id)
        {
            return _ModalitePaiementRepository.GetById(id);

        }
        [HttpPost]
        public void Post([FromBody]ModalitePaiement dvs)
        {
            if (ModelState.IsValid)
                _ModalitePaiementRepository.Add(dvs);

        }
        [HttpPut]
        public void Put([FromBody]ModalitePaiement dvs)
        {


            if (ModelState.IsValid)
                _ModalitePaiementRepository.Update(dvs);

        }
        [HttpDelete("{numero}")]
        public void Delete(int id)
        {

            _ModalitePaiementRepository.Delete(id);

        }
    }
}