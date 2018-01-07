using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BO.Models
{
    public class Country
    {
        public List<City_Detail> City_List { get; set; }
        public List<SelectListItem> CountryModel { get; set; }
        public int? countryid { get; set; }
        public  string countryname { get; set; }
    }
    public class City_Detail
    {
        public long city_id { get; set; }
        public string country_name { get; set; }
        public string city_name { get; set; }
    }
}