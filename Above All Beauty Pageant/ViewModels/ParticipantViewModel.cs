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