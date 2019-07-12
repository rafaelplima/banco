using BancoMicrosservico.Domain.Interface;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoMicrosservico.Aplication.Notificacao
{
    public class NotificacaoServico : INotificacao
    {
       
        private List<Notification> _notifications;

       

        public NotificacaoServico()
        {
            _notifications = new List<Notification>();
        }
        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }

        public void AddNotifications(IEnumerable<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotification(string propriedade, string mensagem)
        {
            var notificacao = new Notification(propriedade, mensagem);
            AddNotification(notificacao);
        }
        public bool Valid => _notifications.Count == 0;
        public bool Invalid => !Valid;

        public IEnumerable<Notification> Notifications => _notifications.AsReadOnly();
    }
}
