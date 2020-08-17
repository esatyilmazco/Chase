using Chase.Business.Notional;
using Chase.Entities.Tangible;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Chase.UI.Areas.Admin.ViewComponents
{
    public class MessageViewComponent:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageService _messageService;
        public MessageViewComponent(UserManager<AppUser> userManager, IMessageService messageService)
        {
            _userManager = userManager;
            _messageService = messageService;
        }

        public ViewViewComponentResult Invoke()
        {
            if (User.Identity!=null)
            {
                var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
                var messages = _messageService.UnreadMessages(user.Id).Count;
                ViewBag.NumberOfMessages = messages;
            }

            return View();
        }
    }
}