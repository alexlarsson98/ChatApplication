namespace ChatAppBackend.Data.Seeds;

internal static class DatabaseInitializerExtension
{
    public static IApplicationBuilder InitializeDatabase(this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app, nameof(app));

        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<ChatAppDbContext>();
            DatabaseInitializer.Initialize(context);
        }
        catch (Exception ex)
        {

        }

        return app;
    }
}
