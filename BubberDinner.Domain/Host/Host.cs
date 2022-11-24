using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Host;

public sealed class Host : AggregateRoot<HostId>
{
    public string FirstName { get; }
    public string LastName { get; }
    public Uri ProfileImage { get; }
    private readonly List<MenuId> _menuIds = new();
    private readonly List<DinnerId> _dinnerIds = new();
    public AverageRating averageRating { get; }
    public UserId UserId { get; set; }

    public IReadOnlyList<MenuId> Menus => _menuIds.AsReadOnly();
    public IReadOnlyList<DinnerId> Dinners => _dinnerIds.AsReadOnly();

    public Host(HostId id, string firstName, string lastName, Uri profileImage, AverageRating averageRating, UserId userId,
        DateTime createdDateTime, DateTime updatedDateTime)
        : base(id, createdDateTime, updatedDateTime)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        this.averageRating = averageRating;
        UserId = userId;
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