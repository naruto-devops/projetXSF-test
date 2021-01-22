using Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementations
{
   public  class ModalitePaiementServices : IModalitePaiementService
    {
        IModalitePaiementRepository _ModalitePaiementRepository;

        public ModalitePaiementServices(IModalitePaiementRepository fat)
        {
            _ModalitePaiementRepository = fat;
        }

        public bool CheckMDT_ExistClient(int id)
        {
            var fat = _ModalitePaiementRepository.GetByClient(id);
            return fat != null;
        }

        public List<ModalitePaiement> GetAll()
        {
            List<ModalitePaiement> result = new List<ModalitePaiement>();
            result = _ModalitePaiementRepository.GetAll();
            return result;
        }

        public ModalitePaiement GetById(int id)
        {
            return _ModalitePaiementRepository.GetById(id);
        }

        public ModalitePaiement Add(ModalitePaiement fat)
        {
            _ModalitePaiementRepository.Add(fat);

            return fat;

        }

        public ModalitePaiement Update(ModalitePaiement fat)
        {
            _ModalitePaiementRepository.Update(fat);
            return fat;
        }

        public bool Delete(int id)
        {
            return _ModalitePaiementRepository.Delete(id);


        }

    }
}
