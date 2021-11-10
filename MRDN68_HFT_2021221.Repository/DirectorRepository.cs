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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Director> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Director ReadOne(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Director director)
        {
            throw new NotImplementedException();
        }
    }
}
