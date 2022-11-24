using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new();
    public string Name { get; }
    public string Description { get; }
    public string AverageRating { get; }

    public IReadOnlyList<MenuItem> Sections => _sections.ToList();
}