using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MRDN68_HFT_2021221.Logic;
using MRDN68_HFT_2021221.Models;
using System.Collections.Generic;

namespace MRDN68_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")] //    /director
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private IDirectorLogic logic;

        public DirectorController(IDirectorLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet("test")] //      /director/test
        public string Test()
        {

            return "TEST";
        }

        [HttpGet] //              /director
        public IEnumerable<Director> GetAll()
        {

            return logic.ReadAll();
        }

        [HttpPost] //             /director
        public void AddOne([FromBody] Director director)
        {

            logic.Create(director);
        }

        [HttpPut] //              /director
        public void EditOne([FromBody] Director director)
        {

            logic.Update(director);
        }

        [HttpDelete("{showtimeId}")] //   /director/{directorId}
        public void DeleteOne([FromRoute] int directorId)
        {

            logic.Delete(directorId);
        }
    }
}



