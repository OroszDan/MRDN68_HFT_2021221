using MRDN68_HFT_2021221.Models;
using MRDN68_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRDN68_HFT_2021221.Logic
{
    public class DirectorLogic : IDirectorLogic
    {
        IDirectorRepository repo;
        public DirectorLogic(IDirectorRepository repo)
        {
            this.repo = repo;
        }

        public void Create(Director director)
        {
           
            if (director != null && !String.IsNullOrEmpty(director.Name) 
                && director.BirthYear != default)
            {
                repo.Create(director);
            }
            else
            {
                throw new ArgumentException("Object is insufficient");
            }
            
        }

        public void Delete(int directorId)
        {
            repo.Delete(directorId);
        }

        public IQueryable<Director> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Director director)
        {
            repo.Update(director);
        }
    }
}
