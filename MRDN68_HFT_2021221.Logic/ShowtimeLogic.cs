using MRDN68_HFT_2021221.Models;
using MRDN68_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRDN68_HFT_2021221.Logic
{
    public class ShowtimeLogic : IShowtimeLogic
    {
        IShowtimeRepository repo;

        public ShowtimeLogic(IShowtimeRepository repo)
        {
            this.repo = repo;
        }

        //
        public IEnumerable<AgeRating> MovieAgeRatingsInCinemaCityArena()
        {// ciname city arenaban vetített filmek besorolásai
            string str = "Cinema City Arena";
            
            var q0 = ReadAll()
                     .Where(x => x.CinemaName == str)
                     .Select(x => x.Movie.Rating);
                    
            return q0;       
        }
        public IEnumerable<string> DirectorNamesOfMoviesShownBefore2004InCinemaCityCinemas()
        {// Cinema City - ben vetített 2004 előtt készült mozik rendezői
            return  ReadAll()
                      .Where(x => x.CinemaName.Contains("Cinema City"))
                      .Select(x => x.Movie)
                      .Where(x => x.Year < 2004)
                      .Select(x => x.Director.Name).Distinct();
                
        }
       
                      
        //}
        public IEnumerable<string> PGCategoryMovieNamesShownAfter12_30()
        {// 12:30 után vetített PG kategóriás filmek nevei
            var q0 = ReadAll()
                .Where(x => (x.DateTime.Hour > 12 || (x.DateTime.Hour == 12 && x.DateTime.Minute > 30)) )
                .Select(x => x.Movie)
                .Where(x => x.Rating == AgeRating.ParentalGuidanceSuggested)
                .Select(x => x.Name);
            
            return q0;          
        }
        public IEnumerable<DateTime> DateTimesOfMoviesShownInBudapestWhoseDirectorsBornBefore1962()
        {// budapesten vetített, 1962 után született rendező által rendezett filmek vetítéseinek ideje
            string city = "Budapest";

            var result = ReadAll()
                .Where(x => x.City == city)
                .Where(x => x.Movie.Director.BirthYear < 1962)
                .Select(x => x.DateTime);

            return result; 
                 
        }

        public void Create(Showtime showtime)
        {
           
            if (showtime !=null 
                && !String.IsNullOrEmpty(showtime.CinemaName)
                && showtime.DateTime != default
                && showtime.Room != default)
            {
                repo.Create(showtime);
            }
            else
            {
                throw new ArgumentException("Object is insufficient");
            }
           
        }

        public void Delete(int showtimeId)
        {
            repo.Delete(showtimeId);
        }

        public IQueryable<Showtime> ReadAll()
        {
            return repo.ReadAll();
        }

        public Showtime Read(int id)
        {
            return repo.Read(id);
        }

        public void Update(Showtime showtime)
        {
          
            repo.Update(showtime);          

        }

       
    }
}
