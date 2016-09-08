using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Above_All_Beauty_Pageant.DTO
{
    public class categoryDTO
    {
        public int value { get; set; }
        public string group { get; set; }
        public categoryDTO(int v, string g)
        {
            value = v;
            group = g;
        }
    }
}