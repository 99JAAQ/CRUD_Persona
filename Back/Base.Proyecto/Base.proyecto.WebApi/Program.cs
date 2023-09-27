
using Base.Proyecto.Common.Interfaces;
using Base.Proyecto.Common.Utils;
using Base.Proyecto.Infraestructure;
using Base.Proyecto.Infraestructure.Interfaces;
using Base.Proyecto.Service;
using Base.Proyecto.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataBaseContext>(opt => opt.UseSqlServer(
      builder.Configuration.GetConnectionString("ConnectionStringSQLServer"), sqlServerOptionsAction: sqlOptions =>
      {
          sqlOptions.EnableRetryOnFailure();
      }), ServiceLifetime.Transient);

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IUtility, Base.Proyecto.Common.Utils.Utility>();
builder.Services.AddScoped<UnitOfWork, UnitOfWork>();
builder.Services.AddScoped<DataBaseContext, DataBaseContext>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IPersonService, PersonService>();

builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddCors(options =>
{
    options.AddPolicy("newPolicy", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
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

app.MapControllers();

app.UseCors("newPolicy");
app.Run();
