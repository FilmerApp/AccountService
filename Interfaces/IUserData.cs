using DAL.Model;

namespace Interfaces
{
    public interface IUserData
    {
        public User GetUser(int id);
    }
}