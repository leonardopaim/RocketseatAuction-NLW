using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories.DataAccess;

public class UserRepository : IUserRepository
{
    private readonly RocketseatAuctionDbContext _dbContext;

    public UserRepository(RocketseatAuctionDbContext dbContext) => _dbContext = dbContext;

    public bool ExistUserWithEmail(string email) => _dbContext.Users.Any(x => x.Email.Equals(email));

    public User GetUserByEmail(string email) => _dbContext.Users.First(x => x.Email.Equals(email));
}
