using Chase.Business.Notional;
using Chase.Entities.Tangible;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Chase.UI.Areas.Admin.ViewComponents
{
    public class NotificationViewComponent : ViewComponent
    {
        private readonly IDeclarationService _declarationService;
        private readonly UserManager<AppUser> _userManager;

        public NotificationViewComponent(IDeclarationService declarationService, UserManager<AppUser> userManager)
        {
            _declarationService = declarationService;
            _userManager = userManager;
        }

        public ViewViewComponentResult Invoke()
        {
            //Bildirim Gösterme
            if (User.Identity != null)
            {
                var appUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
                var notifications = _declarationService.UnreadNotification(appUser.Id).Count;
                ViewBag.NumberOfNotifications = notifications;
            }
            return View();
    
        }
    }
}