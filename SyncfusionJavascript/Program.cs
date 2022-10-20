using Microsoft.EntityFrameworkCore;
using SyncfusionJavascript.Context;
using SyncfusionJavascript.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(op =>
{
    op.ModelBinderProviders.Insert(0, new CustomModelBinderProvider());
});

builder.Services.
    AddDbContext<SyncfusionDbContext>(
    optionsBuilder => optionsBuilder.UseSqlite("Data Source=Db.SqlLite"));


var app = builder.Build();

app.UseStaticFiles();
app.UseDeveloperExceptionPage();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
