Add the secrets:
dotnet user-secrets init --project .\BuberDinner.Api\
dotnet user-secrets set --project .\BuberDinner.Api\ "JwtSettings:Secret" "super-secret-key-from-user-secrets-that-you-cannot-find"
View your secrets:
dotnet user-secrets list --project .\BuberDinner.Api\