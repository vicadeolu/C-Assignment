using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace BusinessLogicLayer.IServices
{
    public interface IUserService
    {
        Users? CreateUser(Users user, out string message);

        Users? GetUserByRole(string role, out string message);

        bool DeleteUser(int id, out string message);

        List<Users> GetAllUsers();

        Users? GetUser(int id);

        Users? UpdateUser(Users user, out string message);
    }
}
