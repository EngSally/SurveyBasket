namespace SurveyBasket.Contracts.Requests;

public record PollRequest(
    int Id,
    string Title,
    string Summary,
    bool IsPublished,
    DateOnly StartsAt,
    DateOnly EndsAt
);