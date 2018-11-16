
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Diagnostics;

namespace MVCPS.ModelsValidations
{
    public class ValidacionCoberturaAttribute : ValidationAttribute
    {

        private readonly string _other;
        public ValidacionCoberturaAttribute(string other)
        {
            _other = other;
        }
        public override bool RequiresValidationContext { get { return true; } }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var property = validationContext.ObjectType.GetProperty(_other);

            if (property == null)
            {
                return new ValidationResult(
                    string.Format("Unknown property: {0}", _other)
                );
            }
            var otherValue = property.GetValue(validationContext.ObjectInstance, null);

            if ((int) otherValue == 1 && Convert.ToSingle(value) > 50)
            {
                return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
            }
            return null;
        }
        
    }
}