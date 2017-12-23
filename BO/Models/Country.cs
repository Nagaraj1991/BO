using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BO.Models
{
    public class Country
    {
        public List<SelectListItem> CountryModel { get; set; }
        public int? countryid { get; set; }
        public  string countryname { get; set; }
    }
}