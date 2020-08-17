using System;
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
    public class StaffWorkOrderController : Controller
    {
        private readonly IDutyService _dutyService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IReportService _reportService;
        private readonly IDeclarationService _declarationService;

        public StaffWorkOrderController(IDutyService dutyService, IMapper mapper, UserManager<AppUser> userManager,
            IReportService reportService, IDeclarationService declarationService)
        {
            _dutyService = dutyService;
            _mapper = mapper;
            _userManager = userManager;
            _reportService = reportService;
            _declarationService = declarationService;
        }

        public async Task<IActionResult> TaskListOfStaff()
        {
            var staffUserName = await _userManager.FindByNameAsync(User.Identity.Name);
            var staffDutyListValue =
                _mapper.Map<List<DutyDto>>(_dutyService.FetchAllTables(I =>
                    I.AppUserId == staffUserName.Id && !I.Case));
            return View(staffDutyListValue);
        }

        public IActionResult AddReport(int id)
        {
            //View'da ki DutyId'yi karşılayan bir id değeri olmak zorunda.
            ReportDto reportDto = new ReportDto
            {
                DutyId = id
            };
            return View(reportDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddReport(ReportDto reportDto)
        {
            _reportService.AddedReport(_mapper.Map<Report>(reportDto));

            var managerList = await _userManager.GetUsersInRoleAsync("Admin"); //Yönetici Olanlara getir.
            await AddReportNotifications(managerList);
            return RedirectToAction("TaskListOfStaff");
        }

        private async Task AddReportNotifications(IList<AppUser> managerList)
        {
            var staff = await _userManager.FindByNameAsync(User.Identity.Name); //Personeli Getirdik.
            foreach (var manager in managerList)
            {
                _declarationService.AddedDeclaration(new Declaration
                {
                    Explanation = $"{staff.Name} {staff.SurName}  Personel'i Yeni Bir Rapor Yazdı",
                    AppUserId = manager.Id,
                    DateTime = DateTime.Now
                });
            }
        }

        public IActionResult UpdateReports(int id)
        {
            //istenen raporu getirdik.
            var updatedReports = _mapper.Map<ReportDto>(_reportService.GetByReportId(id));
            return View(updatedReports);
        }

        [HttpPost]
        public IActionResult UpdateReports(ReportUpdateDto reportUpdateDto)
        {
            var updatedValue = _reportService.GetByReportId(reportUpdateDto.Id); //Güncelenecek ReportId'yi çektik.
            updatedValue.ReportDefinition = reportUpdateDto.ReportDefinition;
            updatedValue.ReportDetail = reportUpdateDto.ReportDetail;
            _reportService.ModifiedReports(updatedValue);
            return RedirectToAction("TaskListOfStaff");
        }

        public IActionResult RemoveReports(int id)
        {
            _reportService.DeletedReports(id);
            return RedirectToAction("TaskListOfStaff");
        }

        public async Task<IActionResult> TaskCompletion(int dutyId)
        {
            var taskCompletionValues = _dutyService.GetByDutyId(dutyId); //Görevin Id'sine ulaştık.
            taskCompletionValues.Case = true;
            _dutyService.UpdatedDuty(taskCompletionValues);
            await TaskCompletionNotifications();
            return RedirectToAction("AllTablesAndFinishedWorks", "Member"); //Tamamlanan İşlere Yönlendir.
        }

        private async Task TaskCompletionNotifications()
        {
            var managerList = await _userManager.GetUsersInRoleAsync("Admin");
            var staff = await _userManager.FindByNameAsync(User.Identity.Name);
            foreach (var manager in managerList)
            {
                _declarationService.AddedDeclaration(new Declaration
                {
                    Explanation = $"{staff.Name} {staff.SurName} Görevi Tamamladı",
                    AppUserId = manager.Id,
                    DateTime = DateTime.Now
                });
            }
        }
    }
}