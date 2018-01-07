using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BO.Models
{
    public class vendor
    {
        public int v_id { get; set; }
        public string v_name { get; set; }
        public string v_address { get; set; }
        public string v_country { get; set; }
        public string v_city { get; set; }
        public string v_area { get; set; }
        public string v_licence { get; set; }
        public string v_contact { get; set; }
        public string v_mail { get; set; }
        public string v_prname { get; set; }
        public string v_prmail { get; set; }
    }
}