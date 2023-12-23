using FacturasAPI;
using FacturasAPI.Services.FacturaService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// CORS
var misReglasCors = "ReglasCors";
builder.Services.AddCors(options =>
{
	options.AddPolicy(name: misReglasCors,
					  builder =>
					  {
						  builder.AllowAnyOrigin()
						  .AllowAnyHeader()
						  .AllowAnyMethod();


					  });
});

// conexión a la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("FacturasApiMySQL");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
);

// registro servicios
builder.Services.AddScoped<IFacturaService, FacturaService>();

// Add services to the container.

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

app.UseCors(misReglasCors); // CORS - se agrega configuración predeterminada

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
