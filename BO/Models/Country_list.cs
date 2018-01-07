using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BO.Models
{
    public class Country_list
    {
        public List<Country_Detail> Country_lists { get; set; }

    }
    public class Country_Detail
    {
        public long country_id { get; set; }
        public string country_name { get; set; }
    }
}