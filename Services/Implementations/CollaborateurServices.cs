using System;
using System.Collections.Generic;
using Models.Models;
using Reposiotries.Implementations;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CollaborateurServices : ICollaborateurService
    {
        ICollaborateurRepository _CollaborateurRepository;

        public CollaborateurServices(ICollaborateurRepository collaborateur)
        {
            _CollaborateurRepository = collaborateur;
        }

        public bool CheckCol_ExistClient(int id)
        {
            var collaborateur = _CollaborateurRepository.GetByClient(id);
            return collaborateur != null;
        }

        public  List<Collaborateur> GetAll()
        {
            List<Collaborateur> result = new List<Collaborateur>();
            result = _CollaborateurRepository.GetAll();
                return result;       
        }
       public  Collaborateur GetById(int id)
        {
            return _CollaborateurRepository.GetById(id);
        }

        public Collaborateur Add(Collaborateur collaborateur)
        {
            _CollaborateurRepository.Add(collaborateur);

            return collaborateur;
           
        }

        public Collaborateur Update(Collaborateur collaborateur)
        {
            _CollaborateurRepository.Update(collaborateur);
            return collaborateur;
        }

        public bool Delete(int id)
        {
           return  _CollaborateurRepository.Delete(id);
           
        }
    }
}
