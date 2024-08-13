using TBA.Repositories.Internal;
using TBA.Repositories;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        // Register IEmployeeRepository and its implementation
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
