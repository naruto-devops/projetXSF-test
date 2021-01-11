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
        [HttpGet("{Id}")]
        public Client GetById(int id)
        {
            return _clientRepository.GetById(id);

        }
        //[HttpPost]
        //public List<Client> Post()
        //{
        //    return _clientRepository.GetAll();

        //}
    }
}