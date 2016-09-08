using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Above_All_Beauty_Pageant.Core.Repositories
{
    public interface IEventRepository
    {
        List<string> EventNames();
        int GetEventIdByName(string eventName);
    }
}
