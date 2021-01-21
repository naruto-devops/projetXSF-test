using Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface ICollaborateurService
    {
        List<Collaborateur> GetAll();
        Collaborateur GetById(int id);
        Collaborateur Add(Collaborateur cbl);
        Collaborateur Update(Collaborateur cbl);
        
        bool CheckCol_ExistClient(int id);
        bool Delete(int id);
    }
}
