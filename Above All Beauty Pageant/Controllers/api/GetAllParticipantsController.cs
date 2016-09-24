using Above_All_Beauty_Pageant.Core;
using Above_All_Beauty_Pageant.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Above_All_Beauty_Pageant.Controllers.api
{
    public class GetAllParticipantsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllParticipantsController(IUnitOfWork db)
        {
            _unitOfWork = db;
        }

        [HttpPost]
        public IHttpActionResult GetParticipants(eventsDTO dto)
        {
            var vm = _unitOfWork.Participants.AllParticipantsInCategory(dto.eventName, dto.catValue);
            if (vm != null)
                return Ok(vm);
            else
                return BadRequest();
        }
    }
}
