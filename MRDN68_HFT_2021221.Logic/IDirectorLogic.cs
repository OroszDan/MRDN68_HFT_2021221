using MRDN68_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRDN68_HFT_2021221.Logic
{
    public interface IDirectorLogic
    {
       
        IEnumerable<DirectorMovieCount> Query1();
        void Create(Director director);
        IQueryable<Director> ReadAll();
        void Update(Director director);
        void Delete(int directorId);
    }
}
