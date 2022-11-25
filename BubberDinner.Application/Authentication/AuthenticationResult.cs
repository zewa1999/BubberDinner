using BuberDinner.Domain.UserAggregate;

namespace BuberDinner.Application.Authentication;

public record AuthenticationResult(
    User User,
    string Token);