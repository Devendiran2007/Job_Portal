var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Map("/", () => {
    return "Checking Endpoint";
});

app.Run();