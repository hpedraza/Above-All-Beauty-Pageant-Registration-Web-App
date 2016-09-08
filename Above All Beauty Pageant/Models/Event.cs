using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Above_All_Beauty_Pageant.Models
{
    public class Event
    {
        public int Id { get; set; }

        public string EventName { get; private set; }


        public Address Location { get; private set; }
        public int LocationId { get; private set; }


        public DateTime TimeOfEvent { get; private set; }

        public Event()
        {

        }

        public Event(string Name, int AddressId, DateTime Time)
        {
            EventName = Name;
            LocationId = AddressId;
            TimeOfEvent = Time;
        }
    }
}