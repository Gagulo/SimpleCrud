using SimpleCrud.Entities;
using SimpleCrud.Models;
using System.Collections.Generic;

namespace SimpleCrud.Repositories
{
    public interface IPersonRepository
    {
        IList<UserModel> GetAllUsers();
        User GetUser(long id);

        void Add(AddUserModel user);
        void Update(User user);
    }
}
