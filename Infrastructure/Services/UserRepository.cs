using CardsServerD100923ER.Core.Interfaces;
using CardsServerD100923ER.Core.Models;
using CardsServerD100923ER.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            try
            {
                return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
