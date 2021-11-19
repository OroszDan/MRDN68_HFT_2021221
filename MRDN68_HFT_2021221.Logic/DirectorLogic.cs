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

        public IQueryable<IGrouping<int,Director>> Query1()
        {  
            return ReadAll()
                .Where(x => x.Name.Contains("a"))
                .GroupBy(x => x.Movies.Where(x => x.Year == 2000).Count());
            //akinek van "a" betű a nevében annak a neve és a 2000 után készült
            //filmjeinek száma csökkenő sorrendben

            
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
