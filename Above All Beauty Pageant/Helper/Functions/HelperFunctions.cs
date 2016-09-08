using Above_All_Beauty_Pageant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Above_All_Beauty_Pageant.Helper.Functions
{
    public class HelperFunctions
    {
        public object[] getEnumDisplayAnnotaion(AgeGroup group, int num)
        {
            var enumType = group.GetType();
            var enumValue = Enum.GetName(enumType, num);
            var member = enumType.GetMember(enumValue)[0];

            return member.GetCustomAttributes(typeof(DisplayAttribute), false);
        }
    }
}