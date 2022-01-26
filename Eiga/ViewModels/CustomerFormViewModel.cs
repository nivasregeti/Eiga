using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eiga.Models;

namespace Eiga.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}