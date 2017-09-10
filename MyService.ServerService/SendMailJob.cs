using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using MyService.Application.Model;
using MyService.Application.Respositories;

namespace MyService.ServerService
{
    public class SendMailJob
    {
        private readonly IUserRepository userRepository = new UserRepository();
        private readonly IEventRepository eventRepository = new EventRepository();
        private readonly IPromotionRepository promotionRepository = new PromotionRepository();

        public void DoJob()
        {
             EventLog.WriteEntry("MyService.ServerService", "Przetwarzanie rozpoczęte", EventLogEntryType.Information);
            var userEvents = this.eventRepository.GetUserEvents();
            foreach (var userEvent in userEvents)
            {
                switch (userEvent.EventType)
                {
                    case UserEventType.UserCreated:
                        this.SendMailOnUserCreated(userEvent);
                        break;
                    default:
                        continue;
                }
            }

            var promotionEvents = this.eventRepository.GetPromotionEvents();
            foreach (var promotionEvent in promotionEvents)
            {
                switch (promotionEvent.EventType)
                {
                    case PromotionEventType.PromotionCreated:
                        this.SendMailOnPromotionCreated(promotionEvent);
                        break;
                    case PromotionEventType.PromotionDeleted:
                        this.SendMailOnPromotionDeleted(promotionEvent);
                        break;
                    case PromotionEventType.PromotionBought:
                        this.eventRepository.MarkPromotionEventAsHandled(promotionEvent.Id);
                        break;
                    case PromotionEventType.PromotionActivated:
                        this.SendMailOnPromotionActivated(promotionEvent);
                        break;
                    default:
                        continue;
                }
            }

             EventLog.WriteEntry("MyService.ServerService", "Przetwarzanie zakończone", EventLogEntryType.Information);
        }

        private void SendMailOnPromotionDeleted(PromotionEvent promotionEvent)
        {
            var promotion = this.promotionRepository.Get(promotionEvent.PromotionId);
            var users = this.userRepository.GetAll();
            this.SendEmail("Promocja została anulowana: " + promotion.Name, "", users.Select(x => x.Email).ToArray());
            this.eventRepository.MarkPromotionEventAsHandled(promotionEvent.Id);
        }

        private void SendMailOnPromotionCreated(PromotionEvent promotionEvent)
        {
            var promotion = this.promotionRepository.Get(promotionEvent.PromotionId);
            var users = this.userRepository.GetAll();
            this.SendEmail("Nowa promocja do kupienia: " + promotion.Name, "", users.Select(x => x.Email).ToArray());
            this.eventRepository.MarkPromotionEventAsHandled(promotionEvent.Id);
        }

        private void SendMailOnUserCreated(UserEvent userEvent)
        {
            var user = this.userRepository.Get(userEvent.UserId);
            this.SendEmail("Użytkownik utworzony", "", user.Email);
            this.eventRepository.MarkUserEventAsHandled(userEvent.Id);
        }

        private void SendMailOnPromotionActivated(PromotionEvent promotionEvent)
        {
            var promotion = this.promotionRepository.Get(promotionEvent.PromotionId);
            var users = this.userRepository.GetAll();
            this.SendEmail("Promocja została aktywowana: " + promotion.Name, "", users.Select(x => x.Email).ToArray());
            this.eventRepository.MarkPromotionEventAsHandled(promotionEvent.Id);
        }

        private void SendEmail(string subject, string body, params string[] emails)
        {
            using (var client = new SmtpClient())
            {
                foreach (var email in emails)
                {
                    var mailMessage = new MailMessage("myservicetest18@gmail.com", email, subject, body);
                    client.Send(mailMessage);
                     EventLog.WriteEntry("MyService.ServerService", "Mail wysłany do: " + email, EventLogEntryType.Information);
                }
            }
        }
    }
}
