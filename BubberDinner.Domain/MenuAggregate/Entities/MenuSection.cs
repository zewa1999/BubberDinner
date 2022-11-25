using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    public MenuSection(MenuSectionId id, string name, string description, DateTime createdDateTime, DateTime updatedDateTime)
        : base(id, createdDateTime, updatedDateTime)
    {
        Name = name;
        Description = description;
    }

    private readonly List<MenuItem> _items = new();
    public string Name { get; }
    public string Description { get; }

    public IReadOnlyList<MenuItem> Items => _items.ToList();

    public static MenuSection Create(string name, string description)
    {
        return new MenuSection(
            MenuSectionId.CreateUnique()
            , name,
            description,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}