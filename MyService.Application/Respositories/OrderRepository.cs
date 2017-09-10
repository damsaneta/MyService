using System;
using MyService.Application.Model;

namespace MyService.Application.Respositories
{
    public class OrderRepository : IOrderRepository
    {
        public void Add(Order order)
        {
            using (var session = RavenDocumentStore.Store.OpenSession())
            {
                session.Store(order);
                var promotion = session.Load<Promotion>(order.PromotionId);
                promotion.CurrentCount ++;
                
                var evt = new PromotionEvent(promotion.Id, PromotionEventType.PromotionBought);
                session.Store(evt);
                if (promotion.MinimalCount == promotion.CurrentCount)
                {
                    var evt2 = new PromotionEvent(promotion.Id,PromotionEventType.PromotionActivated);
                    session.Store(evt2); 
                }

                session.SaveChanges();
            }
        }
    }
}