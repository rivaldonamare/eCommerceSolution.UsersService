namespace eCommerce.Infrastructure.DbContext;

public class DapperDbContext
{
    private readonly IConfiguration _configuration;
    private readonly IDbConnection _connection;
    public DapperDbContext(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        string? connectionString = _configuration.GetConnectionString("PostgresConnection");

        _connection = new NpgsqlConnection(connectionString);
    }

    public IDbConnection Connection => _connection;
}
