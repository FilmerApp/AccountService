using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;
using DAL.Interfaces;

namespace DAL
{
    public class UserDataAccess: IEditUserData, IGetUserData
    {
        private readonly UserContext _context;

        public UserDataAccess(UserContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void RegisterUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User GetUser(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id) ?? throw new ArgumentException("No user with that id could be found", nameof(id));
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email) ?? throw new ArgumentException("No user with that email could be found", nameof(email));
        }

        public void UpdateEmail(int id, string newEmail)
        {
            User user = _context.Users.FirstOrDefault(x => x.Id == id) ?? throw new ArgumentException("No user with that id exists", nameof(id));
            if (user.Email == newEmail)
            {
                throw new ArgumentException("The new email is the same as the old email", nameof(newEmail));
            }
            user.Email = newEmail;
            _context.Update(user);
            _context.SaveChanges();
        }

        public void UpdateUsername(int id, string newUsername)
        {
            User user = _context.Users.FirstOrDefault(x => x.Id == id) ?? throw new ArgumentException("No user with that id exists", nameof(id));
            if (user.Username == newUsername)
            {
                throw new ArgumentException("The new username is the same as the old username", nameof(newUsername));
            }
            user.Username = newUsername;
            _context.Update(user);
            _context.SaveChanges();
        }

        public void UpdatePassword(int id, string newPassword)
        {
            User user = _context.Users.FirstOrDefault(x => x.Id == id) ?? throw new ArgumentException("No user with that id exists", nameof(id));
            if (user.Password == newPassword)
            {
                throw new ArgumentException("The new password is the same as the old password", nameof(newPassword));
            }
            user.Password = newPassword;
            _context.Update(user);
            _context.SaveChanges();
        }

        public bool DoesUserExist(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id) != null;
        }

        public bool IsEmailUnique(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email) == null;
        }
    }
}
