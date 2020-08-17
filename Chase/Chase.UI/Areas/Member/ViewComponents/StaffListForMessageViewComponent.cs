using System.Collections.Generic;
using AutoMapper;
using Chase.Business.Notional;
using Chase.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Chase.UI.Areas.Member.ViewComponents
{
    public class ListOfManagerForMessageViewComponent:ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public ListOfManagerForMessageViewComponent(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public ViewViewComponentResult Invoke()
        {
            var staffForList = _mapper.Map<List<AppUserListDto>>(_userService.FetchNonStaff());
            return View(staffForList);
        }
    }
}