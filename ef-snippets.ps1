dotnet ef migrations add InitialCreate --project WoodWorld.Infrastructure --startup-project WoodWorld.Api --output-dir Persistence/Migrations

dotnet ef migrations add AddRentalIndexes \
  --context WoodWorldContext \
  --project WoodWorld.Infrastructure \
  --startup-project WoodWorld.WebApi
