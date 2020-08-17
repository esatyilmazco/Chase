using System.Collections.Generic;
using System.Linq;
using Chase.Business.Notional;
using Chase.Entities.Tangible;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Chase.UI.TagHelpers
{
    [HtmlTargetElement("bring-duty")]
    public class DutyUserIdTagHelper : TagHelper
    {
        private readonly IDutyService _dutyService;

        public DutyUserIdTagHelper(IDutyService dutyService)
        {
            _dutyService = dutyService;
        }

        public int UserId { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            List<Duty> duties = _dutyService.GetByUserId(UserId);
            //ilgili kullanıcının görevi var mı?
            int completedTasks = duties.Count(d => d.Case);
            int numberOfTasksSheİsCurrentlyWorkingOn = duties.Count(d => !d.Case);
            string htmlString =
                $"<strong class='text-warning'>Tamamladığı Görev Sayısı : </strong> <span class='badge badge-success'>{completedTasks}<i class='fas fa-trophy ml-1'></i></span> " +
                $" <br> <strong class='text-info'>Üzerin'de Çalıştığı Görev Sayısı : </strong> <span class='badge badge-secondary'>{numberOfTasksSheİsCurrentlyWorkingOn}<i class='fas fa-thumbs-up ml-1'></i></span>";

            output.Content.SetHtmlContent(htmlString);
        }
    }
}