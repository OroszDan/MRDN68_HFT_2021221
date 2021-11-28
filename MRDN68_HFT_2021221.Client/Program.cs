using MRDN68_HFT_2021221.Models;
using System;
using System.Collections.Generic;

namespace MRDN68_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(4000);

            RestService service = new RestService("http://localhost:65512");

            //service.Post<Showtime>(new Showtime()
            //{
            //    CinemaName = "Palace",
            //    City = "Érd",
            //    DateTime = new DateTime(2010, 11, 23, 15, 10, 0),
            //    Room = 1,
            //    MovieId = 1


            //}, "showtime");

            //service.Post<Movie>(new Movie()
            //{
            //    Name = "Venom",
            //    Rating = AgeRating.Restricted,
            //    Year = 2021,
            //    DirectorId = 2

            //}, "movie");

            //service.Post<Director>(new Director()
            //{
            //    Name = "James Gunn",
            //    BirthYear = 1975
            //}, "director");

            //service.Delete(14, "showtime");
           
            //service.Put<Showtime>(new Showtime()
            //{
            //    Id = 1,
            //    CinemaName = "Palace",
            //    City = "Érd",
            //    DateTime = new DateTime(2010, 11, 23, 15, 10, 0),
            //    Room = 1,
            //    MovieId = 1
            //}, "showtime");

            var showtimes = service.Get<Showtime>("showtime");
            var movies = service.Get<Movie>("movie");
            var directors = service.Get<Director>("director");

            var query1 = service.Get<KeyValuePair<string, int>>("moviestat/getquery1");
            var query2 = service.Get<string>("showtimestat/getquery2");
            var query3 = service.Get<string>("showtimestat/getquery3");
            var query4 = service.Get<string>("showtimestat/getquery4");
            var query5 = service.Get<DateTime>("showtimestat/getquery5");
            ;
        }
    }
}
