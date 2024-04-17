using main.domain;

namespace main.repository;

public interface IUserRepository : IRepository<long, User>
{
    User? FindByUsernameAndPassword(string username, string password);
}