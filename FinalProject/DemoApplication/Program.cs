using AutoMapper;
using DemoApplication.Data;
using DemoApplication.Interfaces;
using DemoApplication.MapperProfile;
using DemoApplication.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    connectionString));


builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeSalaryRepository, EmployeeSalaryRepository>();
var mapperConfig = new MapperConfiguration(mc => {
    mc.AddProfile(new AutoMapperProfiles());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();
var loggerFactory = app.Services.GetService<ILoggerFactory>();
loggerFactory.AddFile(builder.Configuration["Logging:LogFilePath"].ToString());

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();

    // Add a custom route for redirecting to your custom page
    endpoints.MapGet("/", context =>
    {
        context.Response.Redirect("/Employee"); // Change to the actual path of your custom page
        return Task.CompletedTask;
    });
});

app.Run();
