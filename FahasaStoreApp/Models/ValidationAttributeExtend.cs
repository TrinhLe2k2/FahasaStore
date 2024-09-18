﻿using System.ComponentModel.DataAnnotations;

namespace FahasaStoreApp.Models
{
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public DateGreaterThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var currentValue = (DateTime?)value;
            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (property == null)
            {
                throw new ArgumentException("Property with this name not found.");
            }

            var comparisonValue = (DateTime?)property.GetValue(validationContext.ObjectInstance);

            if (currentValue.HasValue && comparisonValue.HasValue && currentValue.Value < comparisonValue.Value)
            {
                return new ValidationResult(ErrorMessage ?? $"EndDate must be greater than or equal to {comparisonValue.Value.ToShortDateString()}");
            }

            return ValidationResult.Success!;
        }
    }

}
