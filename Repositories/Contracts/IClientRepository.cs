using Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Contracts
{
   public  interface IClientRepository
    {
         List<Client> GetAll();
        Client GetById(int id);
    }
}
