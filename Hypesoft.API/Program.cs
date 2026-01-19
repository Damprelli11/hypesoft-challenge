using Hypesoft.Infrastructure.Configurations;
using MediatR;
using Hypesoft.Application;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Infrastructure (Mongo + Repositories)
builder.Services.AddInfrastructure(builder.Configuration);

//AssemblyReference
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(Hypesoft.Application.AssemblyReference).Assembly)
);

var app = builder.Build();

// Swagger só no ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
