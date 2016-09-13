using Above_All_Beauty_Pageant.Core;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Above_All_Beauty_Pageant.Controllers.api
{
    [Authorize]
    public class ParticipantController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public ParticipantController(IUnitOfWork db)
        {
            _unitOfWork = db;
        }

        [HttpDelete]
        public IHttpActionResult DeleteParticipant(int id)
        {
            try
            {
                var participantId = Convert.ToInt32(id);
                var userId =_unitOfWork.Participants.DeleteParticipant(participantId);

                if (User.Identity.GetUserId() == userId)
                {
                    _unitOfWork.Complete();
                    return Ok();
                }

            }
            catch
            {
                return BadRequest();
            }

            return BadRequest();

        }
    }
}
