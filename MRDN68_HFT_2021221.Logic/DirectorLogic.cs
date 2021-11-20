using MRDN68_HFT_2021221.Models;
using MRDN68_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRDN68_HFT_2021221.Logic
{
    public class DirectorMovieCount
    {
        public string DirectorName { get; set; }
        public int Count { get; set; }
    }
    public class DirectorLogic : IDirectorLogic
    {
        IDirectorRepository repo;
        public DirectorLogic(IDirectorRepository repo)
        {
            this.repo = repo;
        }

        public IEnumerable<DirectorMovieCount> Query1()
        {  
            //var q0= ReadAll()
            //    .Where(x => x.Name.Contains("a"))
            //    .GroupBy(x => x.Movies.Where(x => x.Year == 2000).Count()).FirstOrDefault();
            //akinek van "a" betű a nevében annak a neve és a 2000 után készült
            //filmjeinek száma csökkenő sorrendben
            return from director in ReadAll()
                       let moviecount = director.Movies.Where(x => x.Year > 2000).Count()
                       select new DirectorMovieCount() { DirectorName = director.Name, Count = moviecount };
          

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
