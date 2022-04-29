using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MRDN68_HFT_2021221.Logic;
using MRDN68_HFT_2021221.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using MRDN68_HFT_2021221.Endpoint.Services;

namespace MRDN68_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")] //    /showtime
    [ApiController]
    public class ShowtimeController : ControllerBase
    {
        private IShowtimeLogic logic;
        private IHubContext<SignalRHub> hub;


        public ShowtimeController(IShowtimeLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet("test")] //      /showtime/test
        public string Test()
        {

            return "TEST";
        }

        [HttpGet] //              /showtime
        public IEnumerable<Showtime> GetAll()
        {

            return logic.ReadAll();
        }

        [HttpGet("{id}")] //              /showtime
        public Showtime GetOne(int id)
        {
            return logic.Read(id);
        }

        [HttpPost] //             /showtime
        public void AddOne([FromBody] Showtime showtime)
        {

            logic.Create(showtime);
            this.hub.Clients.All.SendAsync("ShowtimeCreated", showtime);

        }

        [HttpPut] //              /showtime
        public void EditOne([FromBody] Showtime showtime)
        {

            logic.Update(showtime);
            this.hub.Clients.All.SendAsync("ShowtimeUpdated", showtime);

        }

        [HttpDelete("{id}")] //   /showtime/{showtimeId}
        public void DeleteOne([FromRoute] int id)
        {
            var showtimeToDelete = logic.Read(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("ShowtimeDeleted", showtimeToDelete);

        }
    }
}


