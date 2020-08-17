using Chase.Business.Notional;
using Chase.Entities.Tangible;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Chase.UI.Areas.Member.ViewComponents
{
    public class StaffNotificationViewComponent : ViewComponent
    {
        private readonly IDeclarationService _declarationService;
        private readonly UserManager<AppUser> _userManager;

        public StaffNotificationViewComponent(IDeclarationService declarationService, UserManager<AppUser> userManager)
        {
            _declarationService = declarationService;
            _userManager = userManager;
        }

        public ViewViewComponentResult Invoke()
        {
            if (User.Identity != null)
            {
                var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
                var notification = _declarationService.UnreadNotification(user.Id).Count;
                ViewBag.NumberOfNotifications = notification;
            }

            return View();
        }
    }
}