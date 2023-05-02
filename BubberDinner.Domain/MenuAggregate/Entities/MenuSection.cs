using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public MenuSection(MenuSectionId id, string name, string description, DateTime createdDateTime, DateTime updatedDateTime)
        : base(id)
    {
        Name = name;
        Description = description;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
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

#pragma warning disable CS8618
    private MenuSection()
    {

    }
#pragma warning restore CS8618
}