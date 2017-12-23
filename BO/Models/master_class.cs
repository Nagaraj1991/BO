using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
namespace BO.Models
{
    public class master_class
    {
        public string country_name { get; set; }

        [Required(ErrorMessage ="Please Enter Country Name")]
        [Display(Name="Enter Country Name")]
        [StringLength(50,MinimumLength =2,ErrorMessage ="Minimum Two Letters Required")]

        public string city_name { get; set; }
        [Required(ErrorMessage = "Please Enter City Name")]
        [Display(Name = "Enter City Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Minimum Two Letters Required")]

        public string area_name { get; set; }
        [Required(ErrorMessage = "Please Enter Area Name")]
        [Display(Name = "Enter Area Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Minimum Two Letters Required")]

        public int country_id { get; set; }
        public int city_id { get; set; }
        public int area_id { get; set; }
    }
}