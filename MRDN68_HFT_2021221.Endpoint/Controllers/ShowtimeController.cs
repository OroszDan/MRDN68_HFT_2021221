using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MRDN68_HFT_2021221.Logic;
using MRDN68_HFT_2021221.Models;
using System.Collections.Generic;

namespace MRDN68_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")] //    /showtime
    [ApiController]
    public class ShowtimeController : ControllerBase
    {
        private IShowtimeLogic logic;

        public ShowtimeController(IShowtimeLogic logic)
        {
            this.logic = logic;
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

        [HttpPost] //             /showtime
        public void AddOne([FromBody] Showtime showtime)
        {

            logic.Create(showtime);
        }

        [HttpPut] //              /showtime
        public void EditOne([FromBody] Showtime showtime)
        {

            logic.Update(showtime);
        }

        [HttpDelete("{showtimeId}")] //   /showtime/{showtimeId}
        public void DeleteOne([FromRoute] int showtimeId)
        {

            logic.Delete(showtimeId);
        }
    }
}


