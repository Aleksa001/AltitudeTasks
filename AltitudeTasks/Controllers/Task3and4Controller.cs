using AltitudeTasks.Class;
using AltitudeTasks.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AltitudeTasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Task3and4Controller : ControllerBase
    {
        private readonly ICounterForRequests _counterForRequests;
        private readonly IInputService _InputService;
        public Task3and4Controller(ICounterForRequests counterForRequests, IInputService inputService)
        {
            _counterForRequests = counterForRequests;
            _InputService = inputService;
        }

        [HttpGet("getCount")]
        public ActionResult<int> GetCount()
        {
            _counterForRequests.IncrementCounter();
            return Ok(_counterForRequests.GetCounter());
        }

        [HttpPost("upload")]
        public IActionResult Upload([FromBody] Input input)
        {
            _counterForRequests.IncrementCounter();

            if (string.IsNullOrEmpty(input.FirstName) ||
               string.IsNullOrEmpty(input.LastName)  ||
               string.IsNullOrEmpty(input.Telephone))
            {
                return BadRequest("Some of the fields are empty. Fill all fields!");
            }
           
            return Ok(_InputService.AddInput(input));
        }

        [HttpGet("list")]
        public IActionResult GetTelephones()
        {
            _counterForRequests.IncrementCounter();

            Output outputs = new Output
            {
                outputs = _InputService.GetAllInputs()
            };

            return Ok(outputs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            _counterForRequests.IncrementCounter();

            Input input = _InputService.GetInput(id);
            if(input == null)
            {
                return NotFound($"Input with id {id} does not exist!");
            }

            return Ok(input);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            _counterForRequests.IncrementCounter();

            Input input = _InputService.GetInput(id);
            if (input == null)
            {
                return NotFound($"Input with id {id} does not exist!");
            }
            _InputService.DeleteInput(id);

            return Ok($"Input with id {id} is successfully deleted!");
        }
    }
}
