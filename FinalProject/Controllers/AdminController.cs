using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace FinalProject.Controllers
{
    public class AdminController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        List<Course> courses = new List<Course>();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminEntryForm()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "data source=LAPTOP-R1NLRJJL;initial catalog=CIS2103;integrated security=True;";
        }
        public ActionResult AdminEntryCode(admin Admin)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM [admin] WHERE email='" + Admin.email + "' and password='" + Admin.password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View();
            }
            else
            {
                con.Close();
                return RedirectToAction("AdminEntryForm");
            }
        }

        public ActionResult AdminTableForm()
        {
            AdminTableCode();
            return View(courses);
        }

        [HttpPost]
        private void AdminTableCode()
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
                com.CommandText = "SELECT cid,c1,c2,c3,c4,c5,c6,c7,c8,stud_id from units;";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    courses.Add(new Course()
                    {
                        cid = dr["cid"].ToString(),
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
            catch (Exception e)
            {

            }
        }
        public ActionResult AdminEditForm()
        {
            return View();
        }

        public ActionResult AdminEditCode(FormCollection fc)
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

                connectionString();
                con.Open();
                com.Connection = con;
                com.CommandText = "UPDATE units SET c1 = '" + c1 + "',c2 = '" + c2 + "',c3 = '" + c3 + "',c4 = '" + c4 + "',c5 = '" + c5 + "',c6 = '" + c6 + "',c7 = '" + c7 + "',c8 = '" + c8 + "' from units WHERE stud_id = '" + stud_id + "';";

                dr = com.ExecuteReader();
                dr.Read();
                con.Close();
                return RedirectToAction("AdminEditForm");
            }
            return RedirectToAction("AdminEditForm");
        }

        public ActionResult AdminDeleteCode(FormCollection fc)
        {
            int stud_id = Convert.ToInt16(fc["stud_id"]);
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "DELETE FROM units WHERE stud_id = " + stud_id + ";";
            dr = com.ExecuteReader();
            dr.Read();
            con.Close();
            return RedirectToAction("AdminEditForm");
        }
    }
}