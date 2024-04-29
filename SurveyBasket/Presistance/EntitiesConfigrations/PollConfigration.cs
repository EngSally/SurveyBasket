using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyBasket.Entities;

namespace SurveyBasket.Presistance.EntitiesConfigrations;

public class PollConfigration : IEntityTypeConfiguration<Poll>
{
    public void Configure(EntityTypeBuilder<Poll> builder)
    {
        builder.HasIndex(e => e.Title);
        builder.Property(e => e.Title).HasMaxLength(100);
        builder.Property(e => e.Summary).HasMaxLength(1500);

    }
}

