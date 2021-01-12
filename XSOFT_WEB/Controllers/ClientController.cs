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
    public class ClientController : ControllerBase
    {
        IClientRepository _clientRepository;

        public ClientController(IClientRepository clt)
        {
            _clientRepository = clt;
        }
        [HttpGet]
        public List<Client> GetAll()
        {
            return _clientRepository.GetAll();

        }
        [HttpGet("{cbmarq}")]
        public Client GetById(int id)
        {
            return _clientRepository.GetById(id);

        }
        [HttpPost]
        public void Post([FromBody]Client clt)
        {
            if (ModelState.IsValid)
                _clientRepository.Add(clt);

        }
        [HttpPut("{id}")]
       // public void Put(string id, [FromBody]Client clt)
        public void Put(string id, [FromBody]Client clt)
        {
            clt.CT_Num = id;

            if (ModelState.IsValid)
                _clientRepository.Update(id);

        }
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
           
                _clientRepository.Delete(id);

        }

    }
}