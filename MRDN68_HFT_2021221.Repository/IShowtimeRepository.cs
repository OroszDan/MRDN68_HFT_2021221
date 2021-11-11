using MRDN68_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRDN68_HFT_2021221.Repository
{
    public interface IShowtimeRepository
    {// C(R)RUD
        void Create(Showtime showtime);
        Showtime Read(int id);
        IQueryable<Showtime> ReadAll(); // altalaban: query
        void Update(Showtime showtime);
        void Delete(int id);
    }
}
