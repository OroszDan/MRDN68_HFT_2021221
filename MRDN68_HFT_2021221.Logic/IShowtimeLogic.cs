using MRDN68_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRDN68_HFT_2021221.Logic
{
    public interface IShowtimeLogic
    {
        IEnumerable<DateTime> DateTimesOfMoviesShownInBudapestWhoseDirectorsBornBefore1962();
        IEnumerable<AgeRating> MovieAgeRatingsInCinemaCityArena();
        IEnumerable<string> PGCategoryMovieNamesShownAfter12_30();
        IEnumerable<string> DirectorNamesOfMoviesShownBefore2004InCinemaCityCinemas();
        void Create(Showtime showtime);
        Showtime Read(int id);
        IQueryable<Showtime> ReadAll();
        void Update(Showtime showtime);
        void Delete(int showtimeId);
    }
}
