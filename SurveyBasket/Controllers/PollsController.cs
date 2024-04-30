using Azure.Core;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyBasket.Contracts.Polls;
using SurveyBasket.Services;
using System.Threading;

namespace SurveyBasket.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PollsController(IPollService pollService) : ControllerBase

{
    private readonly IPollService _pollService=pollService;
    [HttpGet("")]
    public async Task< IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var polls=await _pollService.GetAllAsync(cancellationToken);
        return  Ok(polls);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id, CancellationToken cancellationToken )
    {

        var poll=await _pollService.GetByIdAsync(id,cancellationToken);
        return poll is null ? NotFound() : Ok(poll);
    }
   
    [HttpPost("")]
    public async Task<IActionResult> Add([FromBody] PollRequest request,CancellationToken cancellationToken )
    {
        var newPoll = await _pollService.AddAsync(request.Adapt<Poll>(),cancellationToken);

        return CreatedAtAction(nameof(Get), new { id = newPoll.Id }, newPoll);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute]   int id,   [FromBody] PollRequest request, CancellationToken cancellationToken )
    {

        if (id != request.Id) return BadRequest();
        bool result= await _pollService.UpdateAsync(request.Adapt<Poll>(),cancellationToken);
        return !result ? NotFound() : NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken )
    {
        bool result= await _pollService.DeleteAsync(id,cancellationToken);
        return !result ? NotFound() : NoContent();
    }

    [HttpPut("{id}/TogglePublish")]
    public async Task<IActionResult> TogglePublish([FromRoute] int id, CancellationToken cancellationToken)
    {

        bool result= await _pollService.TogglePublishAsync(id,cancellationToken);
        return !result ? NotFound() : NoContent();
    }
}
