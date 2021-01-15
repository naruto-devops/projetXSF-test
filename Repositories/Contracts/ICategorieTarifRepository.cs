using Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Contracts
{
   public interface ICategorieTarifRepository
    {
        List<CategorieTarif> GetAll();
        CategorieTarif GetById(string id);
        void Add(CategorieTarif flt);
        void Update(CategorieTarif flt);
        void Delete(string id);
    }
}
