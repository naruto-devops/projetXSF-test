using Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
   public interface IIncotermService
    {
        List<Incoterm> GetAll();
        Incoterm GetById(int id);
        Incoterm Add(Incoterm incoterm);
        Incoterm Update(Incoterm incoterm);

        bool CheckIncoterm_ExistClient(int id);
        bool Delete(int id);
    }
}
