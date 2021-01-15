using Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Contracts
{
   public  interface IFamilleTierRepository
    {
        List<FamilleTier> GetAll();
        FamilleTier GetById(string id);
        void Add(FamilleTier flt);
        void Update( FamilleTier flt);
        void Delete(string id);
    }
}
