namespace MyService.Application.Model
{
    public class UserEvent
    {
        public UserEvent()
        {
        }

        public UserEvent(string userId, UserEventType eventType)
        {
            this.UserId = userId;
            this.EventType = eventType;
        }

        public string Id { get; set; }

        public string UserId { get; set; }

        public UserEventType EventType { get; set; }

        public bool IsHandled { get; set; }
    }
}
