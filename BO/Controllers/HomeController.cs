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
        public ActionResult Index()
        {
            return View();
            
        }


        public ActionResult Dashboard()
        {

            return View();
        }
        public ActionResult AreaMaster()
        {
            Country cc = new Country();
            cc.CountryModel = PopulateCountry();
            return View(cc);
            
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
            return View(cc);
        }

        public ActionResult CountryMaster()
        {
            
            return View();
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