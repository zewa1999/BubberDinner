using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Domain.Common.ValueObjects;

public sealed class Rating : ValueObject
{
    public float Value { get; }

    private Rating(float value)
    {
        Value = value;
    }

    public static Rating CreateNew(float value)
    {
        return new Rating(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}