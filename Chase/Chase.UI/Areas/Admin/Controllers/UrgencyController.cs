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
    public class UrgencyController : Controller
    {
        private readonly IUrgencyService _urgencyService;
        private readonly IMapper _mapper;

        public UrgencyController(IUrgencyService urgencyService, IMapper mapper)
        {
            _urgencyService = urgencyService;
            _mapper = mapper;
        }

        // İşlerin Listelenme Methodu.
        public IActionResult Index()
        {
          
            var urgencyListValue = _mapper.Map<List<UrgencyDto>>(_urgencyService.ListOfUrgency());
            return View(urgencyListValue);
            // var urgencyListModel = new UrgencyListViewModel
            // {
            //     Urgencies = _urgencyService.ListOfUrgency()
            // };
            // return View(urgencyListModel);
        }

        //İş Ekleme Sayfasının Metodu.
        public IActionResult InsertUrgency(Urgency urgency)
        {
            var urgencyAddValue = _mapper.Map<UrgencyDto>(urgency);
            return View(urgencyAddValue);
            // var urgencyAddModel = new UrgencyInsertViewModel
            // {
            //     Urgencies = new List<Urgency>()
            // };
            // return View(urgencyAddModel);
        }

        //İş Ekleme Methodu,İşi Ekle Butonuna Tıklayınca Bu Method Çalışacak.
        [HttpPost]
        public IActionResult InsertUrgency(UrgencyDto urgencyDto)
        {
            _urgencyService.AddingUrgency(_mapper.Map<Urgency>(urgencyDto));
            return RedirectToAction("Index");
            // _urgencyService.AddingUrgency(new Urgency
            // {
            //     Definition = model.Urgencies.Definition
            // });
        }

        //İş Güncelleme Sayfasının Metodu
        public IActionResult ModifiedUrgency(int id)
        {
            var urgencyModifiedValue = _mapper.Map<UrgencyDto>(_urgencyService.GetByUrgencyId(id));
            return View(urgencyModifiedValue);
            // var urgencyModifiedModel = new UrgencyModifiedViewModel
            // {
            //     Urgency = _urgencyService.GetByUrgencyId(id)
            // };
            // return View(urgencyModifiedModel);
        }

        //İşi Güncel'le Butonuna Tıklayınca Bu Method Çalışacak.
        [HttpPost]
        public IActionResult ModifiedUrgency(UrgencyDto urgencyDto)
        {
            _urgencyService.UpdatedUrgency(_mapper.Map<Urgency>(urgencyDto));
            return RedirectToAction("Index");
            // _urgencyService.UpdatedUrgency(new Urgency
            // {
            //     Definition = model.Urgency.Definition,
            //     Id = model.Urgency.Id
            // });
            // return RedirectToAction("Index");
        }

        public IActionResult RemoveUrgency(int id)
        {
            _urgencyService.DeletedUrgency(id);
            return RedirectToAction("Index");
        }

        
    }
}