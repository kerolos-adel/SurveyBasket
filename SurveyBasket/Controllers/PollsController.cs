namespace SurveyBasket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PollsController : ControllerBase
{
    private readonly IPollService _pollService;
    public PollsController(IPollService pollService)
    {
        _pollService = pollService;
    }
    [HttpGet("")]
    public IActionResult GetAll()
    {
        return Ok(_pollService.GetAll());
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var poll = _pollService.GetById(id);
        if (poll == null)
        {
            return NotFound();
        }
        return Ok(poll);
    }
    [HttpPost("")]
    public IActionResult Add(Poll request)
    {
        var newpoll = _pollService.Add(request);
        return CreatedAtAction(nameof(Get), new {id = newpoll?.Id},newpoll);
    }
    [HttpPut("{id}")]
    public IActionResult Update(int id,Poll poll) 
    {
        var isUpdated = _pollService.Update(id, poll);
        if (isUpdated==false)
        {
            return NotFound();
        }
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {

        var isDeleted = _pollService.Delete(id);
        if (isDeleted == false)
        {
            return NotFound();
        }
        return NoContent();
    }

}
    