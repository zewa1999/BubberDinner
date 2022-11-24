using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.Entities;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Dinner;

public sealed class Dinner : AggregateRoot<DinnerId>
{
    private List<Reservation> _reservation = new();

    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime? StartedDateTime { get; }
    public DateTime? EndedDateTime { get; }
    public DinnerStatus DinnerStatus { get; }
    public bool IsPublic { get; }
    public int MaxGuests { get; }
    public Price Price { get; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public Uri ImageUrl { get; }
    public Location Location { get; }

    public IReadOnlyList<Reservation> Reservations => _reservation.AsReadOnly();

    public Dinner(DinnerId id,
        string name, string description, DateTime startDateTime, DateTime endDateTime, DateTime startedDateTime, DateTime endedDateTime,
        DinnerStatus dinnerStatus, bool isPublic, int maxGuests, Price price, HostId hostId, MenuId menuId, Uri imageUrl, Location location,
        DateTime createdDateTime, DateTime updatedDateTime)
        : base(id, createdDateTime, updatedDateTime)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        StartedDateTime = startedDateTime;
        EndedDateTime = endedDateTime;
        DinnerStatus = dinnerStatus;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        HostId = hostId;
        MenuId = menuId;
        ImageUrl = imageUrl;
        Location = location;
    }

    public Dinner Create(
       string name, string description, DateTime startDateTime, DateTime endDateTime, DateTime startedDateTime, DateTime endedDateTime,
       DinnerStatus dinnerStatus, bool isPublic, int maxGuests, Price price, HostId hostId, MenuId menuId, Uri imageUrl, Location location)
    {
        return new(DinnerId.CreateUnique(), name, description, startDateTime, endDateTime, startedDateTime, endedDateTime,
        dinnerStatus, isPublic, maxGuests, price, hostId, menuId, imageUrl, location, DateTime.UtcNow, DateTime.UtcNow);
    }
}