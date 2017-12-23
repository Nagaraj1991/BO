using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BO.Models
{
    public class City
    {
        public City()
        {
            this.Countries = new List<SelectListItem>();
            this.Cities = new List<SelectListItem>();

        }
        public List<SelectListItem>Countries { get; set; }
        public List<SelectListItem> Cities { get; set; }

        public string country_name { get; set; }
        public string city_name { get; set; }
    }
}