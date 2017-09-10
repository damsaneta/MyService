using System.Collections.Generic;
using MyService.Application.Model;

namespace MyService.Application.Respositories
{
    public interface IEventRepository
    {
        IList<PromotionEvent> GetPromotionEvents();

        IList<UserEvent> GetUserEvents();

        void MarkUserEventAsHandled(string id);

        void MarkPromotionEventAsHandled(string id);
    }
}
