using Above_All_Beauty_Pageant.Models;
using Above_All_Beauty_Pageant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Above_All_Beauty_Pageant.Core.Repositories
{
    public interface ICategoryRepository
    {
        int GetCategoryIdByName(AgeGroup ageGroup);
        List<EventCategory> GetEventsCategories(string eventName);
        List<DetailsViewModel> GetDetails(string eventName);
    }
}
