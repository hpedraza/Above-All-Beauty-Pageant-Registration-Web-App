using Above_All_Beauty_Pageant.Helper.Functions;
using Above_All_Beauty_Pageant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Above_All_Beauty_Pageant.ViewModels
{
    [Authorize(Roles = "Admin")]
    public class DetailsViewModel
    {
        public string CategoryName { get; set; }
        public List<Participant> Participants { get; set; }

        public DetailsViewModel()
        {

        }

        public DetailsViewModel(AgeGroup categoryName, List<Participant> participants)
        {
            var helper = new HelperFunctions();
            var attr = helper.getEnumDisplayAnnotaion(categoryName, (int)categoryName);
            CategoryName = ((DisplayAttribute)attr[0]).Name;

            Participants = participants;
        }
    }
}