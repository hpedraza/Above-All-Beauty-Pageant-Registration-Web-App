using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;
using Above_All_Beauty_Pageant.Helper.Functions;
namespace Above_All_Beauty_Pageant.Models
{
    public enum Gender
    {
        Male,
        Female
    }

    [Authorize]
    public class Participant
    {
        public int Id { get; set; }

        public string FirstName { get;set;}

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public EventCategory EventCategory { get; set; }
        public int EventCategoryId { get; set; }

        public ApplicationUser User { get; set; }
        public string UserId { get; private set; }

        public bool paid { get; set; }
        
        public Participant()
        {

        }

        public Participant(string FirstName, string LastName, Gender Gender ,string UserId, int eventId)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Gender = Gender;
            this.UserId = UserId;
            EventCategoryId = eventId;
            paid = false;
        }
    }
}