using System;
using System.Collections.Generic;
using System.Linq;
using MyService.Application.Model;

namespace MyService.Application.Respositories
{
    public class EventRepository : IEventRepository
    {
        public IList<UserEvent> GetUserEvents()
        {
            using (var session = RavenDocumentStore.Store.OpenSession())
            {
                return session.Query<UserEvent>().Where(x => !x.IsHandled).ToList();
            }
        }

        public void MarkUserEventAsHandled(string id)
        {
            using (var session = RavenDocumentStore.Store.OpenSession())
            {
                var evt = session.Load<UserEvent>(id);
                evt.IsHandled = true;
                session.SaveChanges();
            }
        }

        public IList<PromotionEvent> GetPromotionEvents()
        {
            using (var session = RavenDocumentStore.Store.OpenSession())
            {
                return session.Query<PromotionEvent>().Where(x => !x.IsHandled).ToList();
            }
        }

        public void MarkPromotionEventAsHandled(string id)
        {
            using (var session = RavenDocumentStore.Store.OpenSession())
            {
                var evt = session.Load<PromotionEvent>(id);
                evt.IsHandled = true;
                session.SaveChanges();
            }
        }
    }
}