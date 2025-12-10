namespace eCommerce.Infrastructure.DbContext;

public class DapperDbContext
{
    private readonly IConfiguration _configuration;
    private readonly IDbConnection _connection;
    public DapperDbContext(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        string connectionStringTemplate = _configuration.GetConnectionString("PostgresConnection")!;

        string connectionString = connectionStringTemplate
            .Replace("$POSTGRES_HOST", Environment.GetEnvironmentVariable("POSTGRES_HOST") ?? "localhost")
            .Replace("$POSTGRES_PASSWORD", Environment.GetEnvironmentVariable("POSTGRES_PASSWORD") ?? "postgres")
            .Replace("$POSTGRES_PORT", Environment.GetEnvironmentVariable("POSTGRES_PORT") ?? "5432")
            .Replace("$POSTGRES_DATABASE", Environment.GetEnvironmentVariable("POSTGRES_DATABASE") ?? "eCommerceUsers")
            .Replace("$POSTGRES_USER", Environment.GetEnvironmentVariable("POSTGRES_USER") ?? "postgres");

        _connection = new NpgsqlConnection(connectionString);
    }

    public IDbConnection Connection => _connection;
}
