using CardsServerD100923ER.Core.Interfaces;
using CardsServerD100923ER.Core.Models;
using CardsServerD100923ER.Infrastructure.Data;

namespace CardsServerD100923ER.Infrastructure.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly CardsProjectDbContext _context;
        public UserRepository(CardsProjectDbContext context)
        {
            _context = context;
        }

        public async Task<User?> CreateUserAsync(User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
