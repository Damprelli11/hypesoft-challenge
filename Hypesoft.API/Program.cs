using MediatR;
using Hypesoft.Application;
using FluentValidation;
using Hypesoft.Application.Behaviors;
using Hypesoft.API.Middlewares;
using Hypesoft.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add controllers to the services
builder.Services.AddControllers();

// Configure CORS policy to allow requests from the frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Add Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register infrastructure services (MongoDB and repositories)
builder.Services.AddInfrastructure(builder.Configuration);

// Register MediatR for command/query handling
builder.Services.AddMediatR(typeof(AssemblyReference).Assembly);

// Register FluentValidation validators
builder.Services.AddValidatorsFromAssembly(typeof(AssemblyReference).Assembly);

// Add validation pipeline behavior
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

var app = builder.Build();

// Use the CORS policy
app.UseCors("AllowFrontend");

// Enable Swagger UI only in development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use custom exception middleware
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();

app.Run();
