using BuberDinner.Domain.Entities;

namespace BubberDinner.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token);