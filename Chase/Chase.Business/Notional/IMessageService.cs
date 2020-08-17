using System.Collections.Generic;
using Chase.Entities.Tangible;

namespace Chase.Business.Notional
{
    public interface IMessageService
    {
        void SendMessage(Message message);
        void DeleteMessage(int messageId);
        void UpdatedMessage(Message message);
        Message GetByMessageId(int messageId);
        List<Message> UnreadMessages(int userId);
    }
}