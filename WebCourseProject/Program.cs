using Microsoft.EntityFrameworkCore;
using SoapCore;
using WebCourseProject.Data;
using WebCourseProject.Soap;

var builder = WebApplication.CreateBuilder(args);

// DB (InMemory – для мінімально робочого варіанту)
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("ProductsDB"));

// Controllers
builder.Services.AddControllers();

// SOAP
builder.Services.AddSoapCore();
builder.Services.AddScoped<ISoapService, SoapService>();

var app = builder.Build();

app.MapControllers();

// SOAP endpoint
app.UseSoapEndpoint<ISoapService>("/soap", new SoapEncoderOptions());

app.Run();

