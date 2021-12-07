using MRDN68_HFT_2021221.Models;
using System;

namespace MRDN68_HFT_2021221.Client
{
    class ConsoleLogic
    {
		#region Make
		public static Director MakeDirector(bool update = false, Director old = null)
		{
			Director director;

			if (update) director = old;
			else director = new Director();

			Console.Write("Name: ");
			string name = Console.ReadLine();
			director.Name = update ? (name != "" ? name : old.Name) : name;

			Console.Write("\n BirthYear: ");
			string birthyear = Console.ReadLine();
			director.BirthYear = update ? (birthyear != "" ? int.Parse(birthyear) : old.BirthYear) :int.Parse( birthyear);

			Console.WriteLine("Director making is done. Going back to system.");

			return director;
		}
		public static Product MakeProduct(bool update = false, Product old = null)
		{
			Product prod;
			if (update) prod = old;
			else prod = new Product();

			Console.Write("Name: ");
			string name = Console.ReadLine();
			prod.Name = update ? (name != "" ? name : old.Name) : name;

			Console.Write("\n Prize: ");
			string prize = Console.ReadLine();
			prod.Prize = update ? (prize != "" ? int.Parse(prize) : old.Prize) : int.Parse(prize);

			Console.Write("\n Expiration date: ");
			string exdate = Console.ReadLine();
			string[] date = exdate.Split('.');
			prod.ExpirationDate = update ? (exdate != "" ? new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2])) : old.ExpirationDate) : exdate == "" ? null : new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]));

			Console.Write("\n In stock: ");
			string stock = Console.ReadLine();
			prod.InStock = update ? (stock != "" ? int.Parse(stock) : old.InStock) : int.Parse(stock);

			Console.Write("\n Is available anymore (y/n): ");
			string availableam = Console.ReadLine();
			if (!update || update && availableam != "")
			{
				if (availableam == "y") prod.IsAvailableAnymore = true;
				else if (availableam == "n") prod.IsAvailableAnymore = false;
			}

			Console.Write("\n Expiration date: ");
			string nextrefil = Console.ReadLine();
			string[] refdate = nextrefil.Split('.');
			prod.NextRefill = update ? (nextrefil != "" ? new DateTime(int.Parse(refdate[0]), int.Parse(refdate[1]), int.Parse(date[2])) : old.NextRefill) : exdate == "" ? null : new DateTime(int.Parse(refdate[0]), int.Parse(refdate[1]), int.Parse(refdate[2]));

			return prod;
		}
		public static Movie MakeMovie(bool update = false, Movie old = null)
		{
			Movie movie;

			if (update) movie = old;
			else movie = new Movie();

			Console.Write("Director ID: ");
			string dirid = Console.ReadLine();
			movie.DirectorId = update ? (dirid != "" ? int.Parse(dirid) : old.DirectorId) : int.Parse(dirid);

			Console.Write("\n Rating (0 = GeneralAudiences, 1 = ParentalGuidanceSuggested, 2 = ParentsStronglyCautioned, 3 = Restricted, 4 = AdultsOnly,)\n Please type in only the number: ");
			string rating = Console.ReadLine();
			movie.Rating = update ? (rating != "" ? (AgeRating)int.Parse(rating) : old.Rating) : (AgeRating)int.Parse(rating);

			Console.Write("\n Order date: ");
			string ordate = Console.ReadLine();
			string[] odate = ordate.Split('.');
			movie.OrderDate = update ? (ordate != "" ? new DateTime(int.Parse(odate[0]), int.Parse(odate[1]), int.Parse(odate[2])) : old.OrderDate) : ordate == "" ? null : new DateTime(int.Parse(odate[0]), int.Parse(odate[1]), int.Parse(odate[2]));

			

			Console.Write("\n Year: ");
			string year = Console.ReadLine();
			movie.Year = update ? (year != "" ? int.Parse(year) : old.Year) :int.Parse(year);

			Console.Write("\n Name: ");
			string name = Console.ReadLine();
			movie.Name = update ? (name != "" ? name : old.Name) : name;

			return movie;
		}
		public static Showtime MakeShowtime(bool update = false, Showtime old = null)
		{
			Showtime showtime;
			if (update) showtime = old;
			else showtime = new Showtime();

			Console.Write("\n City name: ");
			string city = Console.ReadLine();
			showtime.City = update ? (city != "" ? city : old.City) : city;

			Console.Write("\n Room number: ");
			string room = Console.ReadLine();
			showtime.Room = update ? (room != "" ? int.Parse(room) : old.Room) : int.Parse(room);

			Console.Write("\n CinemaName: ");
			string cinemaname = Console.ReadLine();
			showtime.CinemaName = update ? (cinemaname != "" ? cinemaname : old.CinemaName) : cinemaname;

			Console.Write("\n Delivery date: (year.month.day.hour.minute.second");
			string deldate = Console.ReadLine();
			string[] ddate = deldate.Split('.');
            showtime.DateTime = update ? (deldate != "" ? new DateTime(int.Parse(ddate[0]), int.Parse(ddate[1]), int.Parse(ddate[2])) : old.DateTime) : deldate == "" ? null : new DateTime(int.Parse(ddate[0]), int.Parse(ddate[1]), int.Parse(ddate[2]));

			Console.Write("Movie ID: ");
			string movid = Console.ReadLine();
			showtime.MovieId = update ? (movid != "" ? int.Parse(movid) : old.MovieId) : int.Parse(movid);

			return showtime;

		}
		#endregion


	}
}
