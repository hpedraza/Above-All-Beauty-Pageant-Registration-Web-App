using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Above_All_Beauty_Pageant.Models
{
    public class Address
    {
        public int Id { get; set; }

        public string Street { get; set; }

        [MaxLength(22)]
        public string City { get; set; }

        [MaxLength(2)]
        public string State { get; set; }

        public int ZipCode { get; set; }
    }
}