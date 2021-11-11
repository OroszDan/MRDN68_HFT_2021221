using MRDN68_HFT_2021221.Data;
using MRDN68_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRDN68_HFT_2021221.Repository
{
    public class DirectorRepository : IDirectorRepository
    {
        MovieProgrammeDbContext context;

        public DirectorRepository(MovieProgrammeDbContext context)
        {
            this.context = context;
        }

        public void Create(Director director)
        {
            context.Add(director);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Director director = context.Directors.FirstOrDefault(x => x.Id == id);
            context.Remove(director);
            context.SaveChanges();
        }

        public IQueryable<Director> ReadAll()
        {
            return context.Directors;
        }

        public Director ReadOne(int id)
        {
            return context
                .Directors
                .FirstOrDefault(x => x.Id == id);
            
        }

        public void Update(Director director)
        {
            Director director_old = ReadOne(director.Id);

            if (director_old != null)
            {
                director_old.Gender = director.Gender;
                director_old.Name = director.Name;
                
            }
        }
    }
}
