using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Contracts
{
   public interface IModalitePaiementRepository
    {
        List<ModalitePaiement> GetAll();
        ModalitePaiement GetById(int id);
        void Add(ModalitePaiement mlt);
        void Update(ModalitePaiement mlt);
        void Delete(int id);
    }
}

