namespace SurveyBasket.Contracts.Polls;

public class PollRequestValidator : AbstractValidator<PollRequest>
{
    public PollRequestValidator()
    {
        RuleFor(p => p.Title).NotEmpty().Length(5, 100);
        RuleFor(p => p.Summary).NotEmpty().Length(7, 1500);
        RuleFor(p => p.StartsAt).GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today));
        RuleFor(p => p).Must(HasValiedEndDate)
            .WithMessage($"{nameof(PollRequest.EndsAt)} must be grater than or equal {nameof(PollRequest.StartsAt)}");
    }
    private bool HasValiedEndDate(PollRequest pollRequest)
    {
        return pollRequest.EndsAt >= pollRequest.StartsAt;
    }
}
