using CardsServerD100923ER.Core.Models;

namespace CardsServerD100923ER.Application.Interfaces
{
    public interface IUserService
    {
        Task<User?> Register(User user);
        //Task<List<User>> GetAll();
        //Task<User?> GetOne(string id);
        //Task<User?> Update(string id, User user);
        //Task<User?> Delete(string id);
    }
}
