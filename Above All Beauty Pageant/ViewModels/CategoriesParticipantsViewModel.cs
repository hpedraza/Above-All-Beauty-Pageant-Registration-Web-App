using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Above_All_Beauty_Pageant.Helper.Functions;
using Above_All_Beauty_Pageant.Models;
using System.ComponentModel.DataAnnotations;

namespace Above_All_Beauty_Pageant.ViewModels
{
    public class CategoriesParticipantsViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RegistrationNumber { get; set; } 

        public static int ParticipantId { get; set; }
        public static string EventName { get; set;}
        public static string CategoryName { get;set;}

        public CategoriesParticipantsViewModel(string fn, string ln, int registrationNumber)
        {
            FirstName = fn;
            LastName = ln;
            RegistrationNumber = registrationNumber;
        }

        public int GetParticipantId()
        {
            return ParticipantId;
        }

        public string GetEventName()
        {
            return EventName;
        }

        public string GetCategoryName()
        {
            return CategoryName;
        }

        public void SetStaticProp(int id , string eventName, string categoryName)
        {
            var helper = new Helper.Functions.HelperFunctions();

            ParticipantId = id;
            EventName = eventName;
        
             var attrs = helper.getEnumDisplayAnnotaion((AgeGroup) Enum.Parse( typeof(AgeGroup), categoryName ) , 
                                            (int) Enum.Parse(typeof(AgeGroup), categoryName));

            categoryName = ((DisplayAttribute)attrs[0]).Name;

            CategoryName = categoryName;
        }
    }

    
}