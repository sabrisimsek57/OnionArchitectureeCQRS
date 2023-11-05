using Application.Features.Commands.Contact;
using Application.Features.Commands.Course;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.FluentValidation
{
    public class CreateCourseCommandRequestValidator : AbstractValidator<CreateCourseCommandRequest>
    {
        public CreateCourseCommandRequestValidator()
        {
            RuleFor(x => x.CourseTitle).MinimumLength(5).WithMessage("Başlık en az 5 karakter olmalıdır.");
            RuleFor(x => x.CourseDescription).MinimumLength(10).WithMessage("Açıklama en az 10 karakter olmalıdır.");
            RuleFor(x => x.CoursePrice).MinimumLength(3).WithMessage("Fiyar en az 3 karakter olmalıdır.");
            RuleFor(x => x.CourseGrade).MinimumLength(5).WithMessage("Seviye en az 5 karakter olmalıdır.");


        }
    }
    
}
