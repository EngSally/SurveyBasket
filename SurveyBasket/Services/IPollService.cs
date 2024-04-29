using SurveyBasket.Contracts.Responses;

namespace SurveyBasket.Services;

public interface IPollService
{
    Task<IEnumerable<Poll>> GetAllPollsAsync();
    Task<Poll?> GetByIdPollsAsync(int id);
    Task<Poll> AddPollAsync(Poll poll);



}
