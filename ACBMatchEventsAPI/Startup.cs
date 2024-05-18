using MatchEvents.Domain.Configuration;

public class Startup
{
    private IConfigurationRoot _configuration;
    public Startup(IHostingEnvironment env)
    {
        _configuration = new ConfigurationBuilder()
    }
    public void ConfigureServices(IServiceCollection services)
    {
        //Here I setup to read appsettings
        services.Configure<ConfigurationSettings>(_configuration.GetSection("AppSettings"));
    }
}