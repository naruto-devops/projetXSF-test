using Models.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementations
{
    public class CategorieTarifServices : ICategorieTarifService
    {

        ICategorieTarifRepository _CategorieTarifRepository;

        public CategorieTarifServices(ICategorieTarifRepository categorie)
        {
            _CategorieTarifRepository = categorie;
        }

        public bool CheckCategorie_ExistClient(int id)
        {
            var fat = _CategorieTarifRepository.GetByClient(id);
            return fat != null;
        }

        public List<CategorieTarif> GetAll()
        {
            List<CategorieTarif> result = new List<CategorieTarif>();
            result = _CategorieTarifRepository.GetAll();
            return result;
        }

        public CategorieTarif GetById(int id)
        {
            return _CategorieTarifRepository.GetById(id);
        }

        public CategorieTarif Add(CategorieTarif categorie)
        {
            _CategorieTarifRepository.Add(categorie);

            return categorie;

        }

        public CategorieTarif Update(CategorieTarif categorie)
        {
            _CategorieTarifRepository.Update(categorie);
            return categorie;
        }

        public bool Delete(int id)
        {
            return _CategorieTarifRepository.Delete(id);


        }
    }
}
