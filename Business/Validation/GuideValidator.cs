using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation
{
    public class GuideValidator:AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Lütfen rehber adını giriniz.");
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Lütfen rehber açıklaması giriniz.");
            RuleFor(x=>x.Name).MaximumLength(30).WithMessage("Lütfen 30 karakterden daha az giriniz.");
            RuleFor(x=>x.Name).MinimumLength(8).WithMessage("Lütfen en az 8 karakter giriniz.");
        }
    }
}
