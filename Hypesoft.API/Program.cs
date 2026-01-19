using MediatR;
using Hypesoft.Application;
using FluentValidation;
using Hypesoft.Application.Behaviors;
using Hypesoft.API.Middlewares;
using Hypesoft.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Infrastructure (Mongo + Repositories)
builder.Services.AddInfrastructure(builder.Configuration);

// MediatR
builder.Services.AddMediatR(typeof(AssemblyReference).Assembly);

// Validators
builder.Services.AddValidatorsFromAssembly(typeof(AssemblyReference).Assembly);

// Pipeline behavior
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

var app = builder.Build();

// Swagger só no ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();

app.Run();
