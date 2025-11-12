namespace eCommerce.Infrastructure.DbContext;

public class DapperDbContext
{
    private readonly IConfiguration _configuration;
    private readonly IDbConnection _connection;
    public DapperDbContext(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        string connectionStringTemplate = _configuration.GetConnectionString("PostgresConnection")!;

        string connectionString = connectionStringTemplate.Replace("$POSTGRES_HOST", Environment.GetEnvironmentVariable("POSTGRES_HOST") ?? "localhost")
            .Replace("$POSTGRES_PASSWORD", Environment.GetEnvironmentVariable("POSTGRES_PASSWORD") ?? "postgres");

        _connection = new NpgsqlConnection(connectionString);
    }

    public IDbConnection Connection => _connection;
}
