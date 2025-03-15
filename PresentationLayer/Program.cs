
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Mapping;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;

var builder = WebApplication.CreateBuilder(args);

ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<Context>(options =>
options.UseSqlServer(connectionString), ServiceLifetime.Scoped);

builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();

builder.Services.AddSingleton<VisitorCounterService>();

builder.Services.AddSession();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IMarkaDal, MarkaDal>();
builder.Services.AddScoped<IMarkaService, MarkaService>();

builder.Services.AddScoped<IBirimDal, BirimDal>();
builder.Services.AddScoped<IBirimService, BirimService>();

builder.Services.AddScoped<IUrunlerDal, UrunlerDal>();
builder.Services.AddScoped<IUrunService, UrunService>();

builder.Services.AddScoped<IDepoDal, DepoDal>();
builder.Services.AddScoped<IDepoService, DepoService>();

builder.Services.AddScoped<IUrunlerRepository, UrunlerRepository>();
builder.Services.AddScoped<IUrunlerService, UrunlerService>();

builder.Services.AddScoped<IMusterilerRepository, MusterilerRepository>();
builder.Services.AddScoped<IMusterilerService, MusterilerService>();

builder.Services.AddScoped<IToptancilarRepository, ToptancilarRepository>();
builder.Services.AddScoped<IToptancilarService, ToptancilarService>();

builder.Services.AddScoped<IIslemlerRepository, IslemlerRepository>();
builder.Services.AddScoped<IIslemlerService, IslemlerService>();

builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartService, CartService>();

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
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
