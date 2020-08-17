using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Chase.Business.Notional;
using Chase.Entities.DTOs;
using Chase.Entities.Tangible;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Chase.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageService _messageService;

        public MessageController(IMapper mapper, UserManager<AppUser> userManager, IMessageService messageService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _messageService = messageService;
        }

        //Personel'e Mesaj Yollama Sayfasının Methodu
        public async Task<IActionResult> SendMessageToStaff()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var messageListDto = _mapper.Map<MessageDto>(_messageService.GetByMessageId(user.Id));
            return View(messageListDto);
        }

        [HttpPost]
        public IActionResult SendMessageToStaff(MessageDto messageDto)
        {
            _messageService.SendMessage(_mapper.Map<Message>(messageDto));
            return RedirectToAction("MessagesFromStaff");
            // _messageService.SendMessage(new Message
            // {
            //     AppUserId = messageDto.AppUserId,
            //     MessageText = messageDto.MessageText,
            //     MessageSendingDate = DateTime.Now
            // });
        }

        public async Task<IActionResult> MessagesFromStaff()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var messageList = _mapper.Map<List<MessageDto>>(_messageService.UnreadMessages(user.Id));
            return View(messageList);
        }

        public IActionResult RemoveMessage(int messageId)
        {
            _messageService.DeleteMessage(messageId);
            return RedirectToAction("MessagesFromStaff");
        }
    }
}