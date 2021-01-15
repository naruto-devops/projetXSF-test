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
    public class CollaborateurController : ControllerBase
    {
        ICollaborateurRepository _CollaborateurRepository;

        public CollaborateurController(ICollaborateurRepository frs)
        {
            _CollaborateurRepository = frs;
        }
        [HttpGet]
        public List<Collaborateur> GetAll()
        {
            return _CollaborateurRepository.GetAll();

        }
        [HttpGet("{Numero}")]
        public Collaborateur GetById(int id)
        {
            return _CollaborateurRepository.GetById(id);

        }
        [HttpPost]
        public void Post([FromBody]Collaborateur dvs)
        {
            if (ModelState.IsValid)
                _CollaborateurRepository.Add(dvs);

        }
        [HttpPut]
        public void Put([FromBody]Collaborateur dvs)
        {


            if (ModelState.IsValid)
                _CollaborateurRepository.Update(dvs);

        }
        [HttpDelete("{numero}")]
        public void Delete(int id)
        {

            _CollaborateurRepository.Delete(id);

        }
    }
}