using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidli.Models.ModelValidations
{
    public class MinAgeForMembershipType : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (CustomerModel) validationContext.ObjectInstance;
            if(customer.MemberShipTypeId == MembershipType.Unknown || customer.MemberShipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            if(customer.CustomerAge == 0)
                return new ValidationResult("Customer Age is required");

            return customer.CustomerAge >= 18
                ? ValidationResult.Success
                : new ValidationResult("Customer must be 18 years old to go with subscription plan.");
        }
    }
}