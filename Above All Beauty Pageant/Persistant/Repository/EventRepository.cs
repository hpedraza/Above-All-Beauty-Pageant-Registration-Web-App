using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Above_All_Beauty_Pageant.Core.Repositories;
using Above_All_Beauty_Pageant.ViewModels;
using Above_All_Beauty_Pageant.Models;

namespace Above_All_Beauty_Pageant.Persistant.Repository
{
    public class EventRepository : IEventRepository
    {
        private AboveAllContext _context;

        public EventRepository(AboveAllContext db)
        {
            _context = db;
        }

        public List<string> EventNames()
        {
            return _context.Events.DefaultIfEmpty().Select(e => e.EventName).ToList();
            
        }

        public int GetEventIdByName(string eventName)
        {
            return _context
                .Events
                .FirstOrDefault(e => e.EventName == eventName)
                .Id;
        }

        public List<CategoriesParticipantsViewModel> GetCategoryParticipants(AgeGroup AgeGroup, string eventName)
        {
            var list = _context.Categories.Include(x => x.Participants).FirstOrDefault(c => c.Category == AgeGroup && c.Event.EventName == eventName).Participants.ToList();

            var Participants = new List<CategoriesParticipantsViewModel>();
            foreach(var p in list)
            {
                Participants.Add(new CategoriesParticipantsViewModel(p.FirstName,p.LastName, p.Id));
            }

            return Participants;
        }
    }
}