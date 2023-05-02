using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.Entities;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    public HostId HostId { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public AverageRating AverageRating { get; private set; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

#pragma warning disable CS8618
    private Menu()
    {

    }
#pragma warning restore CS8618

    public Menu(MenuId menuId, string name, string description, AverageRating averageRating, DateTime createdDateTime, DateTime updatedDateTime, HostId hostId)
        : base(menuId)
    {
        HostId = hostId;
        Name = name;
        Description = description;
        AverageRating = averageRating;
        CreatedDateTime = createdDateTime; 
        UpdatedDateTime = updatedDateTime;
    }

    public static Menu Create(
        string name,
        string description,
        AverageRating averageRating,
        HostId hostId)
    {
        return new(
            MenuId.CreateUnique(),
            name,
            description,
            averageRating,
            DateTime.UtcNow,
            DateTime.UtcNow,
            hostId);
    }
}