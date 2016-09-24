using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Above_All_Beauty_Pageant.Persistant.Repository;
using Microsoft.AspNet.Identity;
using Above_All_Beauty_Pageant.Core;
using Above_All_Beauty_Pageant.ViewModels;
using Stripe;

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
            vm.AddParticipant = participant;




            vm.EventNames = _unitOfWork.Events.EventNames();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ParticipantIndexViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index" , vm.AddParticipant);
            }else
            {
                if (!CheckIfParticipantCanParticipateInCategory(vm))
                {
                    return RedirectToAction("Index", vm.AddParticipant);
                }
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

        // method to check if user's age qualifies with age group in which they want to participate in
        public bool CheckIfParticipantCanParticipateInCategory(ParticipantIndexViewModel vm)
        {
            var today = DateTime.UtcNow;
            var age = today.Year - vm.AddParticipant.DOB.Year;

            if (today < vm.AddParticipant.DOB.AddYears(age)) age--;

            if(vm.AddParticipant.Gender == Models.Gender.Female)
            {
                switch (vm.AddParticipant.AgeGroup)
                {
                    case Models.AgeGroup.BabyMiss:
                        if (age < 1) return true;
                        else return false;
                    case Models.AgeGroup.PeeWeeMiss:
                        if (age < 2 && age >= 1) return true;
                        else return false;
                    case Models.AgeGroup.TinyMiss:
                        if (age <= 3 && age >= 2) return true;
                        else return false;
                    case Models.AgeGroup.LittleMiss:
                        if (age <= 5 && age >= 4) return true;
                        else return false;
                    case Models.AgeGroup.PetiteMiss:
                        if (age <= 8 && age >= 6) return true;
                        else return false;
                    case Models.AgeGroup.YouthMiss:
                        if (age <= 12 && age >=9) return true;
                        else return false;
                    case Models.AgeGroup.TeenMiss:
                        if (age <= 15 && age >= 13) return true;
                        else return false;
                    default:
                        return false;
                }
            }
            else
            {
                switch (vm.AddParticipant.AgeGroup)
                {
                    case Models.AgeGroup.BabyMr:
                        if (age < 1) return true;
                        else return false;
                    case Models.AgeGroup.PeeWeeMr:
                        if (age < 2 && age >= 1) return true;
                        else return false;
                    case Models.AgeGroup.TinyMr:
                        if (age <= 3 && age >= 2) return true;
                        else return false;
                    case Models.AgeGroup.LittleMr:
                        if (age <= 5 && age >= 4) return true;
                        else return false;
                    default:
                        return false;
                }
            }

        }

        [HttpGet]
        public ActionResult Payment(string id)
        {
            var userId = User.Identity.GetUserId();
            var participant = _unitOfWork.Participants.GetParticipantById(Convert.ToInt32(id));
            if(participant.UserId == userId)
                return View(new ParticipantViewModel(participant.FirstName, participant.LastName, participant.EventCategory.Category, participant.EventCategory.Event.EventName, participant.Id));

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Payment(string id ,string stripeToken)
        {
            var userId = User.Identity.GetUserId();
            var helper = new Helper.Functions.HelperFunctions();
            var participant = _unitOfWork.Participants.GetParticipantById(Convert.ToInt32(id));
            if (participant.UserId == userId && participant.paid == false)
            {
                try
                {
                    // make payment
                    var Charge = new StripeChargeCreateOptions();

                    Charge.Amount = 9000;
                    Charge.Currency = "usd";
                    Charge.Description = Convert.ToString(participant.Id) + " " + participant.FirstName + " " + participant.LastName;
                    Charge.SourceTokenOrExistingSourceId = stripeToken;
                    Charge.Capture = true;

                    var chargeService = new StripeChargeService();
                    StripeCharge stripeCharge = chargeService.Create(Charge);

                    // set participant's paid prop. to true
                    _unitOfWork.Receipts.PurchaseMade(participant.Id, 90.00, DateTime.Now);
                    _unitOfWork.Participants.ParticipantPaid(participant.Id);
                    _unitOfWork.Complete();

                    // send receipt with thank you email
                    helper.SendEmailNotification(User.Identity.GetUserName(), string.Format("{0} {1}", participant.FirstName, participant.LastName));

                    return RedirectToAction("Transaction", new { TransactionMade = true, id = id });
                }
                catch (StripeException ex)
                {
                    return RedirectToAction("Transaction", new { TransactionMade = false, id = id, error = ex.Message });
                }
                catch (Exception ex)
                {

                    return RedirectToAction("Transaction", new { TransactionMade = true, id = id });
                }
            }

           return View("Index");
        }

        public ActionResult Transaction(bool TransactionMade , int id, string error = "")
        {
            var participant = _unitOfWork.Participants.GetParticipantById(id);
            var vm = new TransactionViewModel(TransactionMade, participant.FirstName, participant.LastName, error, _unitOfWork.Users.GetUsersFullName(User.Identity.GetUserId()) , participant.EventCategory.Event.EventName);
            if (TransactionMade) vm.Receipt = _unitOfWork.Receipts.GetReceipt(id);

            return View(vm);
        }

        [HttpGet]
        public ActionResult ParticipantDetails(int id)
        {
            var participant = _unitOfWork.Participants.GetParticipantById(id);
            var vm = new ParticipantViewModel(participant.FirstName,participant.LastName, participant.Id, participant.HairColor , participant.Hobbies,participant.EyeColor,participant.FavoriteFood,participant.FavoriteColor,participant.Sponsor);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditParticipant(ParticipantViewModel vm ,string id)
        {
            var Id = Convert.ToInt32(id);
            var participant = _unitOfWork.Participants.GetParticipantById(Id);

            participant.Update(vm.EyeColor, vm.FavoriteColor, vm.FavoriteFood, vm.HairColor, vm.Hobbies, vm.Sponsor);
            if (User.Identity.GetUserId() == participant.UserId || User.IsInRole("Admin"))
            {
                _unitOfWork.Complete();
                return RedirectToAction("ParticipantDetails", new { id = Id } );
            }


            return View("Index");
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult GetEveryEventsParticipants(string eventName)
        {
            if(!User.IsInRole("Admin"))
                return View("Index");

            return View(new FullEventDetailsViewModel {EventName = eventName , Details = _unitOfWork.Category.GetDetails(eventName) });
        }
    }
}