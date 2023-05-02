using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.HostAggregate.ValueObjects;

public sealed class HostId : ValueObject
{
    public Guid Value { get; }

    private HostId(Guid value)
    {
        Value = value;
    }

    public static HostId CreateUnique()
    {
        return new HostId(Guid.NewGuid());
    }

    public static HostId Create(Guid value)
    {
        return new HostId(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}