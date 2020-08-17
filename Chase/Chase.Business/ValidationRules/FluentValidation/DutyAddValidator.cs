using Chase.Entities.DTOs;
using FluentValidation;

namespace Chase.Business.ValidationRules.FluentValidation
{
    public class DutyAddValidator:AbstractValidator<DutyDto>
    {
        public DutyAddValidator()
        {
            RuleFor(d => d.Name).NotEmpty().WithMessage("Görev Adı Boş Geçilemez");
            RuleFor(d => d.Description).NotEmpty().WithMessage("Görev Açıklaması Boş Geçilemez");
            RuleFor(d => d.UrgencyId).NotEmpty().WithMessage("İş Durumu Boş Geçilemez");
        }
    }
}