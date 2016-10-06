using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Above_All_Beauty_Pageant.Models;
using Above_All_Beauty_Pageant.ViewModels;
using Above_All_Beauty_Pageant.Core.Repositories;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace Above_All_Beauty_Pageant.Persistant.Repository
{
    [Authorize]
    public class ParticipantRepository : IParticipantRepository
    {
        private AboveAllContext _context;

        public ParticipantRepository(AboveAllContext db)
        {
            _context = db;
        }

        public Participant GetParticipantById(int id)
        {
            return _context
                .Participants
                .Include(p => p.EventCategory)
                .Include(p => p.EventCategory.Event)
                .FirstOrDefault(p => p.Id == id);
        }


        public List<Participant> GetParticipants(string userId)
        {
            return _context.Participants
                .Where(p => p.UserId == userId)
                .Include(p => p.EventCategory.Event)
                .ToList();
        }

        public ParticipantIndexViewModel GenreateParticipantIndexViewModel(List<Participant> participants)
        {
            ParticipantIndexViewModel vm = new ParticipantIndexViewModel();

            foreach(var participant in participants)
            {
                var EventName = _context
                    .Events
                    .Where(e => e.Id == participant.EventCategory.Event.Id)
                    .Select(e => e.EventName)
                    .FirstOrDefault();

                vm.Participants.Add(new ParticipantViewModel(participant.FirstName,participant.LastName,participant.EventCategory.Category,EventName,participant.Gender,participant.paid, participant.Id));
            }

            return vm;
        }

        public bool AddParticipant(string userId , int categoryId, ParticipantViewModel vm)
        {
            var userStore = new UserStore<ApplicationUser>(_context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            try
            {
                var participant = new Participant(vm.FirstName, vm.LastName, vm.Gender, userId , categoryId, vm.DOB, vm.HairColor, vm.EyeColor,vm.FavoriteColor,vm.FavoriteFood, vm.Hobbies,vm.Sponsor);

                if (userManager.IsInRole(userId, "Admin"))
                {
                    participant.ParticipantPaid();
                }

                _context.Participants.Add(participant);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public void ParticipantPaid(int id)
        {
            _context.Participants.FirstOrDefault(p => p.Id == id).ParticipantPaid();
        }

        public string DeleteParticipant(int id)
        {
            var participantToRemove = _context.Participants.FirstOrDefault(p => p.Id == id);
            var userId = participantToRemove.UserId;
            _context.Participants.Remove(participantToRemove);
            return userId;
        }

        public List<CategoriesParticipantsViewModel> AllParticipantsInCategory(string eventName, int catValue)
        {
            var category = ((AgeGroup)catValue);
            var eventId = _context.Events.FirstOrDefault(e => e.EventName == eventName).Id;
            var participantList = _context.Participants.Where(p => p.EventCategory.Event.Id == eventId &&
                                               p.EventCategory.Category == category).ToList();
            List<CategoriesParticipantsViewModel> vm = new List<CategoriesParticipantsViewModel>();
            foreach(var p in participantList)
            {
                vm.Add(new CategoriesParticipantsViewModel(p.FirstName,p.LastName,p.Id));
            }

            return vm;
        }


    }
}