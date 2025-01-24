using Microsoft.Extensions.Options;
using MVCKisiselWebsite.DAL;
using MVCKisiselWebsite.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews(option =>
{
    option.Filters.Add(new LogFilter());
});

//session ekledik
builder.Services.AddSession(o => {
    o.IdleTimeout = TimeSpan.FromMinutes(20);
    o.Cookie.IsEssential = true;
}
);

builder.Services.AddScoped<LogFilter>();
builder.Services.AddScoped<LoginFilter>();
builder.Services.AddScoped<KisiselwebsiteContext>();
//builder.Services.AddSingleton<KisiselwebsiteContext>(); //edit iþleminde sýkýntý oluyor 

//sesion ý ekle
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
