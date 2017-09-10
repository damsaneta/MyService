using System.Diagnostics;
using System.Web.Http;
using MyService.Application.Model;
using MyService.Application.Respositories;

namespace MyService.WebApi.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserRepository userRepository = new UserRepository();

        public IHttpActionResult Post(User user)
        {
            user = this.userRepository.GetOrAdd(user.Email);
            return this.Ok(user);
        }

        public IHttpActionResult Get(int id)
        {
            return this.Ok("Ok");
        }
    }
}
