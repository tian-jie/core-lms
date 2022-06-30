using CoreLMS.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreLMS.Web.Areas.Admin.Pages.Home
{
    [Route("api/home")]
    [ApiController]
    public class HomeApiController : ControllerBase
    {
        private IClockifyService _clockifyService;

        public HomeApiController(IClockifyService clockifyService)
        {
            _clockifyService = clockifyService;
        }

        // GET: api/<ApiController>
        [HttpGet("sync-clockify")]
        public async Task<int> SyncClockify(string startDate, string endDate)
        {
            var loginModel = await _clockifyService.Login("jie.tian@innocellence.com", "Welcome1!");
            var workspaceId = await _clockifyService.GetWorkspaceId(loginModel.id, loginModel.token);
            var timeEntriesInClockify = await _clockifyService.GetTimeEntries(workspaceId, loginModel.token, startDate, endDate);
            await _clockifyService.UpdateTimeEntriesToDatabase(int.Parse(startDate.Replace("-", "")), int.Parse(endDate.Replace("-", "")), timeEntriesInClockify);

            return timeEntriesInClockify.Count;
        }

        // GET api/<ApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }




    }
}
