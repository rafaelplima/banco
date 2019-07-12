using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoMicrosservico.Domain.Interface
{
    public interface INotificacao
    {

        bool Invalid { get; }
        bool Valid { get; }
        IEnumerable<Notification> Notifications { get; }

        void AddNotification(Notification notification);
        void AddNotification(string propriedade, string mensagem);
        void AddNotifications(IEnumerable<Notification> notifications);
    }
}
