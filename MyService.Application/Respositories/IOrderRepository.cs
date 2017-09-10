using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyService.Application.Model;

namespace MyService.Application.Respositories
{
    public interface IOrderRepository
    {
        void Add(Order order);
    }
}
