using System.Collections.Generic;
using MyService.Application.Model;

namespace MyService.Application.Respositories
{
    public interface IUserRepository
    {
        User GetOrAdd(string email);

        IList<User> GetAll();

        User Get(string id);
    }
}
