using System.Collections.Generic;
using System.Linq;
using MyService.Application.Model;

namespace MyService.Application.Respositories
{
    public class PromotionRepository : IPromotionRepository
    {
        public IList<Promotion> GetAll()
        {
            using (var session = RavenDocumentStore.Store.OpenSession())
            {
                return session.Query<Promotion>().Customize(x => x.WaitForNonStaleResults())
                    .Where(x => x.IsDeleted == false)
                    .ToList();
            }
        }

        public void Delete(string id)
        {
            using (var session = RavenDocumentStore.Store.OpenSession())
            {
                var promotion = session.Load<Promotion>(id);
                promotion.IsDeleted = true;
                var evt = new PromotionEvent(promotion.Id, PromotionEventType.PromotionDeleted);
                session.Store(evt);
                session.SaveChanges();
            }
        }

        public void Add(Promotion promotion)
        {
            using (var session = RavenDocumentStore.Store.OpenSession())
            {
                session.Store(promotion);
                var evt = new PromotionEvent(promotion.Id, PromotionEventType.PromotionCreated);
                session.Store(evt);
                session.SaveChanges();
            }
        }
    }
}