using Microsoft.EntityFrameworkCore;
using oceanica_app.Data;
using oceanica_app.Models;
using oceanica_app.Repository;
using oceanica_app.Repository.Abstract;

var builder = WebApplication.CreateBuilder(args);

//ConnectionString
var connectionString = builder.Configuration.GetConnectionString("OceanicaConnection");

// Add services to the container.
builder.Services.AddScoped<IRepository<Vessel>, VesselRepository>();
builder.Services.AddScoped<IRepository<Departament>, DepartamentRepository>();
builder.Services.AddScoped<IRepository<CrewMember>, CrewMemberRepository>();

//AddAutomapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Add Context
builder.Services.AddDbContext<OceanicaContext>(opt =>
opt.UseLazyLoadingProxies().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Enable CORS
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", opt => opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
