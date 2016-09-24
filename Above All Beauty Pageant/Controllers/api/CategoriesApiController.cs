using Above_All_Beauty_Pageant.Core;
using Above_All_Beauty_Pageant.DTO;
using Above_All_Beauty_Pageant.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Above_All_Beauty_Pageant.Helper.Functions;
using System.Web.Http;
using System.Web.Script.Serialization;


namespace Above_All_Beauty_Pageant.Controllers.api
{
    [Authorize]
    public class CategoriesApiController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;


        public CategoriesApiController(IUnitOfWork db)
        {
            _unitOfWork = db;
        }



        [HttpPost]
        public IHttpActionResult getCategories(eventsDTO dto)
        {
            try {
                var helper = new HelperFunctions();

                // get all of an event's AgeGroup names
                var categoryList = _unitOfWork.Category.GetEventsCategories(dto.eventName);
                var AgeGroupList = categoryList.Select(c => c.Category);
                var catNames = new List<object>();
                // Get all of categories 'Display Name'
                foreach (var group in AgeGroupList)
                {
                    var num = (int)group;

                    var attrs = helper.getEnumDisplayAnnotaion(group , num);
                    categoryDTO categoryDTO = new categoryDTO(num , ((DisplayAttribute)attrs[0]).Name);
                    catNames.Add(categoryDTO);
                }

               return Ok(new JavaScriptSerializer().Serialize(catNames));
            }
            catch 
            {
                return BadRequest();
            }

        }


    }
}