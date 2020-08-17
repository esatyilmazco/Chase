using System.Collections.Generic;
using AutoMapper;
using Chase.Business.Notional;
using Chase.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Chase.UI.Areas.Admin.ViewComponents
{
    public class ListOfStaffForMessageViewComponent:ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public ListOfStaffForMessageViewComponent(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public ViewViewComponentResult Invoke()
        {
            var forMessage = _mapper.Map<List<AppUserListDto>>(_userService.FetchNonAdmins());
            return View(forMessage);
        }
    }
}