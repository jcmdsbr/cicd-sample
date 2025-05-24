using Ifsp.Api.Clients;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddHttpClient<IOpenAiService, OpenAiService>("Ifsp.Api", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["OpenAi:BaseUrl"]!);
    c.DefaultRequestHeaders.Add("Authorization", $"Bearer {builder.Configuration["OpenAi:ApiKey"]}");
});

var app = builder.Build();

if (app.Environment.IsDevelopment()) app.MapOpenApi();

app.MapGet("/v1/whats-meaning-name/{name}", async (string name, IOpenAiService service) =>
    {
        var request = new ChatRequest(name);
        var response = await service.HandleAsync(request);
        return Results.Ok(response);
    })
    .WithName("Name")
    .WithOpenApi();

await app.RunAsync();