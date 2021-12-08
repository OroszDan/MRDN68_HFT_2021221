using MRDN68_HFT_2021221.Models;
using System;
using System.Collections.Generic;

namespace MRDN68_HFT_2021221.Client
{
    class Program
    {
        public static string[] main_menu;
        public static string[] side_menu;
        public static string[] query_menu;
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(4000);

            main_menu = new string[] { "Director", "Movie", "Showtime", "Query" };
            side_menu = new string[] { "Get all in system", "Get one", "Create new one", "Update one", "Delete one" };
            query_menu = new string[] { "Count of Movies after 2000 by DirectorNames and Ordered by DirectorNames", "Movie AgeRatings in Cinema City Arena",
                "DirectorNamesOfMoviesShownBefore2004InCinemaCityCinemas","PGCategoryMovieNamesShownAfter12_30",
                "DateTimesOfMoviesShownInBudapestWhoseDirectorsBornBefore1962" };

            RestService restService = new RestService("http://localhost:65512");

            string menu;

            do
            {
                Console.Clear();
                menu = WriteOuts.Menu("Main", main_menu);

                switch (menu)
                {
                    case "1":
                        ConsoleLogic.DirectorThings(WriteOuts.Menu(main_menu[int.Parse(menu)-1], side_menu), restService);
                        Console.ReadLine();
                        continue;
                    case "2":
                        ConsoleLogic.MovieThings(WriteOuts.Menu(main_menu[int.Parse(menu)-1], side_menu), restService);
                        Console.ReadLine();
                        continue;
                    case "3":
                        ConsoleLogic.ShowtimeThings(WriteOuts.Menu(main_menu[int.Parse(menu)-1], side_menu), restService);
                        Console.ReadLine();
                        continue;
                    
                    case "4":
                        ConsoleLogic.QueryThings(WriteOuts.Menu(main_menu[int.Parse(menu)-1], query_menu), restService);
                        Console.ReadLine();
                        continue;
                    case "q":
                        Console.WriteLine("Quiting...");
                        continue;
                    default:
                        Console.WriteLine("Not suitable menu!");
                        continue;
                }

            } while (menu != "q");

            //non-crud methods
            var query1 = restService.Get<KeyValuePair<string, int>>("moviestat/getquery1");
            var query2 = restService.Get<AgeRating>("showtimestat/getquery2");
            var query3 = restService.Get<string>("showtimestat/getquery3");
            var query4 = restService.Get<string>("showtimestat/getquery4");
            var query5 = restService.Get<DateTime>("showtimestat/getquery5");

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

            var showtimes = restService.Get<Showtime>("showtime");
            var movies = restService.Get<Movie>("movie");
            var directors = restService.Get<Director>("director");

            
            ;
        }
    }
}
