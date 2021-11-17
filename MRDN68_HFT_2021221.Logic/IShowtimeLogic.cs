using MRDN68_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRDN68_HFT_2021221.Logic
{
    interface IShowtimeLogic
    {
        void Create(Showtime showtime);
        IQueryable<Showtime> ReadAll();
        void Update(Showtime showtime);
        void Delete(int showtimeId);
    }
}
