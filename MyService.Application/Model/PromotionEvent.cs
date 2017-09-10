namespace MyService.Application.Model
{
    public class PromotionEvent
    {
        public PromotionEvent()
        {   
        }

        public PromotionEvent(string promotionId, PromotionEventType promotionEventType)
        {
            this.PromotionId = promotionId;
            this.EventType = promotionEventType;
        }

        public string Id { get; set; }

        public string PromotionId { get; set; }

        public PromotionEventType EventType { get; set; }

        public bool IsHandled { get; set; }
    }
}
