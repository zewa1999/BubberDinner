using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    public string Name { get; }
    public string Description { get; }

    private MenuItem(MenuItemId id, string name, string description,
        DateTime createdDateTime, DateTime updatedDateTime) : base(id, createdDateTime, updatedDateTime)
    {
        Name = name;
        Description = description;
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
}