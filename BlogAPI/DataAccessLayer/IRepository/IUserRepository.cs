using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace DataAccessLayer.IRepository
{
    public interface IUserRepository
    {
        /// <summary>
        /// Get user by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>user Object by Id</returns>
        Users? Get(int id);

        /// <summary>
        /// Get user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Users? GetUserByEmail(string email);

        /// <summary>
        /// Get user by role
        /// </summary>
        /// <param name="role"></param>
        /// <returns>user Object by Id</returns>
        Users? GetUserByRole(string role);


        /// <summary>
        /// All users
        /// </summary>
        /// <returns>List of users</returns>
        List<Users> GetAllUsers();



        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="user"></param>
        void DeleteUser(Users user);


        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>User Object</returns>
        Users CreateUser(Users user);

        /// <summary>
        /// Update user Details
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Updated Object</returns>
        Users? Update(Users user);

    }
}
