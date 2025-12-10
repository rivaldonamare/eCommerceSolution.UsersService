namespace eCommerce.Infrastructure.Repository;

public class ApplicationUserRepository : IApplicationUserRepository
{
    private readonly DapperDbContext _dapperDbContext;

    public ApplicationUserRepository(DapperDbContext dapperDbContext)
    {
        _dapperDbContext = dapperDbContext ?? throw new ArgumentNullException(nameof(dapperDbContext));
    }
    public async Task<ApplicationUser> AddUser(ApplicationUser user)
    {
        user.UserId = Guid.NewGuid();

        string query = "INSERT INTO public. \"ApplicationUsers\" (\"UserId\", \"Email\", \"Password\", \"Name\", \"Gender\") VALUES (@UserId, @Email, @Password, @Name, @Gender) RETURNING \"UserId\";";

        var rowCountAffected = await _dapperDbContext.Connection.ExecuteAsync(query, user);

        if (rowCountAffected != 1)
        {
            throw new Exception("Failed to add user");
        }

        return user;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string email, string password)
    {
        string query = "SELECT * FROM public. \"ApplicationUsers\" WHERE \"Email\" = @Email AND \"Password\" = @Password";

        var user = await _dapperDbContext.Connection.QueryFirstOrDefaultAsync<ApplicationUser>(query, new { Email = email, Password = password });

        if (user == null)
        {
            throw new InvalidOperationException("User not found");
        }
        
        return user;
    }

    public async Task<ApplicationUser?> GetUserByUserId(Guid userId)
    {
        string query = "SELECT * FROM public. \"ApplicationUsers\" WHERE \"UserId\" = @UserId";

        var user = await _dapperDbContext.Connection.QueryFirstOrDefaultAsync<ApplicationUser>(query, new { UserId = userId });

        return user;
    }
}
