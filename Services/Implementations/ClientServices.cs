using Models.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
   public  class ClientServices : IClientService
    {

        IClientRepository _ClientRepository;

        public ClientServices(IClientRepository categorie)
        {
            _ClientRepository = categorie;
        }

        public bool CheckCode_ExistClient(string code)
        {
            var _listeClient = _ClientRepository.GetAll();
            var res = false;
            foreach (Client client in _listeClient)
            {
                if(client.co)
            }
            
            return res;
        }
    

    }
}
