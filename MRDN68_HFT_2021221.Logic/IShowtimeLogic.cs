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
        IQueryable<string> Query1();
        IQueryable<string> Query2();
        IQueryable<string> Query3();
        IQueryable<string> Query4();
        IQueryable<string> Query5();

        void Create(Showtime showtime);
        IQueryable<Showtime> ReadAll();
        void Update(Showtime showtime);
        void Delete(int showtimeId);
    }
}
