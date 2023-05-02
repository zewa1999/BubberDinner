using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;

namespace BuberDinner.Domain.GuestAggregate.Entities;

public sealed class Rating : Entity<RatingId>
{
    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public int RatingValue { get; set; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public Rating(RatingId id, HostId hostId, DinnerId dinnerId, int ratingValue, DateTime createdDateTime, DateTime updatedDateTime)
        : base(id)
    {
        HostId = hostId;
        DinnerId = dinnerId;
        RatingValue = ratingValue;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Rating Create(
        HostId hostId,
        DinnerId dinnerId,
        int ratingValue)
    {
        return new Rating(
            RatingId.CreateUnique(),
            hostId,
            dinnerId,
            ratingValue,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}