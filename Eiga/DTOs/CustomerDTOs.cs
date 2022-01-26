using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eiga.Models;
using System.ComponentModel.DataAnnotations;


namespace Eiga.DTOs
{
    public class CustomerDTOs
    {
        public int CustomerId { get; set; }

        [Required] 
        [StringLength(255)] 
        public string CustomerName { get; set; }
        //[Min18YearsIfAMember]
        public DateTime? CustomerBirthDate { get; set; }   
        public bool IsSubscribedToNewsLetter { get; set; }

        /*Excluding membership type because this is a domain class and this property here is creating
            dependency from our DTO to our domain model.So if we change this membership type this can impact our DTO.*/
        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }
    }
}
