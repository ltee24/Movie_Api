using Microsoft.EntityFrameworkCore;
using Movie_API;
using Movie_API.Data;
using Movie_API.Models;
using Movie_API.Repository;
using Movie_API.Repository.IRepository;
using Movie_API.Services;
using Movie_API.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MovieDbContext>(option => { option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection")); });
builder.Services.AddScoped<IRepository<MovieDetail>,Repository<MovieDetail>>();
builder.Services.AddHttpClient<IMovieService,MovieService>();
builder.Services.AddScoped<IMovieService,MovieService>();
builder.Services.AddAutoMapper(typeof(MappingConfiguration));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
