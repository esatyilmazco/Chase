using System.Collections.Generic;
using System.Linq;
using Chase.Business.Notional;
using Chase.DataAccess.Notional;
using Chase.Entities.Tangible;
using Microsoft.AspNetCore.Identity;

namespace Chase.Business.Tangible
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;
        private readonly UserManager<AppUser> _userManager;

        public MessageManager(IMessageDal messageDal, UserManager<AppUser> userManager)
        {
            _messageDal = messageDal;
            _userManager = userManager;
        }

        public void SendMessage(Message message)
        {
            _messageDal.Add(message);
        }

        public void DeleteMessage(int messageId)
        {
            _messageDal.Delete(new Message {Id = messageId});
        }

        public void UpdatedMessage(Message message)
        {
            _messageDal.Update(message);
        }

        public Message GetByMessageId(int messageId)
        {
            return _messageDal.Get(m => m.Id == messageId);
        }

        public List<Message> UnreadMessages(int userId)
        {
            return _messageDal.UnReadMessage(userId).ToList();
        }

    }
}