using Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Contracts
{
 public    interface IIncotermRepository
    {
        List<Incoterm> GetAll();
        Incoterm GetById(int id);
        Incoterm GetByClient(int id);
        Incoterm Add(Incoterm mlt);
        Incoterm Update(Incoterm mlt);
        bool Delete(int id);
    }
}
