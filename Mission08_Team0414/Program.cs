using Microsoft.EntityFrameworkCore;
using Mission08_Team0414.Models;   // adjust namespace if needed
using Mission08_Team0414.Data;     // you'll create this

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TasksContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TaskConnection")));
builder.Services.AddScoped<ITasksRepository, EFTasksRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
