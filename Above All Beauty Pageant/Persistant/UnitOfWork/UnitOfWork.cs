using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Above_All_Beauty_Pageant.Models;
using Above_All_Beauty_Pageant.Core;
using Above_All_Beauty_Pageant.Core.Repositories;
using Above_All_Beauty_Pageant.Persistant.Repository;

namespace Above_All_Beauty_Pageant.Persistant
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AboveAllContext _context;
        public IParticipantRepository Participants { get; private set; }
        public IEventRepository Events { get; private set; }
        public ICategoryRepository Category { get; private set; }

        public UnitOfWork(AboveAllContext db)
        {
            _context = db;
            Participants = new ParticipantRepository(db);
            Events = new EventRepository(db);
            Category = new CategoryRespository(db);

        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}