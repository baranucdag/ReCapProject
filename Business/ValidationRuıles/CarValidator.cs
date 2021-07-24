using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRuıles
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).NotEmpty();
            //RuleFor(c => c.DailyPrice).GreaterThan(55);
            RuleFor(c => c.ModelYear).GreaterThan(2010).When(c => c.BrandId == 1);
            //RuleFor(c => c.Description).Must(StartWithA);
        }

        private bool StartWithA(string arg)
        {
            throw new NotImplementedException();
        }
    }
}
