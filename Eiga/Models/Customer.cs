using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Eiga.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required] //To make CustomerName NOT NULL
        [StringLength(255)] //limiting the string size to 255
        //By default as CustomerName is string, it is null length of MAX so we have used attributes(Required, StringLength) 
        //This approach of overriding the defaults is called as Data Annotations
        [Display(Name = "Name")]    //to display CustomerName as Name
        public string CustomerName { get; set; }
        [Min18YearsIfAMember]
        public DateTime? CustomerBirthDate { get; set; }    //to make CustomerBirthDate nullable
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }
        
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}