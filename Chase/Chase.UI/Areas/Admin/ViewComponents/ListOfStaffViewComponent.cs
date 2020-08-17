using System.Collections.Generic;
using AutoMapper;
using Chase.Business.Notional;
using Chase.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Chase.UI.Areas.Admin.ViewComponents
{
    public class ListOfStaffViewComponent : ViewComponent
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public ListOfStaffViewComponent(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public ViewViewComponentResult Invoke()
        {
           
            //Bu Method Personellerin Listesini Getirecek.(Yönetici Olmayanlar)
            var listStaffValue = _mapper.Map<List<AppUserListDto>>(_userService.FetchNonAdmins());
            return View(listStaffValue);
        }
       
    }
}