using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Above_All_Beauty_Pageant.ViewModels
{
    public class ParticipantIndexViewModel
    {
        public IList<ParticipantViewModel> Participants { get; set; }
        
        public ParticipantViewModel AddParticipant { get; set; }

        public List<string> EventNames { get; set; }

        public ParticipantIndexViewModel()
        {
            Participants = new List<ParticipantViewModel>();
        }
    }
}