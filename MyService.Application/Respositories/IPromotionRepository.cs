using System.Collections.Generic;
using MyService.Application.Model;

namespace MyService.Application.Respositories
{
    public interface IPromotionRepository
    {
        IList<Promotion> GetAll();

        void Delete(string id);

        void Add(Promotion promotion);
    }
}
