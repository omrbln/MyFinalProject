using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            //RuleFor(p => p.ProductName).NotEmpty().MinimumLength(2);  gibi tek satırda da yazılabilir ama daha sonra değişiklik yapabilmek için tercih edilmez.
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);

            //Olmayan bir kuralı yazmak
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı.");
            //Aşağıdaki false olursa burası patlar
        }

        //arg = ProductName
        private bool StartWithA(string arg) 
        {
            return arg.StartsWith("A");
        }
    }
}
