using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    public class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator()
        {
            RuleFor(p => p.MovieName).NotEmpty().WithMessage("Film ismi boş bırakılamaz.");
        }
    }
}
