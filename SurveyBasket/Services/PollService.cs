using SurveyBasket.Contracts.Responses;
using SurveyBasket.Presistance;

namespace SurveyBasket.Services;

public class PollService(ApplicationDbContext context) : IPollService
{
    private readonly ApplicationDbContext _context=context;

    public async Task<Poll> AddPollAsync(Poll poll)
    {
         await _context.Polls.AddAsync(poll);
        _context.SaveChanges();
         return poll;
    }

    public async Task<IEnumerable<Poll>> GetAllPollsAsync()=>
     await _context.Polls.AsNoTracking().ToListAsync();
    

    public async Task<Poll?> GetByIdPollsAsync(int id)=>
        await  _context.Polls.SingleOrDefaultAsync(pol => pol.Id == id);
    
}
