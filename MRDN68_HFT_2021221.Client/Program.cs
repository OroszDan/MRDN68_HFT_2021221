using MRDN68_HFT_2021221.Models;
using System;
using System.Collections.Generic;

namespace MRDN68_HFT_2021221.Client
{
    class Program
    {
        public static string[] main_menu;
        public static string[] crud_menu;
        public static string[] query_menu;
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(4000);

            main_menu = new string[] { "Director", "Movie", "Showtime", "Query" };
            crud_menu = new string[] { "Get all in system", "Get one", "Create new one", "Update one", "Delete one" };
            query_menu = new string[] { "Count of Movies after 2000 by DirectorNames and Ordered by DirectorNames", "Movie AgeRatings in Cinema City Arena",
                "Director Names ofMovies Shown Before 2004 in Cinema City Cinemas","PG Category Movie Names Shown After 12:30",
                "DateTimes of Movies Shown in Budapest Whose Directors are Born Before 1962" };

            RestService restService = new RestService("http://localhost:65512");

            string menu;

            do
            {
                Console.Clear();
                menu = WriteOuts.Menu("Main", main_menu);

                switch (menu)
                {
                    case "1":
                        ConsoleLogic.DirectorThings(WriteOuts.Menu(main_menu[int.Parse(menu)-1], crud_menu), restService);
                        Console.ReadLine();
                        continue;
                    case "2":
                        ConsoleLogic.MovieThings(WriteOuts.Menu(main_menu[int.Parse(menu)-1], crud_menu), restService);
                        Console.ReadLine();
                        continue;
                    case "3":
                        ConsoleLogic.ShowtimeThings(WriteOuts.Menu(main_menu[int.Parse(menu)-1], crud_menu), restService);
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

        }
    }
}
