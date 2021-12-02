using NUnit.Framework;
using MRDN68_HFT_2021221.Repository;
using MRDN68_HFT_2021221.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MRDN68_HFT_2021221.Models;

namespace MRDN68_HFT_2021221.Test
{
    [TestFixture]
    class LogicTestsMoq
    {
        IShowtimeLogic ShowtimeLogic;
        IMovieLogic MovieLogic;
        IDirectorLogic DirectorLogic;

        [SetUp]
        public void ShowtimeSetup()
        {
            Director tarantino = new Director() { Name = "Quentin Tarantino", BirthYear = 1963 };
            Director jackson = new Director() { Name = "Peter Jackson", BirthYear = 1961};
            Director colombus = new Director() { Name = "Chris Colombus", BirthYear = 1958 };
             
            Movie tarantino1 = new Movie() { Director = tarantino, Year = 1994, Name = "Pulp Fiction", Rating = AgeRating.Restricted };
            Movie tarantino2 = new Movie() { Director = tarantino, Year = 2003, Name = "Kill Bill 1.", Rating = AgeRating.Restricted };
            Movie jackson1 = new Movie() { Director = jackson, Year = 2003, Name = "Lord of the Rings: The Return of the King", Rating = AgeRating.ParentsStronglyCautioned };
            Movie jackson2 = new Movie() { Director = jackson, Year = 2003, Name = "Lord of the Rings: The two Towers", Rating = AgeRating.ParentsStronglyCautioned };
            Movie colombus1 = new Movie() { Director = colombus, Year = 2001, Name = "Harry Potter and the Philosopher's Stone", Rating = AgeRating.ParentalGuidanceSuggested };
            Movie colombus2 = new Movie() { Director = colombus, Year = 2004, Name = "Harry Potter and the Prisoner of Azkaban", Rating = AgeRating.ParentalGuidanceSuggested };

            Mock<IShowtimeRepository> mockShowtimes = new Mock<IShowtimeRepository>();
            Mock<IMovieRepository> mockMovies = new Mock<IMovieRepository>();
            Mock<IDirectorRepository> mockDirectors = new Mock<IDirectorRepository>();

           
            tarantino.Movies = new List<Movie> { tarantino1, tarantino2 };
            jackson.Movies = new List<Movie> { jackson1, jackson2 };
            colombus.Movies = new List<Movie> { colombus1, colombus2 };

            Showtime showtime1 =
                new Showtime() { Movie = tarantino1, DateTime = new DateTime(1996, 1, 13, 11, 0, 0), CinemaName = "Cinema City Arena", City = "Budapest", Room = 1 };
            Showtime showtime2 =
                new Showtime() { Movie = tarantino1, DateTime = new DateTime(2004, 1, 13, 17, 30, 0), CinemaName = "Cinema City Allee", City = "Budapest", Room = 11 };
            Showtime showtime3 =
                new Showtime() { Movie = tarantino2, DateTime = new DateTime(2004, 2, 25, 9, 50, 0), CinemaName = "Cinema City Westend", City = "Budapest", Room = 2 };
            Showtime showtime4 =
                new Showtime() { Movie = jackson2, DateTime = new DateTime(2006, 5, 3, 18, 10, 0), CinemaName = "Cinema City Arena", City = "Budapest", Room = 1 };
            Showtime showtime5 =
                new Showtime() { Movie = colombus1, DateTime = new DateTime(2007, 10, 18, 15, 40, 0), CinemaName = "Corvin Mozi", City = "Budapest", Room = 5 };
            //Showtime showtime7 =
            //   new Showtime() { Movie = colombus1, DateTime = new DateTime(2008, 10, 18, 15, 40, 0), CinemaName = "Corvin Mozi", City = "Budapest", Room = 5 };
            Showtime showtime6 =
                new Showtime() { Movie = colombus2, DateTime = new DateTime(2006, 12, 15, 13, 0, 0), CinemaName = "Cinema City Győr", City = "Győr", Room = 3 };

            tarantino1.Showtimes = new List<Showtime> { showtime1, showtime2 };
            tarantino2.Showtimes = new List<Showtime> { showtime3 };
            jackson2.Showtimes = new List<Showtime> { showtime4 };
            colombus1.Showtimes = new List<Showtime> { showtime5 };
            colombus2.Showtimes = new List<Showtime> { showtime6 };

            mockMovies.Setup(x => x.ReadAll())
                .Returns(new List<Movie>
                {
                    tarantino1,tarantino2,jackson1,jackson2,colombus1,colombus2

                }.AsQueryable());

            mockDirectors.Setup(x => x.ReadAll())
                .Returns(new List<Director>
                {
                    tarantino,jackson,colombus

                }.AsQueryable());

            mockShowtimes.Setup(x => x.ReadAll())
                .Returns(new List<Showtime>
                {
                    showtime1,showtime2,showtime3,showtime4,showtime5,showtime6,

                }.AsQueryable());


            ShowtimeLogic = new ShowtimeLogic(mockShowtimes.Object);
            MovieLogic = new MovieLogic(mockMovies.Object);
            DirectorLogic = new DirectorLogic(mockDirectors.Object);
        }

        [Test]
        public void CheckCountOfMoviesAfter2000ByDirectorNamesAndOrderedbyDirectorNames()
        {//2000 utáni filmek száma rendezőként csoportosítva, azon belül ábécé sorrendben
            List<KeyValuePair<string, int>> expresult = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int> ("Chris Colombus",1),
                new KeyValuePair<string, int> ("Peter Jackson",2),
                new KeyValuePair<string, int> ("Quentin Tarantino",1)
            };

            List<KeyValuePair<string, int>> result = MovieLogic.CountOfMoviesAfter2000ByDirectorNamesAndOrderedbyDirectorNames().ToList();

           CollectionAssert.AreEqual(expresult,result);
        }

        [Test]
        public void CheckMovieAgeRatingsInCinemaCityArena()
        {
            // ciname city arenaban vetített filmek besorolásai
            List<AgeRating> ageRatings = new()
            {
                AgeRating.Restricted,
                AgeRating.ParentsStronglyCautioned
            };

            List<AgeRating> result = ShowtimeLogic.MovieAgeRatingsInCinemaCityArena().ToList();
            CollectionAssert.AreEquivalent(ageRatings, result);
            
        }


        [Test]
        public void CheckDirectorNamesOfMoviesShownBefore2004InCinemaCityCinemas()
        {
            // Cinema City - ben vetített 2004 előtt készült mozik rendezői

            List<string> queryresult = new List<string>
            {
               
                "Peter Jackson",
                 "Quentin Tarantino"
            };

            List<string> result = ShowtimeLogic.DirectorNamesOfMoviesShownBefore2004InCinemaCityCinemas().ToList();
            CollectionAssert.AreEquivalent(queryresult, result);         
           
        }

        [Test]
        public void CheckPGCategoryMovieNamesShownAfter12_30()
        {// 12:00 után vetített PG kategóriás filmek nevei
            List<string> testresult = new()
            {
                "Harry Potter and the Philosopher's Stone",
                "Harry Potter and the Prisoner of Azkaban"
            };

            List<string> queryresult = ShowtimeLogic.PGCategoryMovieNamesShownAfter12_30().ToList();
            Assert.AreEqual(queryresult, testresult);
        }

        [Test]
        public void CheckDateTimesOfMoviesShownInBudapestWhoseDirectorsBornBefore1962()
        {
            var result = ShowtimeLogic.DateTimesOfMoviesShownInBudapestWhoseDirectorsBornBefore1962().ToList();

            List<DateTime> expresult = new List<DateTime>
            {
                new DateTime(2007, 10, 18, 15, 40, 0),
                new DateTime(2006, 5, 3, 18, 10, 0)
            };

            CollectionAssert.AreEquivalent(expresult, result);
        }

        [Test]
        public void ShowtimeCreateExceptionTest()
        {
            //1.
            Assert.Throws(typeof(ArgumentException), () => ShowtimeLogic.Create(null));
            
            Showtime testshowtime1 = new()
            {
                City = "Kispest",
                CinemaName = "",
                Room = 0,
               

            };

            //2.
            Assert.Throws(typeof(ArgumentException), () => ShowtimeLogic.Create(testshowtime1));
          
            Showtime testshowtime2 = new()
            {
                City = "Budapest",
                CinemaName = "Etele Mozi",
                Room = 0

            };

            //3.
            Assert.Throws(typeof(ArgumentException), () => ShowtimeLogic.Create(testshowtime2));
            
            Showtime testshowtime3 = new()
            {
                City = "Budapest",
                CinemaName = "Etele Mozi",
                DateTime = new DateTime(2017, 02, 2, 5, 6, 0)

            };

            //3.
            Assert.Throws(typeof(ArgumentException), () => ShowtimeLogic.Create(testshowtime3));

        }

        [Test]
        public void MovieCreateExceptionTest()
        { 
            //1.
            Assert.Throws(typeof(ArgumentException), () => MovieLogic.Create(null));
          
            Movie testmovie1 = new()
            {
                Name = "",
                Year = 1492,
                 Rating = AgeRating.AdultsOnly             
            };

            //2.
            Assert.Throws(typeof(ArgumentException), () => MovieLogic.Create(testmovie1));

          
            Movie testmovie2 = new()
            {
                Name = "jóskapista",
                Year = 1492,
               
            };

            //3.
            Assert.Throws(typeof(ArgumentException), () => MovieLogic.Create(testmovie2));

        }

        [Test]
        public void DirectorCreateExceptionTest()
        {
            //1.
            Assert.Throws(typeof(ArgumentException), () => DirectorLogic.Create(null));
            
            Director testdirector1 = new()
            {
                BirthYear = 2001
            };
            //2.
            Assert.Throws(typeof(ArgumentException), () => DirectorLogic.Create(testdirector1));
            
            Director testdirector2 = new()
            {
                Name = "Mariska",
                
            };
            //3.
            Assert.Throws(typeof(ArgumentException), () => DirectorLogic.Create(testdirector2));


        }

       

        [Test]
        public void DirectorMoviesInstanceTest() 
        {
            Director director = new()
            {
                Name = "asacadsdddddddddd",
                BirthYear = 45677

            };

            Assert.That(director.Movies != null);

        }

        [Test]
        public void MoviesShowtimesInstanceTest()
        {
            Movie movie = new()
            {
                Name = "haleluja",
                Rating = AgeRating.AdultsOnly
            };

            Assert.That(movie.Showtimes != null);

        }



    }
}
