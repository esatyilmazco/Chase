using System;
using AutoMapper;
using Chase.Business.Notional;
using Chase.Entities.DTOs;
using Chase.Entities.Tangible;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Chase.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class WorkOrdersController : Controller
    {
        private readonly IDutyService _dutyService;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly IDeclarationService _declarationService;

        public WorkOrdersController(IDutyService dutyService, IMapper mapper, IFileService fileService,
            IDeclarationService declarationService)
        {
            _dutyService = dutyService;
            _mapper = mapper;
            _fileService = fileService;
            _declarationService = declarationService;
        }

        // Rolü Yönetici Olmayan Kullanıcıları ve İş Süreçlerini Listeleyeceğiz.
        public IActionResult Index()
        {
            //Yönetici olmayan personelin getirilmesi ve Bir İşin Süreçleri(Tüm Tabloları getirecek.)
            var tasksAndJobs = _dutyService.FetchAllTables();
            return View(tasksAndJobs);
        }

        //Personel Atama Sayfasının Methodu
        public IActionResult AppointStaff(int id)
        {
            //Bu Method'un İşi Personel Görevlendir Butonuna Tıklayınca Id'sine göre İş Süreçlerini Getiren Method.
            var listDutyAppoint = _mapper.Map<DutyListAllDto>(_dutyService.BringWithUrgencyId(id));
            return View(listDutyAppoint);
        }

        [HttpPost]
        public IActionResult AppointStaff(DutyListAllDto dutyListAllDto)
        {
            // var dutyValue = _mapper.Map<Duty>(_dutyService.GetByDutyId(model.Id));Bu kod ile de çalışılabilir.
            //Göreve ulaşıyoruz(Görev Id'sine)
            var dutyIdValue = _dutyService.GetByDutyId(dutyListAllDto.Id);
            //Duty'nin AppUserId'sinin Karşısına gene Duty Nesnesi verilmeli.
            dutyIdValue.AppUserId =dutyListAllDto.StaffId; //Görevin Kullanıcı ID'sine = dutyListAllDto'nun personelId'sini atıyoruz.
            _dutyService.UpdatedDuty(dutyIdValue);
            NotificationOfAssignmentToStaff(dutyListAllDto, dutyIdValue);
            return RedirectToAction("Index");
        }

        private void NotificationOfAssignmentToStaff(DutyListAllDto dutyListAllDto, Duty dutyIdValue)
        {
            _declarationService.AddedDeclaration(new Declaration
            {
                AppUserId = dutyListAllDto.StaffId,
                Explanation = $"{dutyIdValue.Name} Ad'lı Bu Görevi Aldınız.",
                DateTime = DateTime.Now
            });
        }

        //Raporların Detayını Gösteren Sayfanın Methodu
        public IActionResult ShowJobDetail(int id)
        {
            var dutyWithReport = _mapper.Map<DutyListAllDto>(_dutyService.GetReportsAndUsers(id));
            return View(dutyWithReport);
        }

        //Excel Dosyası Getirme Methodu.
        public IActionResult GetExcelFile(int id)
        {
            //İstediğimiz Raporun Id'sini çektik.Report'a ulaştık.
            var reporIdlist = _dutyService.GetReportsAndUsers(id).Reports;
            var excelFile = _fileService.TransferExcel(reporIdlist);
            return File(excelFile, "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                Guid.NewGuid() + ".xlsx");
        }
    }
}