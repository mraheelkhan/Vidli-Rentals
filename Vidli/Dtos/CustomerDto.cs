using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidli.Models;
using Vidli.Models.ModelValidations;

namespace Vidli.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string CustomerName { get; set; }

        [Required]
        public string CustomerAddress { get; set; }

        [Required]
        [MinAgeForMembershipTypeApi]
        public int CustomerAge { get; set; }


        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        [Required]
        public byte MemberShipTypeId { get; set; }
    }
}