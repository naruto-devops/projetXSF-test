using Models.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementations
{
    public class DeviseServices : IDeviseService
    {
       
            IDeviseRepository _DeviseRepository;

            public DeviseServices(IDeviseRepository dvs)
            {
                _DeviseRepository = dvs;
            }

            public bool CheckDev_ExistClient(int id)
            {
                var dvs = _DeviseRepository.GetByClient(id);
                return dvs != null;
            }

            public List<Devise> GetAll()
            {
                List<Devise> result = new List<Devise>();
                result = _DeviseRepository.GetAll();
                return result;
            }

            public Devise GetById(int id)
            {
                return _DeviseRepository.GetById(id);
            }

            public Devise Add(Devise dvs)
            {
                _DeviseRepository.Add(dvs);

                return dvs;

            }

            public Devise Update(Devise dvs)
            {
                _DeviseRepository.Update(dvs);
                return dvs;
            }

            public bool Delete(int id)
            {
                return _DeviseRepository.Delete(id);

            }
    }
}
