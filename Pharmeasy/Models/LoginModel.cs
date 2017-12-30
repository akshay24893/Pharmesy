using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pharmeasy.Models
{
    public class LoginModel
    {
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string user { get; set; }
        public int IsValid(string _username, string _pwd, string usr)

        {
            string _sql = "";
            if (usr.Equals("UserDatas"))
            {
                _sql = "Select user_id From UserData Where usr_email='" + _username + "' And password='" + _pwd + "'";
            }
            else if (usr.Equals("DoctorDatas"))
            {
                _sql = "Select doc_id From DoctorData Where doc_email='" + _username + "' And password='" + _pwd + "'";
            }
            else if (usr.Equals("Pharmacists"))
            {
                _sql = "Select pharmacist_id From Pharmacist Where ph_email='" + _username + "' And password='" + _pwd + "'";
            }
            SqlConnection cn = new SqlConnection(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\Pharmesy.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");

            cn.Open();

            SqlCommand cmd = new SqlCommand(_sql, cn);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                return (int)dr.GetValue(0);
            }
            else
                return 0;
        }
    }
}