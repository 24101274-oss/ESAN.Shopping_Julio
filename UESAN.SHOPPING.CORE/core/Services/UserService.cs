using System;
using System.Collections.Generic;
using System.Text;
using UESAN.SHOPPING.CORE.core.DTOs;
using UESAN.SHOPPING.CORE.core.Entities;
using UESAN.SHOPPING.CORE.core.Interfaces;
using UESAN.SHOPPING.CORE.Core.Services;


namespace UESAN.SHOPPING.CORE.core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserDTO> SignIn(string email, string password)
        {
            var user = await _userRepository.SignIn(email, password);
            var token = ""; //aqui deberias generar un token jwt o similar para autenticar al usuario en futuras solicitudes
            if (user == null) return null;
            return new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = "token" // Aquí deberías generar un token real
            };
        }
        public async Task<int> Signup(UserCreateDTO userCreateDTO)
        {
            var user = new User
            {
                FirstName = userCreateDTO.FirstName,
                LastName = userCreateDTO.LastName,
                DateOfBirth = userCreateDTO.DateOfBirth,
                Email = userCreateDTO.Email,
                Password = userCreateDTO.Password, // En un entorno real, deberías hashear la contraseña antes de almacenarla
                Country = userCreateDTO.Country,
                Address = userCreateDTO.Address,
                Type = userCreateDTO.Type,
                IsActive = true // Por defecto, el usuario se crea como activo
            };
            return await _userRepository.Sigup(user);
        }
    }
}