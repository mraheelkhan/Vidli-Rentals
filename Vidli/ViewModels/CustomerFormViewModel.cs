using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidli.Models;
using Vidli.Models.ModelValidations;

namespace Vidli.ViewModels
{
    public class CustomFormViewModel
    {
        public IEnumerable<MembershipType> MembershipType { get; set; }

        //public CustomerModel Customer { get; set; }

        public int? Id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "Customer Address")]
        public string CustomerAddress { get; set; }

        [Required]
        [Range(10,120)]
        [Display(Name = "Customer Age")]
        [MinAgeForMembershipType]
        public int? CustomerAge { get; set; }


        public bool IsSubscribedToNewsletter { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        public byte? MemberShipTypeId { get; set; }


        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Customer" : "New Customer";
            }
        }

        public CustomFormViewModel()
        {
            Id = 0;
        }
        public CustomFormViewModel(CustomerModel customer)
        {
            Id = customer.Id;
            CustomerName = customer.CustomerName;
            CustomerAge = customer.CustomerAge;
            CustomerAddress = customer.CustomerAddress;
            MemberShipTypeId = customer.MemberShipTypeId;
            IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
        }
    }
}