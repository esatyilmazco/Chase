using System.Collections.Generic;
using AutoMapper;
using Chase.Business.Notional;
using Chase.Entities.DTOs;
using Chase.Entities.Tangible;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chase.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class DutyController : Controller
    {
        private readonly IDutyService _dutyService;
        private readonly IMapper _mapper;

        public DutyController(IDutyService dutyService, IMapper mapper)
        {
            _dutyService = dutyService;
            _mapper = mapper;
        }
        // Görev Listeleme Methodu
        public IActionResult Index()
        {
            //Tamamlanmamış İşe Göre Getir.(Minus());
            var listOfDutyValue = _mapper.Map<List<DutyDto>>(_dutyService.Minus());
            return View(listOfDutyValue);
            // var listOfDutyValue = new DutyListViewModel
            // {
            //     Duties = _dutyService.ListOfDuty()

            // };
            // return View(listOfDutyValue);
          
        }

        //Görev Ekleme Sayfası Methodu
        public ActionResult InsertDuty(Duty duty)
        {
            var addedtDuty = _mapper.Map<DutyDto>(duty);
            return View(addedtDuty);
        }

        //Method Post Olunca.
        [HttpPost]
        public ActionResult InsertDuty(DutyDto dutyDto)
        {
            if (!ModelState.IsValid) return View(dutyDto);

            _dutyService.AddedDuty(_mapper.Map<Duty>(dutyDto));
            return RedirectToAction("Index");
        }

        public IActionResult ModifiedDuty(int id)
        {
            var modifiedDutyValue = _mapper.Map<DutyDto>(_dutyService.GetByDutyId(id));
            return View(modifiedDutyValue);
        }

        //Güncelleme Sayfasın'da ki Güncelle Butonuna Basınca Bu Method Çalışır.
        [HttpPost]
        public IActionResult ModifiedDuty(DutyDto dutyDto)
        {
            _dutyService.UpdatedDuty(_mapper.Map<Duty>(dutyDto));
            return RedirectToAction("Index");
        }

        public IActionResult RemoveDuty(int id)
        {
            _dutyService.DeletedDuty(id);
            return RedirectToAction("Index");
        }

      
       
    }
}