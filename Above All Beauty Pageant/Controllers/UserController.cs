using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Above_All_Beauty_Pageant.Persistant.Repository;
using Microsoft.AspNet.Identity;
using Above_All_Beauty_Pageant.Core;
using Above_All_Beauty_Pageant.ViewModels;

namespace Above_All_Beauty_Pageant.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index(ParticipantViewModel participant = null)
        {
            var Participants = _unitOfWork.Participants.GetParticipants(User.Identity.GetUserId());
            var vm = _unitOfWork.Participants.GenreateParticipantIndexViewModel(Participants);
        
            if (participant != null)
                vm.AddParticipant = participant;

            vm.EventNames = _unitOfWork.Events.EventNames();
            return View(vm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddParticipant(ParticipantIndexViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", vm.AddParticipant);
            }

            var userId = User.Identity.GetUserId();

            var categoryId = _unitOfWork.Category.GetCategoryIdByName(vm.AddParticipant.AgeGroup);

            // add participant to event and save if successful
            if (_unitOfWork.Participants.AddParticipant(userId, categoryId, vm.AddParticipant))
            {
                _unitOfWork.Complete();

            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Payment(string id)
        {
            
            var participant = _unitOfWork.Participants.GetParticipantById(Convert.ToInt32(id));

            return View(new ParticipantViewModel(participant.FirstName,participant.LastName,participant.EventCategory.Category,participant.EventCategory.Event.EventName,participant.Id));
        }

    }
}