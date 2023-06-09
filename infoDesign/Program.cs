using infoDesign.AccesoDatos.Data;
using infoDesign.AccesoDatos.Data.Repository.IRepository;
using infoDesign.AccesoDatos.Data.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*" )
                                                    .AllowAnyHeader()
                                                    .AllowAnyMethod();
                      });
});




// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("InfodesignConnection") ?? throw new InvalidOperationException("Cadena de conexion 'ConexionSql' no encontrada.");
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IContenedorTrabajo, ContenedorTrabajo>();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
