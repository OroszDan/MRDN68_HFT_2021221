using NUnit.Framework;
using MRDN68_HFT_2021221.Repository;
using MRDN68_HFT_2021221.Data;
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
        public void Setup()
        {
            Director tarantino = new Director() { Name = "Quentin Tarantino" };
            Director jackson = new Director() { Name = "Peter Jackson" };
            Director colombus = new Director() { Name = "Chris Colombus" };

            Movie tarantino1 = new Movie() { Director = tarantino, Year = 1994, Name = "Pulp Fiction", Rating = AgeRating.Restricted };
            Movie tarantino2 = new Movie() { Director = tarantino, Year = 2003, Name = "Kill Bill 1.", Rating = AgeRating.Restricted };
            Movie jackson1 = new Movie() { Director = jackson, Year = 2003, Name = "Lord of the Rings: The Return of the King", Rating = AgeRating.ParentsStronglyCautioned };
            Movie jackson2 = new Movie() { Director = jackson, Year = 2003, Name = "Lord of the Rings: The two Towers", Rating = AgeRating.ParentsStronglyCautioned };
            Movie colombus1 = new Movie() { Director = colombus, Year = 2001, Name = "Harry Potter and the Philosopher's Stone", Rating = AgeRating.ParentalGuidanceSuggested };
            Movie colombus2 = new Movie() { Director = colombus, Year = 2004, Name = "Harry Potter and the Prisoner of Azkaban", Rating = AgeRating.ParentalGuidanceSuggested };

            Mock<IShowtimeRepository> mockShowtimes = new Mock<IShowtimeRepository>();

            mockShowtimes.Setup(x => x.ReadAll())
            .Returns(new List<Showtime>
            {
                new Showtime() {  Movie = tarantino1, DateTime = new DateTime(1996, 1, 13, 11, 0, 0), CinemaName = "Cinema City Arena", City = "Budapest", Room = 1 },
                new Showtime() {  Movie = tarantino2, DateTime = new DateTime(2004, 1, 13, 17, 30, 0), CinemaName = "Cinema City Allee", City = "Budapest", Room = 11 },
                new Showtime() {  Movie = jackson1, DateTime = new DateTime(2004, 2, 25, 9, 50, 0), CinemaName = "Cinema City Westend", City = "Budapest", Room = 2 },
                new Showtime() {  Movie = jackson2, DateTime = new DateTime(2006, 5, 3, 18, 10, 0), CinemaName = "Cinema City Arena", City = "Budapest", Room = 1 },
                new Showtime() {  Movie = colombus1, DateTime = new DateTime(2007, 10, 18, 9, 40, 0), CinemaName = "Corvin Mozi", City = "Budapest", Room = 5 },
                new Showtime() {  Movie = colombus2, DateTime = new DateTime(2006, 12, 15, 13, 0, 0), CinemaName = "Cinema City Győr", City = "Győr", Room = 3 }

            }.AsQueryable());

            ShowtimeLogic = new ShowtimeLogic(mockShowtimes.Object);
        }

        [Test]
        public void CheckQuery4()
        {

            int count = ShowtimeLogic.Query4().Count();
            Assert.That(count == 1);
        }

        [Test]
        public void CheckQuery2()
        {
            bool truth = ShowtimeLogic.Query2();
            Assert.That(truth == true);
        }



    }
}
