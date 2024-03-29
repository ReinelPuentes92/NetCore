

using _NetCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region DbContext

//Connection String
string connString = builder.Configuration
                            .GetConnectionString("DefaultConnection");

/*builder.Services.AddDbContext<EscuelaContext>(
    options => options.UseInMemoryDatabase(databaseName: "testDB")
);*/

builder.Services.AddDbContext<EscuelaContext>(options => {
    options.UseSqlServer(connString);
});
#endregion

var app = builder.Build();

using(var scope = app.Services.CreateScope()){
    var serv = scope.ServiceProvider;
    try{
        var context = serv.GetRequiredService<EscuelaContext>();
        context.Database.EnsureCreated();
    } catch (Exception){
        throw;
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Escuela}/{action=Index}/{id?}");

app.Run();
