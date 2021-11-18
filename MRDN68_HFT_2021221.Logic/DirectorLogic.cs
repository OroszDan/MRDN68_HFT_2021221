using MRDN68_HFT_2021221.Models;
using MRDN68_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRDN68_HFT_2021221.Logic
{
    class DirectorLogic : IDirectorLogic
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
                .Where(x => x.Name == name).Select(x => x.Movies);

            
        }

        public void Create(Director director)
        {
            repo.Create(director);
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
