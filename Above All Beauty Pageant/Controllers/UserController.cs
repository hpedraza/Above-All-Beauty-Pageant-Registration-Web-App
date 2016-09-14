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

        public ActionResult Index()
        {
            var Participants = _unitOfWork.Participants.GetParticipants(User.Identity.GetUserId());
            var vm = _unitOfWork.Participants.GenreateParticipantIndexViewModel(Participants);

            vm.EventNames = _unitOfWork.Events.EventNames();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ParticipantIndexViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.EventNames = _unitOfWork.Events.EventNames();
                return View("Index" , vm);
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
            if (participant.UserId == userId)
            {
                try
                {
                    // make payment
                    var Charge = new StripeChargeCreateOptions();
                    // always set these properties
                    Charge.Amount = 9000;
                    Charge.Currency = "usd";

                    // set this if you want to
                    Charge.Description = Convert.ToString(participant.Id);

                    Charge.SourceTokenOrExistingSourceId = stripeToken;


                    //|\\__--v ERROR v--__//|\\
                    //Charge.Metadata.Add("ParticipantId", id);

                    // (not required) set this to false if you don't want to capture the charge yet - requires you call capture later
                    Charge.Capture = true;

                    var chargeService = new StripeChargeService();
                    StripeCharge stripeCharge = chargeService.Create(Charge);

                    // send receipt with thank you email and set patitiant bool to paid.
                    _unitOfWork.Participants.ParticipantPaid(participant.Id);
                    _unitOfWork.Complete();
                    helper.SendEmailNotification(User.Identity.GetUserName(), string.Format("{0} {1}", participant.FirstName, participant.LastName));

                    // DIRECT TO PAYMENT HAS BEEN MADE
                    RedirectToAction("Transaction", new { TransactionMade = true, id = id });
                }
                catch (Exception ex)
                {
                    var e = ex;
                    // card has been declined
                    // redirect to credit card is declined
                    RedirectToAction("Transaction", new { TransactionMade = true, id = id });
                }
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult Transaction(bool TransactionMade , int id)
        {


            return View();
        }

    }
}