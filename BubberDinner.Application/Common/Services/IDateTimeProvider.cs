namespace BuberDinner.Application.Common.Services;

public interface IDateTimeProvider
{
    public DateTime UtcNow { get; }
}