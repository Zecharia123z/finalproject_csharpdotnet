using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using FinalProject.Models;

namespace FinalProject.Controllers
{

    public class UserController : Controller
    {
        // GET: User
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        List<Course> courses = new List<Course>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserAddForm()
        {
            return View();
        }
        public void UserAddCode(FormCollection fc)
        {

            CIS2103Entities2 cis = new CIS2103Entities2();

            String email = fc["email"];
            String password = fc["password"];
            String status = "Student";

            user u = new user();
            u.email = email;
            u.password = password;
            u.status = status;

            cis.users.Add(u);
            cis.SaveChanges();

        }

        public ActionResult UserEntryForm()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "data source=LAPTOP-R1NLRJJL;initial catalog=CIS2103;integrated security=True;";
        }
        public ActionResult UserEntryCode(user User)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM [user] WHERE email='" + User.email + "' and password='" + User.password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View();
            }
            else
            {
                con.Close();
                return RedirectToAction("UserEntryForm");
            }
        }

        
        public void UserTableCode(FormCollection fc)
        {
            CIS2103Entities2 cis = new CIS2103Entities2();
            
            String c1 = fc["c1"];
            String c2 = fc["c2"];
            String c3 = fc["c3"];
            String c4 = fc["c4"];
            String c5 = fc["c5"];
            String c6 = fc["c6"];
            String c7 = fc["c7"];
            String c8 = fc["c8"];
            int stud_id = Convert.ToInt16(fc["stud_id"]);

            if ((c1 == "CIS2101" || c1 == "") && (c2 == "CIS2102" || c2 == "") && (c3 == "CIS2103" || c3 == "") && (c4 == "CIS2104" || c4 == "") && (c5 == "CIS2105" || c5 == "") && (c6 == "CIS2106" || c6 == "") && (c7 == "EDM2" || c7 == "") && (c8 == "TFL" || c8 == ""))
            {
                unit un = new unit();

                un.c1 = c1;
                un.c2 = c2;
                un.c3 = c3;
                un.c4 = c4;
                un.c5 = c5;
                un.c6 = c6;
                un.c7 = c7;
                un.c8 = c8;
                un.stud_id = stud_id;

                cis.units.Add(un);
                cis.SaveChanges();
            }
        }
        

        public ActionResult UserStudyLoad(int? stud_id)
        {
            StudyLoadCode(stud_id);
            return View(courses);
        }

        [HttpPost]
        private void StudyLoadCode(int? stud_id)
        {
            connectionString();
            if (courses.Count > 0)
            {
                courses.Clear();
            }
            
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT c1,c2,c3,c4,c5,c6,c7,c8,stud_id from units WHERE stud_id = (SELECT user_id FROM [user] WHERE user_id = "+stud_id+"); ";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    courses.Add(new Course() { 
                        c1 = dr["c1"].ToString(),
                        c2 = dr["c2"].ToString(), 
                        c3 = dr["c3"].ToString(),
                        c4 = dr["c4"].ToString(),
                        c5 = dr["c5"].ToString(),
                        c6 = dr["c6"].ToString(),
                        c7 = dr["c7"].ToString(),
                        c8 = dr["c8"].ToString(),
                        stud_id = dr["stud_id"].ToString()
                    });
                }
                con.Close();
            }
            catch(Exception e)
            {

            }
        }

        public ActionResult UserChangePass()
        {
            return View();
        }

        public ActionResult UserChangeCode(FormCollection fc)
        {
            String email = fc["email"];
            String password = fc["password"];
            String confirmpassword = fc["confirmpassword"];
            if (password == confirmpassword)
            {
                connectionString();
                con.Open();
                com.Connection = con;
                com.CommandText = "UPDATE [user] SET password = '" + password + "' from units WHERE email = '" + email + "';";
                dr = com.ExecuteReader();
                dr.Read();
                con.Close();
                

            }

            return RedirectToAction("UserChangePass");

        }
    }
}