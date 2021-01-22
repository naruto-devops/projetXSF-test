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
    public class CollaborateurController : ControllerBase
    {
        ICollaborateurService _collaborateurService;

        public CollaborateurController(ICollaborateurService collaborateurService)
        {
            _collaborateurService = collaborateurService;
        }
        [HttpGet]
        public List<Collaborateur> GetAll()
        {
            return _collaborateurService.GetAll();

        }
        [HttpGet("{Numero}")]
        public Collaborateur GetById(int id)
        {
            return _collaborateurService.GetById(id);

        }
        [HttpPost]
        public Collaborateur Post([FromBody]Collaborateur collaborateur)
        {
            if (ModelState.IsValid)
                _collaborateurService.Add(collaborateur);
            return collaborateur;

        }
        [HttpPut]
        public Collaborateur Put([FromBody]Collaborateur collaborateur)
        {

            
            if (ModelState.IsValid)
                _collaborateurService.Update(collaborateur);
            return collaborateur;

        }
        [HttpDelete("{numero}")]
        public bool Delete(int id)
        {
            bool res = false;

            if (_collaborateurService.CheckCol_ExistClient(id)==false)
            { _collaborateurService.Delete(id);
                res = true;
            }
           
            return res;

        }
    }
}