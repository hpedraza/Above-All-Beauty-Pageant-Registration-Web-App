using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Above_All_Beauty_Pageant.Models
{
    public enum AgeGroup
    {
        [Display(Name = "Baby Miss")]
        BabyMiss,

        [Display(Name = "Pee Wee Miss")]
        PeeWeeMiss,

        [Display(Name = "Tiny Miss")]
        TinyMiss,

        [Display(Name = "Little Miss")]
        LittleMiss,

        [Display(Name = "Baby Miss")]
        PetiteMiss,

        [Display(Name = "Youth Miss")]
        YouthMiss,

        [Display(Name = "Teen Miss")]
        TeenMiss,

        [Display(Name = "Baby Mr.")]
        BabyMr,

        [Display(Name = "Pee Wee Mr.")]
        PeeWeeMr,

        [Display(Name = "Tiny Mr.")]
        TinyMr,

        [Display(Name = "Little Mr.")]
        LittleMr
    }


    public class EventCategory
    {
        public int Id { get; set; }

        [Index("KEY",1,IsUnique = true)]
        public AgeGroup Category { get; set; }

        public ICollection<Participant> Participants { get; set; }

        public Event Event { get; set; }
        [Index("KEY", 2, IsUnique = true)]
        public int EventId { get; set; }

        public EventCategory()
        {
            Participants = new HashSet<Participant>();
        }

        public EventCategory(AgeGroup category, int eventId)
        {
            Participants = new HashSet<Participant>();
            Category = category;
            EventId = eventId;
        }

    }


}