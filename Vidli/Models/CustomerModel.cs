using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidli.Models.ModelValidations;

namespace Vidli.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Enter Customer Name")]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "Enter Customer Address")]
        public string CustomerAddress { get; set; }

        [Required]
        [Display(Name = "Enter Customer Age")]
        [MinAgeForMembershipType]
        public int CustomerAge { get; set; }


        public bool IsSubscribedToNewsletter { get; set; }


        public MembershipType MembershipType { get; set; }

        [Required]
        public byte MemberShipTypeId { get; set; }
    }
}