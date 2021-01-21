using Models.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementations
{
   public  class IncotermServices : IIncotermService
    {
        IIncotermRepository _IncotermRepository;

        public IncotermServices(IIncotermRepository fat)
        {
            _IncotermRepository = fat;
        }

        public bool CheckIncoterm_ExistClient(int id)
        {
            var fat = _IncotermRepository.GetByClient(id);
            return fat != null;
        }

        public List<Incoterm> GetAll()
        {
            List<Incoterm> result = new List<Incoterm>();
            result = _IncotermRepository.GetAll();
            return result;
        }

        public Incoterm GetById(int id)
        {
            return _IncotermRepository.GetById(id);
        }

        public Incoterm Add(Incoterm incoterm)
        {
            _IncotermRepository.Add(incoterm);

            return incoterm;

        }

        public Incoterm Update(Incoterm incoterm)
        {
            _IncotermRepository.Update(incoterm);
            return incoterm;
        }

        public bool Delete(int id)
        {
            return _IncotermRepository.Delete(id);

        }
    }
}
