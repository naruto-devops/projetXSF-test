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
        void Add(Incoterm mlt);
        void Update(Incoterm mlt);
        void Delete(int id);
    }
}
