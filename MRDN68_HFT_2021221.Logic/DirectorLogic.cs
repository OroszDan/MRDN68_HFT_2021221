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

        public void Query()
        {
            string name = "Quentin Tarantino";
            var q0 = ReadAll()
                .Where(x => x.Name == name).GroupBy(x => x.Movies.Where(x => x.Year ==2000));

            
        }

        public void Create(Director director)
        {
            if (director !=null)
            {
                repo.Create(director);
            }
            else
            {
                throw new ArgumentException("Object cannot be null");
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
