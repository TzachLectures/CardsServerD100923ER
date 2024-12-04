﻿using CardsServerD100923ER.Application.Interfaces;
using CardsServerD100923ER.Application.Utils;
using CardsServerD100923ER.Core.Interfaces;
using CardsServerD100923ER.Core.Models;

namespace CardsServerD100923ER.Application.Services
{
    public class UserService :IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuth _authService;

        public UserService(IUserRepository userRepository,IAuth auth)
        {
            _userRepository = userRepository;
            _authService = auth;
        }

        public async Task<User?> Register(User user)
        {
           if (user == null) return null;
            user.Password = PasswordHelper.GenerateHashedPassword(user.Password,user);
            return await _userRepository.CreateUserAsync(user);
        }

        public async Task<string?> Login(LoginModel login)
        {
            User? u = await _userRepository.GetUserByEmailAsync(login.Email);
            
            if (u == null || !PasswordHelper.VerifyPassword(login.Password,u.Password,u))
            {
                return null;
            }

            return _authService.GenerateToken(u);
        }

    }
}
