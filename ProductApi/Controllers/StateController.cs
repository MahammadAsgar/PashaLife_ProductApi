using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductApi.Data.ViewModel;
using ProductApi.Services;
using ProductApi.Services.Abstract;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateRepository _service;
        private readonly ILogger<StateController> _logger;

        public StateController(IStateRepository service, ILogger<StateController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost("add-state")]
        public IActionResult AddState([FromBody] StateVM stateVM)
        {
            _logger.LogInformation("This is AddState()");
            _service.AddState(stateVM);
            return Ok(stateVM);
        }

        [HttpPut("update-state")]
        public IActionResult UpdateState(int id, StateVM stateVM)
        {
            _logger.LogInformation("This is UpdateState()");
            var state = _service.UpdateState(id, stateVM);
            return Ok(state);
        }
        [HttpDelete("delete-state")]
        public IActionResult DeleteState(int id)
        {
            _logger.LogInformation("This is DeleteState()");
            _service.DeleteState(id);
            return Ok();
        }
        [HttpGet("get-state-by-id")]
        public IActionResult GetStateById(int id)
        {
            _logger.LogInformation("This is GetState()");
            var state = _service.GetState(id);
            return Ok(state);
        }
        [HttpGet("get-all-states")]
        public IActionResult GetAllStates()
        {
            _logger.LogInformation("This is GetAllStates()");
            var states = _service.GetAllStates();
            return Ok(states);
        }
    }
}
