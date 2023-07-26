using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContextPool<NotificationsContext>(
        o => o.UseSqlite("Data Source=notifications.db"));

builder.Services
    .AddOpenTelemetry()
    .ConfigureResource(b => b.AddService("Notifications-Subgraph", "Demo", Env.Version))
    .WithTracing(
        b =>
        {
            b.AddHttpClientInstrumentation();
            b.AddAspNetCoreInstrumentation();
            b.AddHotChocolateInstrumentation();
            b.AddOtlpExporter();
        })
    .WithMetrics(
        b =>
        {
            b.AddHttpClientInstrumentation();
            b.AddAspNetCoreInstrumentation();
            b.AddOtlpExporter();
        });

builder.Services
    .AddGraphQLServer()
    .AddTypes()
    .AddGlobalObjectIdentification()
    .RegisterDbContext<NotificationsContext>()
    .AddInstrumentation(o => o.RenameRootActivity = true);

var app = builder.Build();

await DatabaseHelper.SeedDatabaseAsync(app);

app.MapGraphQL();

app.UseGraphQLGraphiQL();

app.RunWithGraphQLCommands(args);