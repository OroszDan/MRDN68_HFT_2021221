using MRDN68_HFT_2021221.Models;
using MRDN68_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRDN68_HFT_2021221.Logic
{
    class ShowtimeLogic : IShowtimeLogic
    {
        IShowtimeRepository repo;

        public ShowtimeLogic(IShowtimeRepository repo)
        {
            this.repo = repo;
        }

        //
       

        public void Create(Showtime showtime)
        {
            repo.Create(showtime);
        }

        public void Delete(int showtimeId)
        {
            repo.Delete(showtimeId);
        }

        public IQueryable<Showtime> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Showtime showtime)
        {
            repo.Update(showtime);
        }
    }
}
