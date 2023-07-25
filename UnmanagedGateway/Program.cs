var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("Fusion");

builder.Services
    .AddFusionGatewayServer()
    .ConfigureFromFile("./gateway.fgp");

var app = builder.Build();

app.MapGraphQL();

app.UseGraphQLGraphiQL();

app.RunWithGraphQLCommands(args);
