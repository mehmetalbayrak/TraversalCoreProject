using Dto.DTOs.AnnouncementDtos;
using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation
{
    public class AnnouncementValidator : AbstractValidator<AddAnnouncementDto>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık bilgisi boş geçilemez.");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Başlık bilgisi boş geçilemez.");
            RuleFor(x => x.Content).MinimumLength(5).WithMessage("Lütfen en az 5 karakter girişi yapınız.");
            RuleFor(x => x.Content).MaximumLength(100).WithMessage("Lütfen en fazla 100 karakter girişi yapınız.");
        }
    }
}
