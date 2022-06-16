using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace DAL.Interfaces
{
    public interface IGetUserData
    {
        public User GetUser(int id);
        public User GetUserByEmail(string email);
        public bool IsEmailUnique(string email);
    }
}
