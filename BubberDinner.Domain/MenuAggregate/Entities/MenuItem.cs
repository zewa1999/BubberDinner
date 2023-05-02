using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    public string Name { get; }
    public string Description { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private MenuItem(MenuItemId id, string name, string description,
        DateTime createdDateTime, DateTime updatedDateTime) : base(id)
    {
        Name = name;
        Description = description;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static MenuItem Create(
        string name,
        string description)
    {
        return new MenuItem(
            MenuItemId.CreateUnique(),
            name,
            description,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

#pragma warning disable CS8618
    private MenuItem()
    {

    }
#pragma warning restore CS8618
}