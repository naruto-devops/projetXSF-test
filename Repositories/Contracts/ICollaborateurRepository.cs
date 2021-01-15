using Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Contracts
{
    public interface ICollaborateurRepository
    {
        List<Collaborateur> GetAll();
        Collaborateur GetById(int id);
        void Add(Collaborateur cbl);
        void Update(Collaborateur cbl);
        void Delete(int id);
    }
}
