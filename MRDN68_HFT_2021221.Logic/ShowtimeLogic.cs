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
        public IEnumerable<AgeRating> Query2()
        {// ciname city arenaban vetített filmek besorolásai
            string str = "Cinema City Arena";
            /*var q0 = */
           var q0 = ReadAll()
                    .Where(x => x.CinemaName == str /*&& x.DateTime.Hour > 17*/).Select(x => x.Movie.Rating).AsEnumerable();
            return q0;       
        }
        public IEnumerable<string> Query3()
        {// Cinema City - ben vetített 2004 előtt készült mozik rendezői
            return  ReadAll()
                      .Where(x => x.CinemaName.Contains("Cinema City"))
                      .Select(x => x.Movie)
                      .Where(x => x.Year < 2004)
                      .Select(x => x.Director.Name).Distinct();
                      
           
        }
        //public void Query3()
        //{// az 1-es teremben vetített előadások besorolás alapján csoportosítva
        //    var q2 = ReadAll()
        //        .Where(x => x.Room == 1).GroupBy(x => x.Movie.Rating);
                
                      
        //}
        public IEnumerable<string> Query4()
        {// 12:30 után vetített PG kategóriás filmek nevei
            var q0 = ReadAll()
                .Where(x => (x.DateTime.Hour > 12 || (x.DateTime.Hour == 12 && x.DateTime.Minute > 30)) )
                .Select(x => x.Movie)
                .Where(x => x.Rating == AgeRating.ParentalGuidanceSuggested)
                .Select(x => x.Name);
            
            return q0;          
        }
        public IEnumerable<DateTime> Query5()
        {// budapesten vetített, az egyik legrégebbi, 1960 után született rendező által rendezett film vetítéseinek ideje
            string city = "Budapest";

            var result = ReadAll()
                .Where(x => x.City == city)
                .Select(x => x.Movie)
                .Where(x => x.Director.BirthYear < 1962)
                .GroupBy(x => x.Year)
                .OrderBy(x => x.Key.Value)
                .FirstOrDefault()
                .Select(x => x.Showtimes).FirstOrDefault()
                .Select(x => x.DateTime);

            // .OrderBy(x => x.Year).FirstOrDefault();

            // .Select(x => x.Showtimes.Where(x => x.City == city))
            //.Select(x => x.Select(x => x.DateTime));


            //var q4 = ReadAll()
            //    .Select(x => x.Movie)
            //    .Where(x => x.Director.BirthYear < 1960)
            //    .Max(x => x.Year);

            //var q0_res = ReadAll()
            //    .Where(x => x.City == city)
            //    .Select(x => x.Movie)  
            //    .FirstOrDefault(x => x.Year == q4)
            //    .Showtimes.Select(x => x.DateTime);
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

        public void Update(Showtime showtime)
        {
          
            repo.Update(showtime);          

        }
    }
}
