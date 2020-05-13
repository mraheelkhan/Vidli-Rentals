using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidli.Dtos
{
    public class CustomerReadOnlyDto
    {
        public string CustomerName { get; set; }

        public MembershipTypeDto MembershipType { get; set; }
    }
}