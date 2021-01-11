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
    public class FournisseurController : ControllerBase
    {
        IFournisseurRepository _FournisseurRepository;

        public FournisseurController(IFournisseurRepository frs)
        {
            _FournisseurRepository = frs;
        }
        [HttpGet]
        public List<Fournisseur> GetAll()
        {
            return _FournisseurRepository.GetAll();

        }
    }
}