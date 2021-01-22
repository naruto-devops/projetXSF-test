using Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Contracts
{
   public interface ICategorieTarifRepository
    {
        List<CategorieTarif> GetAll();
        CategorieTarif GetById(int id);
        CategorieTarif GetByClient(int id);
        CategorieTarif Add(CategorieTarif categorie);
        CategorieTarif Update(CategorieTarif categorie);
        bool Delete(int id);
    }
}
