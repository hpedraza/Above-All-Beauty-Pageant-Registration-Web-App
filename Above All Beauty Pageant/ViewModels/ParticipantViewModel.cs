using Above_All_Beauty_Pageant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Above_All_Beauty_Pageant.Helper.Functions;
namespace Above_All_Beauty_Pageant.ViewModels
{


    public class ParticipantViewModel
    {

        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Plese select a gender.")]
        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Please select an age group.")]
        [Display(Name = "Age Group")]
        public AgeGroup AgeGroup { get; set; }

        public string AgeGroupDataAnnotation { get; set; }

        [Required(ErrorMessage = "Please select an event you would like to participant in.")]
        [Display(Name = "Event Name")]
        public string EventName { get; set; }

        public int Id { get; private set; }

        public bool Paid { get; set; }

        [Required(ErrorMessage = "Please type in participant's favorite hobbies.")]
        [Display(Name = "Hobbies")]
        public string Hobbies { get; set; }

        [Required(ErrorMessage = "Please type in participant's eye color.")]
        [Display(Name = "Eye Color")]
        public string EyeColor { get; set; }

        [Required(ErrorMessage = "Please type in participant's hair color.")]
        [Display(Name = "Hair Color")]
        public string HairColor { get; set; }

        [Required(ErrorMessage = "Please type in participant's favorite color.")]
        [Display(Name = "Favorite Color")]
        public string FavoriteColor { get; set; }

        [Required(ErrorMessage = "Please type in participant's favorite food.")]
        [Display(Name = "Favorite Food")]
        public string FavoriteFood { get; set; }

        [Required(ErrorMessage = "Please select date of birth.")]
        [Display(Name = "Date of birth")]
        public DateTime DOB{ get; set; }

        public string Sponsor { get; set; }

        public ParticipantViewModel()
        {

        }

        public ParticipantViewModel(string FN, string ln, AgeGroup ageGroup, string eventName, int id)
        {
            var helper = new HelperFunctions();
            var attr = helper.getEnumDisplayAnnotaion(ageGroup, (int)ageGroup);
            AgeGroupDataAnnotation = ((DisplayAttribute)attr[0]).Name;

            AgeGroup = ageGroup;
            FirstName = FN;
            LastName = ln;
            EventName = eventName;
            Id = id;
        }

        public ParticipantViewModel(string FN, string ln, AgeGroup ageGroup, string eventName, Gender gender, bool paid, int id)
        {
            var helper = new HelperFunctions();
            var attr = helper.getEnumDisplayAnnotaion(ageGroup, (int)ageGroup);
            AgeGroupDataAnnotation = ((DisplayAttribute)attr[0]).Name;

            FirstName = FN;
            LastName = ln;
            AgeGroup = ageGroup;
            Gender = gender;
            EventName = eventName;
            Paid = paid;
            Id = id;
        }
    }
}