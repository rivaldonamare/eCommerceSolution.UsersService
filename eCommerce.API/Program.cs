var builder = WebApplication.CreateBuilder(args);

// Add Infrastructure Services
builder.Services.AddInfrastructure();
builder.Services.AddCore();

// Add Controller to the services collection
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));


builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);

// fluent validation
builder.Services.AddFluentValidationAutoValidation();

// Build the application
var app = builder.Build();

app.UseExceptionHandlingMiddleware();

// Routing
app.UseRouting();

// Auth
app.UseAuthentication();
app.UseAuthorization();

// Controller Routes
app.MapControllers();

// Run
app.Run();
