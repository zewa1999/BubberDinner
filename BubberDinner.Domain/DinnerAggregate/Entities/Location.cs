using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregate.Entities;

public sealed class Location : Entity<LocationId>
{
    public string Name { get; }
    public string Address { get; }
    public double Latitude { get; }
    public double Longitude { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public Location(LocationId id, string name, string address, double latitude, double longitude, DateTime createdDateTime, DateTime updatedDateTime)
        : base(id)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Location Create(
        string name,
        string address,
        double latitude,
        double longitude)
    {
        return new(
            LocationId.CreateUnique(),
            name,
            address,
            latitude,
            longitude,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}