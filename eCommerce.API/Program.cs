var builder = WebApplication.CreateBuilder(args);

// Add Infrastructure Services
builder.Services.AddInfrastructure();
builder.Services.AddCore();

// Add Controller to the services collection
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));


builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);

// fluent validation
builder.Services.AddFluentValidationAutoValidation();

// Add Swagger to the services collection
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS to the services collection
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin() // to allow any domain to hit API
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Build the application
var app = builder.Build();

app.UseExceptionHandlingMiddleware();

// Routing
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();

// Auth
app.UseAuthentication();
app.UseAuthorization();

// Controller Routes
app.MapControllers();

// Run
app.Run();
