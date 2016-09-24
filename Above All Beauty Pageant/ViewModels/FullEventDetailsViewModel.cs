using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Above_All_Beauty_Pageant.ViewModels
{
    public class FullEventDetailsViewModel
    {
        public string EventName { get; set; }
        public List<DetailsViewModel> Details {get;set;}
    }
}