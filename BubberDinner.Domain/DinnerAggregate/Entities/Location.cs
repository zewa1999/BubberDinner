using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregate.Entities;

public sealed class Location : Entity<LocationId>
{
    public string Name { get; }
    public string Address { get; }
    public double Latitude { get; }
    public double Longitude { get; }

    public Location(LocationId id, string name, string address, double latitude, double longitude, DateTime createdDateTime, DateTime updatedDateTime)
        : base(id, createdDateTime, updatedDateTime)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
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