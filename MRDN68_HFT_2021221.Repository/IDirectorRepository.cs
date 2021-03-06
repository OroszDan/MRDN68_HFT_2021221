using MRDN68_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRDN68_HFT_2021221.Repository
{
    public interface IDirectorRepository
    {
        // C(R)RUD
        void Create(Director director);
        Director Read(int id);
        IQueryable<Director> ReadAll(); // altalaban: query
        void Update(Director director);
        void Delete(int id);
    }
}
