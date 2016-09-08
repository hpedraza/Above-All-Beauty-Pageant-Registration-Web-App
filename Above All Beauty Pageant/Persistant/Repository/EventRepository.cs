using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Above_All_Beauty_Pageant.Core.Repositories;

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

    }
}