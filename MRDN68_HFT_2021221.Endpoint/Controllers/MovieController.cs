using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MRDN68_HFT_2021221.Logic;
using MRDN68_HFT_2021221.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using MRDN68_HFT_2021221.Endpoint.Services;

namespace MRDN68_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")] //    /movie
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieLogic logic;

        private IHubContext<SignalRHub> hub;

        public MovieController(IMovieLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
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

        [HttpGet("{id}")] //              /movie
        public Movie GetOne(int id)
        {
            return logic.Read(id);
        }

        [HttpPost] //             /movie
        public void AddOne([FromBody] Movie movie)
        {

            logic.Create(movie);
            this.hub.Clients.All.SendAsync("MovieCreated",movie);
        }

        [HttpPut] //              /movie
        public void EditOne([FromBody] Movie movie)
        {

            logic.Update(movie);
            this.hub.Clients.All.SendAsync("MovieUpdated", movie);

        }

        [HttpDelete("{id}")] //   /movie/{id}
        public void DeleteOne([FromRoute] int id)
        {
            var movieToDelete = logic.Read(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("MovieDeleted", movieToDelete);

        }
    }
}



