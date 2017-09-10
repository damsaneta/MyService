using System;
using System.Collections.Generic;
using System.Linq;
using MyService.Application.Model;

namespace MyService.Application.Respositories
{
    public class UserRepository : IUserRepository
    {
        public User GetOrAdd(string email)
        {
            using (var session = RavenDocumentStore.Store.OpenSession())
            {
                var user = session.Query<User>()
                    .SingleOrDefault(x => x.Email == email);
                if (user == null)
                {
                    user = new User {Email = email};
                    session.Store(user);
                    var evt = new UserEvent(user.Id, UserEventType.UserCreated);
                    session.Store(evt);
                    session.SaveChanges();
                }

                return user;
            }
        }

        public IList<User> GetAll()
        {
            using (var session = RavenDocumentStore.Store.OpenSession())
            {
                return session.Query<User>().ToList();
            }
        }

        public User Get(string id)
        {
            using (var session = RavenDocumentStore.Store.OpenSession())
            {
                return session.Load<User>(id);
            }
        }
    }
}