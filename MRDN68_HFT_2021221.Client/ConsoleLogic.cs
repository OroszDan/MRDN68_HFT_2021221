using MRDN68_HFT_2021221.Models;
using System;
using System.Collections.Generic;

namespace MRDN68_HFT_2021221.Client
{
    class ConsoleLogic
    {
		#region Readable object
		private static string MakeDirectorReadable(Director d)
		{
			return $" ID: {d.Id},\n Name: {d.Name},\n BirthYear: {d.BirthYear}";
		}
		private static string MakeMovieReadable(Movie m)
		{
			return $" ID: {m.Id},\n Name: {m.Name},\n Rating: {m.Rating},\n Year: {m.Year},\n Director's Name: {m.Director.Name}";
		}
		private static string MakeShowtimeReadable(Showtime st)
		{
			return $" ID: {st.Id},\n CinemaName: {st.CinemaName},\n City: {st.City},\n DateTime: {st.DateTime},\n Room: {st.Room},\n MovieName: {st.Movie.Name}";
		}

		private static string MakeValuePairReadable(KeyValuePair<string, int> item)
		{
			return item.Key + $"\n Number of Movies: {item.Value}";
		}

		private static string[] MakeObjectArray(IEnumerable<object> objectlist, string type)
		{
			List<string> list = new List<string>();
			foreach (var item in objectlist)
			{
				switch (type)
				{
					case "director":
						list.Add(MakeDirectorReadable((Director)item));
						continue;
					case "movie":
						list.Add(MakeMovieReadable((Movie)item));
						continue;
					case "showtime":
						list.Add(MakeShowtimeReadable((Showtime)item));
						continue;
					default:
						continue;
				}
			}
			return list.ToArray();
		}
		#endregion

		#region Object Makers
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

			Console.WriteLine("Director making is done.");

			return director;
		}
		
		public static Movie MakeMovie(bool update = false, Movie old = null)
		{
			Movie movie;

			if (update) movie = old;
			else movie = new Movie();

			Console.Write("\n Rating:\n (0 = GeneralAudiences, 1 = ParentalGuidanceSuggested, 2 = ParentsStronglyCautioned, 3 = Restricted, 4 = AdultsOnly,)\n Please type in only the number: ");
			string rating = Console.ReadLine();
			movie.Rating = update ? (rating != "" ? (AgeRating)int.Parse(rating) : old.Rating) : (AgeRating)int.Parse(rating);			

			Console.Write("\n Year: ");
			string year = Console.ReadLine();
			movie.Year = update ? (year != "" ? int.Parse(year) : old.Year) :int.Parse(year);

			Console.Write("\n Name: ");
			string name = Console.ReadLine();
			movie.Name = update ? (name != "" ? name : old.Name) : name;

			Console.Write("Director ID: ");
			string dirid = Console.ReadLine();
			movie.DirectorId = update ? (dirid != "" ? int.Parse(dirid) : old.DirectorId) : int.Parse(dirid);

			Console.WriteLine("Movie making is done.");


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

			Console.Write("\n Delivery date:");
            Console.WriteLine("(year.month.day.hour.minute.second)");
			string deldate = Console.ReadLine();
			string[] ddate = deldate.Split('.');
            showtime.DateTime = update ? (deldate != "" ? new DateTime(int.Parse(ddate[0]), int.Parse(ddate[1]), int.Parse(ddate[2]), int.Parse(ddate[3]), int.Parse(ddate[4]),int.Parse(ddate[5])) : old.DateTime) /*: deldate == "" ? null*/ : new DateTime(int.Parse(ddate[0]), int.Parse(ddate[1]), int.Parse(ddate[2]), int.Parse(ddate[3]), int.Parse(ddate[4]), int.Parse(ddate[5]));

			Console.Write("Movie ID: ");
			string movid = Console.ReadLine();
			showtime.MovieId = update ? (movid != "" ? int.Parse(movid) : old.MovieId) : int.Parse(movid);

			Console.WriteLine("Showtime making is done.");

			return showtime;

		}
		#endregion

		#region Menus

		public static void DirectorThings(string action, RestService service)
		{
			Console.Clear();
			Console.WriteLine("**********************************");
			Console.WriteLine($"            {Program.crud_menu[int.Parse(action) - 1]} menu          ");
			Console.WriteLine("**********************************");
			Director dir;
			switch (action)
			{
				case "1":
					IEnumerable<Director> list = service.Get<Director>("director");
					WriteOuts.WriteOutAll(MakeObjectArray(list, "director"));
					break;
                case "2":
                    Console.WriteLine("Please write down the director id: ");
                    dir = service.Get<Director>(int.Parse(Console.ReadLine()), "director");
                    WriteOuts.WriteOutOne(MakeDirectorReadable(dir));
					break;
                case "3":
					try
					{
						dir = MakeDirector();
						service.Post<Director>(dir, "director");
					}
					catch (Exception e)
					{
						Console.WriteLine("Something went wrong!");
                        Console.WriteLine(e.Message);
					}
					break;
				case "4":
					Console.WriteLine("Please write down the director's id you want to change: ");
					try
					{

                        dir = service.Get<Director>(int.Parse(Console.ReadLine()), "director");
                        WriteOuts.WriteOutOne(MakeDirectorReadable(dir));
                        Console.WriteLine("If you don't want to change a property just hit enter.");
						dir = MakeDirector(true, dir);
						service.Put<Director>(dir, "director");
					}
					catch (Exception e)
					{
						Console.WriteLine("Something went wrong!");
						Console.WriteLine(e.Message);
					}
					break;
				case "5":
					Console.WriteLine("Please write down the director's id you want to delete: ");
					service.Delete(int.Parse(Console.ReadLine()), "director");
					break;
				default:
					break;
			}
		}
		public static void MovieThings(string action, RestService service)
		{
			Console.Clear();
			Console.WriteLine("**********************************");
			Console.WriteLine($"            {Program.crud_menu[int.Parse(action) - 1]} menu          ");
			Console.WriteLine("**********************************");
			Movie mov;
			switch (action)
			{
				case "1":
					IEnumerable<Movie> list = service.Get<Movie>("movie");
					WriteOuts.WriteOutAll(MakeObjectArray(list, "movie"));
					break;
                case "2":
                    Console.WriteLine("Please write down the movie id: ");
                    mov = service.Get<Movie>(int.Parse(Console.ReadLine()), "movie");
                    WriteOuts.WriteOutOne(MakeMovieReadable(mov));
					break;
                case "3":
					try
					{
						mov = MakeMovie();
						service.Post<Movie>(mov, "movie");
					}
					catch (Exception e)
					{
						Console.WriteLine("Something went wrong!");
						Console.WriteLine(e.Message);
					}
					break;
				case "4":
					Console.WriteLine("Please write down the movie's id you want to change: ");
					try
					{
						mov = service.Get<Movie>(int.Parse(Console.ReadLine()), "movie");
						WriteOuts.WriteOutOne(MakeMovieReadable(mov));
						Console.WriteLine("If you don't want to change a property just hit enter.");
						mov = MakeMovie(true, mov);
						service.Put<Movie>(mov, "movie");
					}
					catch(Exception e)
					{
						Console.WriteLine("Something went wrong!");
                        Console.WriteLine(e.Message);
					}
					break;
				case "5":
					Console.WriteLine("Please write down the movie's id you want to delete: ");
					service.Delete(int.Parse(Console.ReadLine()), "movie");
					break;
				default:
					break;
			}
		}
		public static void ShowtimeThings(string action, RestService service)
		{
			Console.Clear();
			Console.WriteLine("**********************************");
			Console.WriteLine($"            {Program.crud_menu[int.Parse(action) - 1]} menu          ");
			Console.WriteLine("**********************************");
			Showtime showt;
			switch (action)
			{
				case "1":
					IEnumerable<Showtime> list = service.Get<Showtime>("showtime");
					WriteOuts.WriteOutAll(MakeObjectArray(list, "showtime"));
					break;
				case "2":
					Console.WriteLine("Please write down the showtime id: ");
					showt = service.Get<Showtime>(int.Parse(Console.ReadLine()), "showtime");
					WriteOuts.WriteOutOne(MakeShowtimeReadable(showt));
					break;
				case "3":
					try
					{
						showt = MakeShowtime();
						service.Post<Showtime>(showt, "showtime");
					}
					catch(Exception e)
					{
						Console.WriteLine("Something went wrong!");
                        Console.WriteLine(e.Message);
					}
					break;
				case "4":
					Console.WriteLine("Please write down the showtime's id you want to change: ");
					try
					{
						showt = service.Get<Showtime>(int.Parse(Console.ReadLine()), "showtime");
						WriteOuts.WriteOutOne(MakeShowtimeReadable(showt));
						Console.WriteLine("If you don't want to change a property just hit enter.");
						showt = MakeShowtime(true, showt);
						service.Put<Showtime>(showt, "showtime");
					}
					catch(Exception e)
					{
						Console.WriteLine("Something went wrong!");
                        Console.WriteLine(e.Message);
					}
					break;
				case "5":
					Console.WriteLine("Please write down the showtime's id you want to delete: ");
					service.Delete(int.Parse(Console.ReadLine()), "showtime");
					break;
				default:
					break;
			}
		}
		
		public static void QueryThings(string action, RestService service)
		{
			Console.Clear();
			Console.WriteLine("************************************************");
            Console.WriteLine($"		Results");
			Console.WriteLine("************************************************");
			
            Console.WriteLine();

			switch (action)
			{
				case "1":
					IEnumerable<KeyValuePair<string, int>> list = service.Get<KeyValuePair<string, int>>("moviestat/getquery1");
					List<string> ollist = new List<string>();
					foreach (var item in list)
					{
						ollist.Add(MakeValuePairReadable(item));
					}
					WriteOuts.WriteOutAll(ollist.ToArray());
					break;
				case "2":
					
					List<AgeRating> ratinglist = service.Get<AgeRating>("showtimestat/getquery2");
					
					List<string> ratingliststring = new();
					foreach (var item in ratinglist)
					{
						ratingliststring.Add(item.ToString());
					};
					WriteOuts.WriteOutAll(ratingliststring.ToArray());
					break;
				case "3":
					
					string[] stringlist1 = service.Get<string>("showtimestat/getquery3").ToArray();
					WriteOuts.WriteOutAll(stringlist1);
					break;

				case "4":

					string[] stringlist2 = service.Get<string>("showtimestat/getquery4").ToArray();
					WriteOuts.WriteOutAll(stringlist2);
					break;

				case "5":

					List<DateTime> datetimelist = service.Get<DateTime>("showtimestat/getquery5");
					
					
					List<string> datetimeliststring = new();
                    foreach (var item in datetimelist)
                    {
						datetimeliststring.Add(item.ToString());
                    };
					WriteOuts.WriteOutAll(datetimeliststring.ToArray());
					break;
				default:
					break;
			}
		}
		#endregion
	}

	public class WriteOuts
	{
		public static void WriteOutAll(string[] data)
		{
			for (int i = 0; i < data.Length; i++)
			{
				;
				WriteOutOne(data[i]);
			}
		}
		public static void WriteOutOne(string data)
		{
			Console.WriteLine(data);
			Console.WriteLine();
		}
		public static string Menu(string MenuTitle, string[] menus)
		{
			Console.Clear();
			Console.WriteLine("********************************************");
			Console.WriteLine($"            {MenuTitle} menu          ");
			Console.WriteLine("********************************************");
			for (int i = 0; i < menus.Length; i++)
			{
				Console.WriteLine($"{i + 1} - {menus[i]}");
			}
			if (MenuTitle == "Main")
			{
				Console.WriteLine("----------------------------------------");
				Console.WriteLine("q - Quit");
			}
			Console.WriteLine("********************************************");

			Console.Write("Please give me the number of the option you would like to use: ");
			string back = Console.ReadLine();
			return back;
		}
	}
}
