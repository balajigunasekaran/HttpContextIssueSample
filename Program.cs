var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();

var app = builder.Build();
app.MapGet("/test", async context =>
{
    Task[] tasks =
    [
        DoWork(context),
        DoWork(context),
    ];
    await Task.WhenAll(tasks);
    
    static Task DoWork(HttpContext context)
    {
        return Task.Run(async () =>
        {
            await Task.Delay(100);
            //try { context!.User.ToString(); } catch { }
            context!.User.ToString();
        });
    }
});
app.Run();
