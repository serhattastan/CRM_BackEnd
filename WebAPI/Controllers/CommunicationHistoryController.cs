using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunicationHistoryController : ControllerBase
    {
        ICommunicationHistoryService _communicationHistoryService;

        public CommunicationHistoryController(ICommunicationHistoryService communicationHistoryService)
        {
            _communicationHistoryService = communicationHistoryService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _communicationHistoryService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbydetails")]
        public IActionResult GetAllByDetails()
        {
            var result = _communicationHistoryService.GetCommunicationHistoryDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int communicationHistoryId)
        {
            var result = _communicationHistoryService.GetById(communicationHistoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("update")]
        public IActionResult Update(CommunicationHistory communicationHistory)
        {
            var result = _communicationHistoryService.Update(communicationHistory);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(CommunicationHistory communicationHistory)
        {
            var result = _communicationHistoryService.Add(communicationHistory);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int communicationHistoryId)
        {
            var result = _communicationHistoryService.Delete(communicationHistoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
