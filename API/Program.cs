using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Mapping.Config;
using BusinessLayer.Mapping.Resolvers;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<Context>(options =>
options.UseSqlServer(connectionString), ServiceLifetime.Scoped);

builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IUrunlerDal, UrunlerDal>();
builder.Services.AddScoped<IUrunService, UrunService>();

builder.Services.AddScoped<IDepoDal, DepoDal>();
builder.Services.AddScoped<IDepoService, DepoService>();

builder.Services.AddScoped<SehirIdResolver>();
builder.Services.AddScoped<IlceIdResolver>();

builder.Services.AddScoped<SehirAdResolver>();
builder.Services.AddScoped<IlceAdResolver>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowAll");
app.MapControllers();

app.Run("http://0.0.0.0:5000");
