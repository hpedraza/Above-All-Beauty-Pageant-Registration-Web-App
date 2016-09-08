using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Above_All_Beauty_Pageant.Persistant.Repository;
using Above_All_Beauty_Pageant.Core.Repositories;

namespace Above_All_Beauty_Pageant.Core
{
    public interface IUnitOfWork
    {
        IEventRepository Events { get;  }
        IParticipantRepository Participants { get; }
        ICategoryRepository Category { get; }
        void Complete();
    }
}
