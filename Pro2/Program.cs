using Microsoft.EntityFrameworkCore;
using Pro2.Data;
using Pro2.Repositories;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IPetRepository, PetRepository>(); //מוסיף סרוויס סקופ זה עם רענון לפי סקופ
builder.Services.AddDbContext<PetContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllersWithViews();


var app = builder.Build();

if (app.Environment.IsStaging() || app.Environment.IsProduction()) {
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

using (var scope = app.Services.CreateScope()) {
    var ctx = scope.ServiceProvider.GetRequiredService<PetContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}

app.UseRouting();
app.MapDefaultControllerRoute();

app.Run();