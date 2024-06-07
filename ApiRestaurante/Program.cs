using AccesoDatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllersWithViews(); //fue este

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "WebApiCrud",
            Version = "v1"
        });
    //var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}";
    //var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
    //options.IncludeXmlComments(filePath);

});



builder.Services.AddDbContext<RestauranteDbContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseAuthorization();
app.UseRouting();
app.UseCors(
       options => options
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()

       

  );


app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
app.Run();
