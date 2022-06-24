namespace WebinarApi;

public static class RegisterEndPoints
{
    public static WebApplication RegisterEndpoints(this WebApplication app)
    {
        app.MapGet("/", () => "ok");
        return app;
    }
}