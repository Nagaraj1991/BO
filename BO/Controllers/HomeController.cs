using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.SqlClient;
using System.Configuration;
using BO.Models;
using System.Data;
namespace BO.Controllers
{
    public class HomeController : Controller
    {
        string cname1;
        BO.Models.city_db cd = new BO.Models.city_db();

        public ActionResult Index()
        {
            return View();
            
        }
        [HttpPost]
        public ActionResult Index(string Username, string password)
        {
            if (Username == "1" && password == "1")
            {
               return Redirect("/Home/Dashboard");
            }
            else
            {
                ViewBag.Message = "Worng Password";
            }
            return View();

        }

        public void country_bind()
        {
            DataSet ds = cd.getCountry();
            List<SelectListItem> coutrylist = new List<SelectListItem>();

            foreach (DataRow dr in ds.Tables[0].Rows)

            {

                coutrylist.Add(new SelectListItem { Text = dr["country_name"].ToString(), Value = dr["country_name"].ToString() });

            }

            ViewBag.Country = coutrylist;

        }
        
        public JsonResult city_Bind(string country_id)

        {

            DataSet ds = cd.getCity(country_id);

            List<SelectListItem> citylist = new List<SelectListItem>();

            foreach (DataRow dr in ds.Tables[0].Rows)

            {

                citylist.Add(new SelectListItem { Text = dr["city_name"].ToString(), Value = dr["city_name"].ToString() });

            }

            return Json(citylist, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Area_Bind(string city_id)

        {

            DataSet ds = cd.getArea(city_id);

            List<SelectListItem> arealist = new List<SelectListItem>();

            foreach (DataRow dr in ds.Tables[0].Rows)

            {

                arealist.Add(new SelectListItem { Text = dr["area_name"].ToString(), Value = dr["area_name"].ToString() });

            }

            return Json(arealist, JsonRequestBehavior.AllowGet);

        }


        public ActionResult Dashboard()
        {

            return View();
        }
        public ActionResult AreaMaster()
        {
            country_bind();
            return View();
            
        }
        public ActionResult AddVendor() 
        {

            return View();
        }
        public ActionResult PendingRequest()
        {

            return View();
        }
        public ActionResult CityMaster()
        {
            Country cc = new Country();
            cc.CountryModel = PopulateCountry();
            List<City_Detail> cd = new List<City_Detail>();
            cd = getcity();
            cc.City_List = cd;
            return View(cc);
        }

        public ActionResult CountryMaster()
        {
            Country_list cl = new Country_list();
            List<Country_Detail> cll = new List<Country_Detail>();
            cll = getcountry();
            cl.Country_lists = cll;

            return View(cl);
        }


        public List<Country_Detail> getcountry()
        {
            List<Country_Detail> objStudent = new List<Country_Detail>();
            /*Create instance of entity model*/
            Restaurent_BOEntities2 objentity = new Restaurent_BOEntities2();
            /*Getting data from database for user validation*/
            var _objuserdetail = (from data in objentity.tbl_country
                                  select data);
            foreach (var item in _objuserdetail)
            {
                objStudent.Add(new Country_Detail { country_id = item.country_id, country_name = item.country_name });
            }
            return objStudent;
        }

        public List<City_Detail> getcity()
        {
            List<City_Detail> objStudent = new List<City_Detail>();
            /*Create instance of entity model*/
            Restaurent_BOEntities1 objentity = new Restaurent_BOEntities1();
            /*Getting data from database for user validation*/
            var _objuserdetail = (from data in objentity.tbl_city
                                  select data);
            foreach (var item in _objuserdetail)
            {
                objStudent.Add(new City_Detail { city_id = item.city_id, country_name = item.country_name,city_name=item.city_name });
            }
            return objStudent;
        }

        [HttpPost]
        public ActionResult CityMaster(string cname,string countryname)
        {
            //getcoun();
            SqlConnection con = null;
            string result;

            
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
            SqlCommand cmd = new SqlCommand("master_crud", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@country_name", countryname);
            cmd.Parameters.AddWithValue("@mode", 12);
            cmd.Parameters.AddWithValue("@city_name", cname);
            con.Open();
            ViewData["result"] = cmd.ExecuteNonQuery().ToString();
            Country cc = new Country();
            cc.CountryModel = PopulateCountry();
            return View(cc);
        }

        [HttpPost]
        public ActionResult CountryMaster(string cou,string cop)
        {
            //ViewData["result"] = cou;
            SqlConnection con = null;
            string result;

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
            SqlCommand cmd = new SqlCommand("master_crud", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@country_name", cou);
            cmd.Parameters.AddWithValue("@mode", 11);
            cmd.Parameters.AddWithValue("@cur_pair", cop);
            con.Open();
            ViewData["result"] = cmd.ExecuteNonQuery().ToString();
            //TempData["msg"] = "<script>alert('Successfully Inserted');</script>";
            //ViewData["result"] = result.ToString();
            return View();
        }

        
        private static List<SelectListItem> PopulateCountry()
        {
            List<SelectListItem> item = new List<SelectListItem>();
            try
            {
                
                string constr = ConfigurationManager.ConnectionStrings["Constring"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "select country_name from tbl_country";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while(sdr.Read())
                            {
                                item.Add(new SelectListItem
                                {
                                    
                                    Value = sdr["country_name"].ToString(),
                                    Text = sdr["country_name"].ToString()
                                });
                            }
                        }
                        con.Close();
                        
                    }
                }
                
            }
            catch(Exception ex)
            {

            }
            return item;
            
        }

        private static List<SelectListItem> PopulateCity()
        {
            List<SelectListItem> item = new List<SelectListItem>();
            try
            {

                string constr = ConfigurationManager.ConnectionStrings["Constring"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "select country_name from tbl_country";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                item.Add(new SelectListItem
                                {

                                    Value = sdr["country_name"].ToString(),
                                    Text = sdr["country_name"].ToString()
                                });
                            }
                        }
                        con.Close();
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return item;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }

}