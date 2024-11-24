﻿using CardsServerD100923ER.Application.Interfaces;
using CardsServerD100923ER.Core.Interfaces;
using CardsServerD100923ER.Core.Models;

namespace CardsServerD100923ER.Application.Services
{
    public class UserService :IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> Register(User user)
        {
           if (user == null) return null;

           return await _userRepository.CreateUserAsync(user);
        }
    }
}