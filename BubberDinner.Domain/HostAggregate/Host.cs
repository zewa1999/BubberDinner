using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Domain.HostAggregate;

public sealed class Host : AggregateRoot<HostId>
{
    public string FirstName { get; }
    public string LastName { get; }
    public Uri ProfileImage { get; }
    private readonly List<MenuId> _menuIds = new();
    private readonly List<DinnerId> _dinnerIds = new();
    public AverageRating averageRating { get; }
    public UserId UserId { get; set; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public IReadOnlyList<MenuId> Menus => _menuIds.AsReadOnly();
    public IReadOnlyList<DinnerId> Dinners => _dinnerIds.AsReadOnly();

    public Host(HostId id, string firstName, string lastName, Uri profileImage, AverageRating averageRating, UserId userId,
        DateTime createdDateTime, DateTime updatedDateTime)
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        this.averageRating = averageRating;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Host Create(
        string firstName,
        string lastName,
        Uri profileImage,
        AverageRating averageRating,
        UserId userId
        )
    {
        return new(
            HostId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            averageRating,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}