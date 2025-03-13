using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.IRepository;
using Domain.Models;

namespace DataAccessLayer.Repository
{
    public class UserRepository: IUserRepository
    {
        private ApplicationDBContext _applicationDbContext;

        public UserRepository(ApplicationDBContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public Users CreateUser(Users user)
        {
            _applicationDbContext.Users.Add(user);
            _applicationDbContext.SaveChanges();
            return user;
        }

        public void DeleteUser(Users user)
        {
            _applicationDbContext.Remove(user);
            _applicationDbContext.SaveChanges();
        }

        public Users? Get(int id)
        {
            return _applicationDbContext.Users.Find(id);
        }

        public List<Users> GetAllUsers()
        {
            return _applicationDbContext.Users.ToList();
        }

        public Users? GetUser(int id)
        {
            Users? users = _applicationDbContext.Users.Find(id);
            return users;
        }

        public Users? GetUserByEmail(string email)
        {
            Users? user = _applicationDbContext.Users.FirstOrDefault(fil => fil.Email.ToLower() == email.ToLower());
            return user;
        }

        public Users? GetUserByRole(string role)
        {
            Users? user = _applicationDbContext.Users.FirstOrDefault(fil => fil.Role.ToLower() == role.ToLower());
            return user;
        }

        public Users? Update(Users user)
        {
            Users? existingUser = _applicationDbContext.Users.Find(user.Id);



            existingUser.Username = user.Username;
            existingUser.Email = user.Email;
            existingUser.UpdatedAt = user.UpdatedAt;

            _applicationDbContext.Users.Update(existingUser);
            _applicationDbContext.SaveChanges();

            return existingUser;
        }
    }
}
