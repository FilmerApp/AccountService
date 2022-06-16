using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace DAL.Interfaces
{
    public interface IEditUserData
    {
        public void RegisterUser(User user);
        public void UpdateEmail(int id, string newEmail);
        public void UpdateUsername(int id, string newUsername);
        public void UpdatePassword(int id, string newPassword);
    }
}
