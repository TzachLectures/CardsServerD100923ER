using CardsServerD100923ER.Core.Models;

namespace CardsServerD100923ER.Application.Interfaces
{
    public interface IAuth
    {
        public string GenerateToken(User u);
    }
}
