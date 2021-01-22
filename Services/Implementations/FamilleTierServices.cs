using Models.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementations
{
   public class FamilleTierServices : IFamilleTierService
    {
        IFamilleTierRepository _FamilleTierRepository;

        public FamilleTierServices(IFamilleTierRepository fat)
        {
            _FamilleTierRepository = fat;
        }

        public bool CheckFAT_ExistClient(int id)
        {
            var fat = _FamilleTierRepository.GetByClient(id);
            return fat != null;
        }

        public List<FamilleTier> GetAll()
        {
            List<FamilleTier> result = new List<FamilleTier>();
            result = _FamilleTierRepository.GetAll();
            return result;
        }

        public FamilleTier GetById(int id)
        {
            return _FamilleTierRepository.GetById(id);
        }

        public FamilleTier Add(FamilleTier fat)
        {
            _FamilleTierRepository.Add(fat);

            return fat;

        }

        public FamilleTier Update(FamilleTier fat)
        {
            _FamilleTierRepository.Update(fat);
            return fat;
        }

        public bool Delete(int id)
        {
            return _FamilleTierRepository.Delete(id);

        }
    }
}
