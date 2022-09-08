using System;
using System.ComponentModel.DataAnnotations;

namespace LibrarryCrudOps.Validators
{
    public class NonEmptyGuidAttribute : ValidationAttribute
    {
        public NonEmptyGuidAttribute(string errorMessage) : base(errorMessage)
        {
        }

        public override bool IsValid(object value)
        {
            return !Equals(value, Guid.Empty);
        }
    }
}
