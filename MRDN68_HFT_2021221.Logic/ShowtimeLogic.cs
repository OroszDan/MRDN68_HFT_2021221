﻿using MRDN68_HFT_2021221.Models;
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
        public IQueryable<string> Query1()
        {// ciname city arenaban vetített filmek rendezői
            string str = "Cinema City Arena";
            /*var q0 = */
            return ReadAll()
                    .Where(x => x.CinemaName == str).Select(x => x.Movie.Director.Name);
                   
        }
        public IEnumerable<bool> lekerdezes2()
        {// vetítenek-e 2000 előtt készült filmeket
            //var q1 = 
                return ReadAll()
                      .Select(x => x.Movie)
                      .Select(x => x.Year < 2000);
        }
        public void lekerdezes3()
        {// az 1-es teremben vetített előadások besorolás alapján csoportosítva
            var q2 = ReadAll()
                .Where(x => x.Room == 1).GroupBy(x => x.Movie.Rating);
                
                      
        }
        public IQueryable<string> Query4()
        {// 12:30 után vetített filmek nevei
            DateTime date = new DateTime(2004, 1, 13, 12, 30, 0);
            return ReadAll()
                .Where(x => (x.DateTime.Hour >= date.Hour) && (x.DateTime.Minute > date.Minute))
                .Select(x => x.Movie.Name);

                      
        }
        public void lekerdezes5()
        {// budapesten vetített, legújabb, férfi által rendezett film évszáma
            string city = "Budapest";

            var q4 = ReadAll()
                .Where(x => x.City == city)
                .Select(x => x.Movie)
                .Where(x => x.Director.Gender == Gender.male)
                .Max(x => x.Year);
            //var q4_v2 = from showtimes in ReadAll()
            //            let newestmovieyear = showtimes.
                      
        }

        public void Create(Showtime showtime)
        {
            repo.Create(showtime);
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