﻿using Microsoft.EntityFrameworkCore;
using MRDN68_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRDN68_HFT_2021221.Data
{
    public class MovieProgrammeDbContext : DbContext
    {
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Showtime> Showtimes { get; set; }

        public MovieProgrammeDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                    UseLazyLoadingProxies().
                    UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // "The primary key value needs to be specified even if it's usually generated by the database. It will be used to detect data changes between migrations"
            Director tarantino = new Director() { Id = 1, Name = "Quentin Tarantino", BirthYear = 1963 };
            Director jackson = new Director() { Id = 2, Name = "Peter Jackson", BirthYear = 1961 };
            Director colombus = new Director() { Id = 3, Name = "Chris Colombus"  , BirthYear = 1958 };

            Movie tarantino1 = new Movie() { Id = 1, DirectorId = tarantino.Id, Year = 1994, Name = "Pulp Fiction", Rating = AgeRating.Restricted };
            Movie tarantino2 = new Movie() { Id = 2, DirectorId = tarantino.Id, Year = 2003 ,Name = "Kill Bill 1.", Rating = AgeRating.Restricted };
            Movie jackson1 = new Movie() { Id = 3, DirectorId = jackson.Id, Year = 2003, Name = "Lord of the Rings: The Return of the King", Rating = AgeRating.ParentsStronglyCautioned }; //Lord of the Rings ParentsStronglyCautioned
            Movie jackson2 = new Movie() { Id = 4, DirectorId = jackson.Id, Year = 2003, Name = "Lord of the Rings: The two Towers", Rating = AgeRating.ParentsStronglyCautioned };
            Movie colombus1 = new Movie() { Id = 5, DirectorId = colombus.Id, Year = 2001, Name = "Harry Potter and the Philosopher's Stone", Rating = AgeRating.ParentalGuidanceSuggested };//Harry Potter and the ParentalGuidanceSuggested
            Movie colombus2 = new Movie() { Id = 6, DirectorId = colombus.Id, Year = 2004, Name = "Harry Potter and the Prisoner of Azkaban", Rating = AgeRating.ParentalGuidanceSuggested};

            Showtime showtime1 = new Showtime() { Id = 1, MovieId = 1, DateTime = new DateTime(1996, 1, 13, 11, 0, 0), CinemaName = "Cinema City Arena", City = "Budapest", Room = 1 };
            Showtime showtime2 = new Showtime() { Id = 2, MovieId = 1, DateTime = new DateTime(2004, 1, 13, 17, 30,0), CinemaName = "Cinema City Allee", City = "Budapest", Room = 11 };
            Showtime showtime3 = new Showtime() { Id = 3, MovieId = 2, DateTime = new DateTime(2004, 2, 25, 9, 50, 0), CinemaName = "Cinema City Westend", City = "Budapest", Room = 2 };
            Showtime showtime4 = new Showtime() { Id = 4, MovieId = 4, DateTime = new DateTime(2006, 5, 3, 18, 10, 0), CinemaName = "Cinema City Arena", City = "Budapest", Room = 1 };
            Showtime showtime5 = new Showtime() { Id = 5, MovieId = 5, DateTime = new DateTime(2007, 10, 18, 15, 40, 0), CinemaName = "Corvin Mozi", City = "Budapest", Room = 5 };
            Showtime showtime6 = new Showtime() { Id = 6, MovieId = 6, DateTime = new DateTime(2006, 12, 15, 13, 0, 0), CinemaName = "Cinema City Győr", City = "Győr", Room = 3 };

            // FLUENT API (lehetne a Brand osztalyban is -> ForeignKey attributum)
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasOne(movie => movie.Director)
                      .WithMany(Director => Director.Movies)
                      .HasForeignKey(movie => movie.DirectorId)
                      .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Showtime>(entity =>
            {
                entity.HasOne(showtime => showtime.Movie)
                      .WithMany(Movie => Movie.Showtimes)
                      .HasForeignKey(showtime => showtime.MovieId)
                      .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Director>().HasData(tarantino, jackson, colombus);
            modelBuilder.Entity<Movie>().HasData(tarantino1, tarantino2, jackson1, jackson2, colombus1, colombus2);
            modelBuilder.Entity<Showtime>().HasData(showtime1, showtime2, showtime3, showtime4, showtime5, showtime6);
        }

    }
}
