using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.IServices;
using DataAccessLayer.IRepository;
using Domain.Models;

namespace BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Constructor for dependency injection
        /// </summary>
        /// <param name="userRepository">The user repository</param>
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Users? CreateUser(Users user, out string message)
        {
            if (string.IsNullOrWhiteSpace(user.Username))
            {
                message = "Username cannot be empty.";
                return null;
            }

            if (string.IsNullOrWhiteSpace(user.Email))
            {
                message = "Email cannot be empty.";
                return null;
            }

            // Check if a user with the same username or email already exists
            var existingUser = _userRepository.GetUserByEmail(user.Email);
            if (existingUser != null)
            {
                message = "A user with this username or email already exists.";
                return null;
            }

            // Create the user
            var createdUser = _userRepository.CreateUser(user);
            message = "User created successfully.";
            return createdUser;
        }

        public bool DeleteUser(int id, out string message)
        {
            var user = _userRepository.Get(id);
            if (user == null)
            {
                message = "User not found.";
                return false;
            }

            _userRepository.DeleteUser(user);
            message = "User deleted successfully.";
            return true;
        }

        public List<Users> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public Users? GetUser(int id)
        {
            return _userRepository.Get(id);
        }

        public Users? GetUserByRole(string role, out string message)
        {
            if (string.IsNullOrWhiteSpace(role))
            {
                message = "Role cannot be empty.";
                return null;
            }
            message = "User found.";
            return _userRepository.GetUserByRole(role);
        }

        public Users? UpdateUser(Users user, out string message)
        {
            throw new NotImplementedException();
        }
    }
}
