using Microsoft.AspNetCore.Mvc;
using MRDN68_HFT_2021221.Logic;
using MRDN68_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MRDN68_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ShowtimeStatController : ControllerBase
    {
        private IShowtimeLogic logic;

        public ShowtimeStatController(IShowtimeLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet] //  GET:     showtimestat/getquery2
        public IEnumerable<AgeRating> GetQuery2()
        {
            return logic.MovieAgeRatingsInCinemaCityArena();
        }

        [HttpGet] //  GET:     showtimestat/getquery3
        public IEnumerable<string> GetQuery3()
        {
            return logic.DirectorNamesOfMoviesShownBefore2004InCinemaCityCinemas();
        }

        [HttpGet] //  GET:     showtimestat/getquery4
        public IEnumerable<string> GetQuery4()
        {
            return logic.PGCategoryMovieNamesShownAfter12_30();
        }

        [HttpGet] //  GET:     showtimestat/getquery5
        public IEnumerable<DateTime> GetQuery5()
        {
            return logic.DateTimesOfMoviesShownInBudapestWhoseDirectorsBornBefore1962();
        }
    }
}
