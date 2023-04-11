namespace Hangfire.API.Extensions;

public static class ServiceExtensions
{
    /// <summary>
    /// Extension method for configure Hangfire dashboard. Just for example the credentials for Login are stored in appsettings.json file.
    /// But it is not practice to store the credentials there. Good places to store Hangfire credentials are:
    /// Environment variables, Secret Manager tool in VS, Key Vault in Azure or other cloud-based key management services to store and manage Hangire dashboard credentials.
    /// </summary>
    /// <param name="app"></param>
    /// <param name="webApplicationBuilder"></param>
    /// <param name="configuration"></param>
    public static void ConfigureHangfireDashboard(this IApplicationBuilder app,
        WebApplicationBuilder webApplicationBuilder, IConfiguration configuration)
    {
        app.UseHangfireDashboard("/hangfire", new DashboardOptions()
        {
            DashboardTitle = "Hangfire Dashboard",

            Authorization = new[]{
                new HangfireCustomBasicAuthenticationFilter{
                    User = configuration.GetSection("HangfireCredentials:UserName").Value,
                    Pass = configuration.GetSection("HangfireCredentials:Password").Value
                }
            }
        });
    }
}