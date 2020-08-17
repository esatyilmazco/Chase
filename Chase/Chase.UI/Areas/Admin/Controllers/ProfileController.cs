using System.Threading.Tasks;
using AutoMapper;
using Chase.Entities.DTOs;
using Chase.Entities.Tangible;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Chase.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public ProfileController(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> ProfileArea()
        {
            var managerName = await _userManager.FindByNameAsync(User.Identity.Name);
            var managerList = _mapper.Map<AppUserListDto>(managerName);
            return View(managerList);
            // return View(_mapper.Map<AppUserListDto>(await _userManager.FindByNameAsync(User.Identity.Name)));
        }

     
    }
}