using Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
   public  interface IFamilleTierService
    {
        List<FamilleTier> GetAll();
        FamilleTier GetById(int id);
        FamilleTier Add(FamilleTier cbl);
        FamilleTier Update(FamilleTier cbl);

        bool CheckFAT_ExistClient(int id);
        bool Delete(int id);
    }
}
