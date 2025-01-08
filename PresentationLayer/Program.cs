
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUrunlerRepository, UrunlerRepository>();
builder.Services.AddScoped<IUrunlerService, UrunlerService>();

builder.Services.AddScoped<IMusterilerRepository, MusterilerRepository>();
builder.Services.AddScoped<IMusterilerService, MusterilerService>();

builder.Services.AddScoped<IToptancilarRepository, ToptancilarRepository>();
builder.Services.AddScoped<IToptancilarService, ToptancilarService>();

builder.Services.AddScoped<IIslemlerRepository, IslemlerRepository>();
builder.Services.AddScoped<IIslemlerService, IslemlerService>();

var app = builder.Build();

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
    pattern: "{controller=Urunler}/{action=Index}/{id?}");

app.Run();
