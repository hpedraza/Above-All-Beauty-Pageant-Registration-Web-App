using Above_All_Beauty_Pageant.Core.Repositories;
using Above_All_Beauty_Pageant.Models;
using Above_All_Beauty_Pageant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Above_All_Beauty_Pageant.Persistant.Repository
{
    public class CategoryRespository : ICategoryRepository
    {
        private AboveAllContext _context;

        public CategoryRespository(AboveAllContext db)
        {
            _context = db;
        }

        public int GetCategoryIdByName(AgeGroup group)
        {
            return _context.Categories.FirstOrDefault(c => c.Category == group).Id;
        }

        public List<EventCategory> GetEventsCategories(string eventName)
        {
            try {
                return _context.Categories.Where(c => c.Event.EventName == eventName).ToList();
            } catch {
                return new List<EventCategory>();
            }

        }

        public List<DetailsViewModel> GetDetails(string eventName)
        {
            var categories = _context.Categories
                .Include(c => c.Participants)
                .Where(c => c.Event.EventName == eventName)
                .ToList();

            List<DetailsViewModel> DetailsList = new List<DetailsViewModel>();

            foreach (var category in categories)
            {
                DetailsList.Add(new DetailsViewModel(category.Category, category.Participants.ToList()));
            }

            return DetailsList;
        }

    }
}