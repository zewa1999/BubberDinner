﻿using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    public MenuSection(MenuSectionId id, string name, string description) : base(id)
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
        return new MenuSection(MenuSectionId.CreateUnique(), name, description);
    }
}