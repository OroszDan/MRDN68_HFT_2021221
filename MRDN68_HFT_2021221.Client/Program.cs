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

            //non-crud methods
            var query1 = service.Get<KeyValuePair<string, int>>("moviestat/getquery1");
            var query2 = service.Get<AgeRating>("showtimestat/getquery2");
            var query3 = service.Get<string>("showtimestat/getquery3");
            var query4 = service.Get<string>("showtimestat/getquery4");
            var query5 = service.Get<DateTime>("showtimestat/getquery5");

            //crud methods
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
            //    BirthYear = 1975,
            //     Movies = null

            //}, "director");


            //service.Delete(7, "showtime");
            //service.Delete(8, "showtime");
            //service.Delete(9, "showtime");
            //service.Delete(10, "showtime");
            //service.Delete(11, "showtime");
            //service.Delete(16, "movie");
            //service.Delete(16, "director");

            //service.Put<Showtime>(new Showtime()
            //{
            //    Id = 1,
            //    CinemaName = "Palace",
            //    City = "Érd",
            //    DateTime = new DateTime(2010, 11, 23, 15, 10, 0),
            //    Room = 1,
            //    MovieId = 1

            //}, "showtime");

            //service.Put<Movie>(new Movie()
            //{
            //    Id = 2,
            //    Name = "Álom.net",
            //    Year = 2009,
            //    Rating = AgeRating.AdultsOnly,
            //    DirectorId = 1


            //}, "movie");

                //service.Put<Director>(new Director()
                //{
                //    Id = 1,
                //    Name = "Janika",
                //    BirthYear = 2010,
                //   


                //}, "director");

            var showtimes = service.Get<Showtime>("showtime");
            var movies = service.Get<Movie>("movie");
            var directors = service.Get<Director>("director");

            
            ;
        }
    }
}
