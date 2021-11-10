using MRDN68_HFT_2021221.Data;
using MRDN68_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRDN68_HFT_2021221.Repository
{
    public class ShowtimeRepository : IShowtimeRepository
    {
        MovieProgrammeDbContext context;

        public ShowtimeRepository(MovieProgrammeDbContext context)
        {
            this.context = context;
        }

        public void Create(Showtime showtime)
        {
            context.Add(showtime);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Showtime showtime = context.Showtimes.FirstOrDefault(x => x.Id == id);
            context.Remove(showtime);
            context.SaveChanges();
            
        }

        public IQueryable<Showtime> ReadAll()
        {
            return context.Showtimes;
        }

        public Showtime ReadOne(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Showtime showtime)
        {
            throw new NotImplementedException();
        }
    }
}
