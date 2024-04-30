
using SurveyBasket.Entities;
using SurveyBasket.Presistance;

namespace SurveyBasket.Services;

public class PollService(ApplicationDbContext context) : IPollService
{
    private readonly ApplicationDbContext _context=context;

    public async Task<Poll> AddAsync(Poll poll, CancellationToken cancellationToken=default)
    {
         await _context.Polls.AddAsync(poll, cancellationToken);
         await _context.SaveChangesAsync(cancellationToken);
         return poll;
    }

    public async Task<IEnumerable<Poll>> GetAllAsync(CancellationToken cancellationToken = default) =>
     await _context.Polls.AsNoTracking().ToListAsync(cancellationToken);
    

    public async Task<Poll?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        await  _context.Polls.SingleOrDefaultAsync(pol => pol.Id == id, cancellationToken);

    public async Task<bool> UpdateAsync(Poll poll, CancellationToken cancellationToken = default)
    {
        var oldpoll=await  _context.Polls.FindAsync(poll.Id,cancellationToken);
        if (oldpoll is null) return false;
        oldpoll.Title = poll.Title;
        oldpoll.Summary = poll.Summary;
        oldpoll.StartsAt = poll.StartsAt;
        oldpoll.EndsAt = poll.EndsAt;
       await _context.SaveChangesAsync(cancellationToken);
        return true;

    }

    public  async Task<bool> TogglePublishAsync(int id, CancellationToken cancellationToken = default)
    {
        var oldpoll=await  _context.Polls.FindAsync(id,cancellationToken);
        if (oldpoll is null) return false;
        oldpoll.IsPublished = !oldpoll.IsPublished;
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }


    public async Task<bool> DeleteAsync(int  id, CancellationToken cancellationToken = default)
    {
        var poll=await _context.Polls.FindAsync(id,cancellationToken);
        if(poll is null) return false;  
        _context.Polls.Remove(poll);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
       
    }

}
