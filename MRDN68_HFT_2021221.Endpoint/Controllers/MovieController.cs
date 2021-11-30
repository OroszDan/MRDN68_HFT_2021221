using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MRDN68_HFT_2021221.Logic;
using MRDN68_HFT_2021221.Models;
using System.Collections.Generic;

namespace MRDN68_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")] //    /movie
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieLogic logic;

        public MovieController(IMovieLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet("test")] //      /movie/test
        public string Test()
        {

            return "TEST";
        }

        [HttpGet] //              /movie
        public IEnumerable<Movie> GetAll()
        {

            return logic.ReadAll();
        }

        [HttpPost] //             /movie
        public void AddOne([FromBody] Movie movie)
        {

            logic.Create(movie);
        }

        [HttpPut] //              /movie
        public void EditOne([FromBody] Movie movie)
        {

            logic.Update(movie);
        }

        [HttpDelete("{movieId}")] //   /movie/{movieId}
        public void DeleteOne([FromRoute] int movieId)
        {

            logic.Delete(movieId);
        }
    }
}



