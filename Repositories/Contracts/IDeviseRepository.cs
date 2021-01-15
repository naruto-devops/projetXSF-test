using Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Contracts
{
  public   interface IDeviseRepository
    {
        List<Devise> GetAll();
        Devise GetById(string id);
        void Add(Devise flt);
        void Update(Devise flt);
        void Delete(string id);
    }
}
