using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
   public  interface IModalitePaiementService
    {
        List<ModalitePaiement> GetAll();
        ModalitePaiement GetById(int id);
        ModalitePaiement Add(ModalitePaiement cbl);
        ModalitePaiement Update(ModalitePaiement cbl);

        bool CheckMDT_ExistClient(int id);
        bool Delete(int id);
    }
}
