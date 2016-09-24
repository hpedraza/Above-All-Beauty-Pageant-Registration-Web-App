using Above_All_Beauty_Pageant.Models;
using Above_All_Beauty_Pageant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Above_All_Beauty_Pageant.Core.Repositories
{
    public interface IParticipantRepository
    {
        List<Participant> GetParticipants(string userId);
        ParticipantIndexViewModel GenreateParticipantIndexViewModel(List<Participant> participants);
        bool AddParticipant(string userId, int categoryId, ParticipantViewModel participantViewModel);
        Participant GetParticipantById(int id);
        void ParticipantPaid(int id);
        string DeleteParticipant(int id);
        List<CategoriesParticipantsViewModel> AllParticipantsInCategory(string eventName, int catValue);

    }
}
