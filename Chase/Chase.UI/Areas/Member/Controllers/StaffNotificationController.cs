using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Chase.Business.Notional;
using Chase.Entities.DTOs;
using Chase.Entities.Tangible;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Chase.UI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class StaffNotificationController : Controller
    {
        private readonly IDeclarationService _declarationService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public StaffNotificationController(IDeclarationService declarationService, UserManager<AppUser> userManager,
            IMapper mapper)
        {
            _declarationService = declarationService;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> ListOfStaffNotification()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var declarationStaffListDtos =
                _mapper.Map<List<DeclarationListDto>>(_declarationService.UnreadNotification(user.Id));
            return View(declarationStaffListDtos);
        }

        [HttpPost]
        public IActionResult ReadedStaffNotification(int id)
        {
            var notificationToBeUpdated = _declarationService.GetByDeclarationId(id);
            notificationToBeUpdated.Case = true;
            _declarationService.UpdatedDeclaration(notificationToBeUpdated);
            return RedirectToAction("ListOfStaffNotification");
        }
    }
}