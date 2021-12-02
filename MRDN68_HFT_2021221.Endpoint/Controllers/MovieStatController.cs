using Microsoft.AspNetCore.Mvc;
using MRDN68_HFT_2021221.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRDN68_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MovieStatController : ControllerBase
    {
        IMovieLogic logic;

        public MovieStatController(IMovieLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet] //  GET:     moviestat/getquery1
        public IEnumerable<KeyValuePair<string, int>> GetQuery1()
        {
            return logic.CountOfMoviesAfter2000ByDirectorNamesAndOrderedbyDirectorNames();
        }
    }
}
