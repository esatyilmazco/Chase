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
    public class StaffMessageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IMessageService _messageService;
        public StaffMessageController(UserManager<AppUser> userManager, IMapper mapper, IMessageService messageService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _messageService = messageService;
        }

        //Gelen Mesajlar
        public async Task<IActionResult> IncomingMessages()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var listOfIncomingMessages = _mapper.Map<List<MessageDto>>(_messageService.UnreadMessages(user.Id));
            return View(listOfIncomingMessages);
        }

        public async Task<IActionResult> SendMessageToManager()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var managerListDto = _mapper.Map<MessageDto>(_messageService.GetByMessageId(user.Id));
            return View(managerListDto);
        }
        
        [HttpPost]
        public IActionResult SendMessageToManager(MessageDto messageDto)
        {
            _messageService.SendMessage(_mapper.Map<Message>(messageDto));
            return RedirectToAction("IncomingMessages");
        }

        public IActionResult RemoveMessage(int messageId)
        {
            _messageService.DeleteMessage(messageId);
            return RedirectToAction("IncomingMessages");
        }
        
    }
}