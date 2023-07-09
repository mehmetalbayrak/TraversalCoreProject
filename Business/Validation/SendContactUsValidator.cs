﻿using Dto.DTOs.ContactDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation
{
    public class SendContactUsValidator : AbstractValidator<SendMessageDto>
    {
        public SendContactUsValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanı boş geçilemez.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez.");
            RuleFor(x => x.Body).NotEmpty().WithMessage("Mesaj alanı boş geçilemez.");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Konu alanına en az 5 karakter veri girişi yapmanız gerekli.");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Konu alanına en fazla 100 karakter veri girişi yapabilirsiniz.");
            RuleFor(x => x.Mail).MinimumLength(5).WithMessage("Mail alanına en az 5 karakter veri girişi yapmanız gerekli.");
            RuleFor(x => x.Mail).MaximumLength(100).WithMessage("Mail alanına en fazla 100 karakter veri girişi yapabilirsiniz.");
        }
    }
}