
using Above_All_Beauty_Pageant.Core;
using Above_All_Beauty_Pageant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Above_All_Beauty_Pageant.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        private readonly IUnitOfWork _unitOfWork;

        public EventController(IUnitOfWork db)
        {
            _unitOfWork = db;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryDetails(string AgeGroup , string EventName , string Id)
        {
            // get all participants in eventCategory

            var CategoriesParticipants = _unitOfWork.Events.GetCategoryParticipants(  (AgeGroup) Enum.Parse(typeof(AgeGroup) , AgeGroup), EventName);
            CategoriesParticipants[0].SetStaticProp(Convert.ToInt32(Id) , EventName , AgeGroup);
            return View(CategoriesParticipants);
        }
    }
}