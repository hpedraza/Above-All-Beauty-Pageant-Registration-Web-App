using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;
using Above_All_Beauty_Pageant.Helper.Functions;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        public string FirstName { get;set;}

        [Required]
        public string LastName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public EventCategory EventCategory { get; set; }
        public int EventCategoryId { get; set; }

        public ApplicationUser User { get; set; }
        public string UserId { get; private set; }

        public bool paid { get; private set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public string HairColor { get; set; }

        [Required]
        public string EyeColor { get; set; }

        [Required]
        public string FavoriteColor { get; set; }

        [Required]
        public string FavoriteFood { get; set; }

        [Required]
        public string Hobbies { get; set; }

        public string Sponsor { get; set; }
     
        public Participant()
        {

        }

        public void ParticipantPaid()
        {
            paid = true;
        }

        public void Update(string eyeColor, string favoriteColor, string favoriteFood, string hairColor, string hobbies, string sponsor)
        {
            EyeColor = eyeColor;
            favoriteColor = FavoriteColor;
            FavoriteFood = favoriteFood;
            HairColor = hairColor;
            Hobbies = hobbies;
            Sponsor = sponsor;
        }

        public Participant(string FirstName, string LastName, Gender Gender ,string UserId, int eventId, DateTime dob, string hairColor, string eyeColor, string favoriteColor, string favoriteFood, string hobbies, string sponsor = null)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Gender = Gender;
            this.UserId = UserId;
            EventCategoryId = eventId;
            paid = false;
            DOB = dob;
            HairColor = hairColor;
            EyeColor = eyeColor;
            FavoriteColor = favoriteColor;
            FavoriteFood = favoriteFood;
            Hobbies = hobbies;
            Sponsor = sponsor;
        }
    }
}