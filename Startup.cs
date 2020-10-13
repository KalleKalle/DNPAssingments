using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DNP_Assignment_1.Data;
using Microsoft.AspNetCore.Components.Authorization;


namespace DNP_Assignment_1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
           // services.AddSingleton<ITodoService, TodoService>();
            services.AddSingleton<IAdultService, AdultService>();
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticatorStateProvider>();
           // services.AddScoped<IUserService,UserService>();
           services.AddScoped<IUserService, UserService>();

           services.AddAuthorization(options =>
           {
               options.AddPolicy("MustBeAdmin", a => a.RequireAuthenticatedUser().RequireClaim("Role", "Admin"));
               options.AddPolicy("MustBeLoggedIn", a => a.RequireAuthenticatedUser().RequireClaim("SecurityLevel", "2", "3")); 
           });
        }
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}