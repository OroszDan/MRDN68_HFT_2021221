using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MRDN68_HFT_2021221.Logic;
using MRDN68_HFT_2021221.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using MRDN68_HFT_2021221.Endpoint.Services;

namespace MRDN68_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")] //    /director
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private IDirectorLogic logic;
        private IHubContext<SignalRHub> hub;


        public DirectorController(IDirectorLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
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

        [HttpGet("{id}")] //              /director/1
        public Director GetOne(int id)
        {
            return logic.Read(id);
        }

        [HttpPost] //             /director
        public void AddOne([FromBody] Director director)
        {

            logic.Create(director);
            this.hub.Clients.All.SendAsync("DirectorCreated", director);
        }

        [HttpPut] //              /director
        public void EditOne([FromBody] Director director)
        {

            logic.Update(director);
            this.hub.Clients.All.SendAsync("DirectorUpdated", director);

        }

        [HttpDelete("{id}")] //   /director/{id}
        public void DeleteOne([FromRoute] int id)
        {
            var directorToDelete = logic.Read(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("DirectorDeleted", directorToDelete);
        }
    }
}



