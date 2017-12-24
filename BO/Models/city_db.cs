using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Configuration;
using System.Data;

namespace BO.Models
{
    public class city_db
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
        
        public DataSet getCountry()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select country_name from tbl_country ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            return ds;
            
        }
        public DataSet getCity(string CountryName)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select city_name from tbl_city where country_name='" + CountryName + "'",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            return ds;
        }

        public DataSet getArea(string CityName)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select area_name from tbl_area where country_name='" + CityName + "'",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            return ds;
        }
    }
}