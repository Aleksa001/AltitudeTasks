using AltitudeTasks.Class;
using AltitudeTasks.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AltitudeTasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Task2Controller : ControllerBase
    {
        private readonly IListService _listService;
        private readonly ICounterForRequests _counterForRequests;
        public Task2Controller(IListService listService, ICounterForRequests counterForRequests)
        {
            _counterForRequests = counterForRequests;
            _listService = listService;
        }

        [HttpPost("uploadlist")]
        public IActionResult Upload([FromBody] ListInput input)
        {
            _counterForRequests.IncrementCounter();

            try
            {
                List<int> result = _listService.Proccess(input);
                ListOutput output = new ListOutput {
                    ID = Guid.NewGuid().ToString("N"),
                    Operation = input.Operation,
                    Data = result
                };
                return Ok(output);
            }
            catch (NotImplementedException ex) { 
                return BadRequest(ex.Message);
            }

           
        }
    }
}
