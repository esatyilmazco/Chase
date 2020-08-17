using System.Threading.Tasks;
using AutoMapper;
using Chase.Entities.DTOs;
using Chase.Entities.Tangible;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Chase.UI.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class StaffProfileController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public StaffProfileController(IMapper mapper, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IActionResult> StaffProfileIndex()
        {
            var staffName = await _userManager.FindByNameAsync(User.Identity.Name);
            var staffList = _mapper.Map<AppUserListDto>(staffName);
            return View(staffList);
        }
        
    }
}