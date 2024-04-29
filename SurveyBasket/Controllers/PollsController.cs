using Azure.Core;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyBasket.Contracts.Requests;
using SurveyBasket.Services;
using System.Threading;

namespace SurveyBasket.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PollsController(IPollService pollService) : ControllerBase

{
    private readonly IPollService _pollService=pollService;
    [HttpGet("")]
    public async Task< IActionResult> GetAll()
    {
        var polls=await _pollService.GetAllPollsAsync();
        return  Ok(polls);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {

        var poll=await _pollService.GetByIdPollsAsync(id);
        return poll is null ? NotFound() : Ok(poll);
    }
   
    [HttpPost("")]
    public async Task<IActionResult> Add([FromBody] PollRequest request)
    {
        var newPoll = await _pollService.AddPollAsync(request.Adapt<Poll>());

        return CreatedAtAction(nameof(Get), new { id = newPoll.Id }, newPoll);
    }


}
