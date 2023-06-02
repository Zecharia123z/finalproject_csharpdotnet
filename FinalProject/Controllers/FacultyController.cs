using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Faculty
{
    public class FacultyController : Controller
    {
        // GET: Faculty
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        List<Course> courses = new List<Course>();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FacultyEntryForm()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "data source=LAPTOP-R1NLRJJL;initial catalog=CIS2103;integrated security=True;";
        }
        public ActionResult FacultyEntryCode(faculty Faculty)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM faculty WHERE email='" + Faculty.email + "' and password='" + Faculty.password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View();
            }
            else
            {
                con.Close();
                return RedirectToAction("FacultyEntryForm");
            }
        }
        public ActionResult FacultyAddForm()
        {
            return View();
        }

        public void FacultyAddCode(FormCollection fc)
        {
            CIS2103Entities2 cis = new CIS2103Entities2();

            String email = fc["email"];
            String password = fc["password"];
            String status = "Faculty";

            faculty f = new faculty();
            f.email = email;
            f.password = password;
            f.status = status;

            cis.faculties.Add(f);
            cis.SaveChanges();

        }

        public ActionResult FacultyC1()
        {
            FacultyC1Code();
            return View(courses);
        }

        [HttpPost]
        public void FacultyC1Code()
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
                com.CommandText = "SELECT c1,stud_id from units WHERE c1 > '';";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    courses.Add(new Course()
                    {
                        c1 = dr["c1"].ToString(),
                        stud_id = dr["stud_id"].ToString()
                    });
                }
                con.Close();
            }
            catch (Exception e)
            {

            }
        }

        public ActionResult FacultyC2()
        {
            FacultyC2Code();
            return View(courses);
        }

        [HttpPost]
        public void FacultyC2Code()
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
                com.CommandText = "SELECT c2,stud_id from units WHERE c2 > '';";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    courses.Add(new Course()
                    {
                        c2 = dr["c2"].ToString(),
                        stud_id = dr["stud_id"].ToString()
                    });
                }
                con.Close();
            }
            catch (Exception e)
            {

            }
        }

        public ActionResult FacultyC3()
        {
            FacultyC3Code();
            return View(courses);
        }

        [HttpPost]
        public void FacultyC3Code()
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
                com.CommandText = "SELECT c3,stud_id from units WHERE c3 > '';";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    courses.Add(new Course()
                    {
                        c3 = dr["c3"].ToString(),
                        stud_id = dr["stud_id"].ToString()
                    });
                }
                con.Close();
            }
            catch (Exception e)
            {

            }
        }

        public ActionResult FacultyC4()
        {
            FacultyC4Code();
            return View(courses);
        }

        [HttpPost]
        public void FacultyC4Code()
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
                com.CommandText = "SELECT c4,stud_id from units WHERE c4 > '';";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    courses.Add(new Course()
                    {
                        c4 = dr["c4"].ToString(),
                        stud_id = dr["stud_id"].ToString()
                    });
                }
                con.Close();
            }
            catch (Exception e)
            {

            }
        }

        public ActionResult FacultyC5()
        {
            FacultyC5Code();
            return View(courses);
        }

        [HttpPost]
        public void FacultyC5Code()
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
                com.CommandText = "SELECT c5,stud_id from units WHERE c5 > '';";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    courses.Add(new Course()
                    {
                        c5 = dr["c5"].ToString(),
                        stud_id = dr["stud_id"].ToString()
                    });
                }
                con.Close();
            }
            catch (Exception e)
            {

            }
        }

        public ActionResult FacultyC6()
        {
            FacultyC6Code();
            return View(courses);
        }

        [HttpPost]
        public void FacultyC6Code()
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
                com.CommandText = "SELECT c6,stud_id from units WHERE c6 > '';";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    courses.Add(new Course()
                    {
                        c6 = dr["c6"].ToString(),
                        stud_id = dr["stud_id"].ToString()
                    });
                }
                con.Close();
            }
            catch (Exception e)
            {

            }
        }

        public ActionResult FacultyC7()
        {
            FacultyC7Code();
            return View(courses);
        }

        [HttpPost]
        public void FacultyC7Code()
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
                com.CommandText = "SELECT c7,stud_id from units WHERE c7 > '';";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    courses.Add(new Course()
                    {
                        c7 = dr["c7"].ToString(),
                        stud_id = dr["stud_id"].ToString()
                    });
                }
                con.Close();
            }
            catch (Exception e)
            {

            }
        }

        public ActionResult FacultyC8()
        {
            FacultyC8Code();
            return View(courses);
        }

        [HttpPost]
        public void FacultyC8Code()
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
                com.CommandText = "SELECT c8,stud_id from units WHERE c8 > '';";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    courses.Add(new Course()
                    {
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
    }
}