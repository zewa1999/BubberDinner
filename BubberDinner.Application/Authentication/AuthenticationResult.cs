using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Authentication;

public record AuthenticationResult(
    User User,
    string Token);