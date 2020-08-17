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
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class MemberController : Controller
    {
        private readonly IReportService _reportService;
        private readonly IDutyService _dutyService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public MemberController(IDutyService dutyService,
            UserManager<AppUser> userManager, IMapper mapper, IReportService reportService)
        {
            _dutyService = dutyService;
            _userManager = userManager;
            _mapper = mapper;
            _reportService = reportService;
        }

        public async Task<IActionResult> Index()
        {
            await NumberOfReportsWrittenByTheStaff();
            await NumberOfTasksCompletedByStaff();
            await NumberOfTasksToBePerformedByStaff();
            return View();
        }

        private async Task NumberOfTasksToBePerformedByStaff()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.NumberOfTaskToBe = _dutyService.GetNumberOfTasksToBePerformedByTheStaff(user.Id);
        }

        private async Task NumberOfTasksCompletedByStaff()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.NumberOfTasksPerformed = _dutyService.GetNumberOfTasksCompletedByTheStaff(user.Id);
        }

        private async Task NumberOfReportsWrittenByTheStaff()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.NumberOfReportsWritten = _reportService.GetStaffReportCount(user.Id);
        }

        //Tamamlanan İşleri tüm tablolar ile getirmek
        public async Task<IActionResult> AllTablesAndFinishedWorks()
        {
            var staffName = await _userManager.FindByNameAsync(User.Identity.Name);
            var staffValue = _dutyService.GetAllTablesAndCompleteJobs(staffName.Id);
            var listMap = _mapper.Map<List<DutyListAllDto>>(staffValue);
            return View(listMap);
        }
    }
}