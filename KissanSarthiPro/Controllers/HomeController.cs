using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KissanSarthiPro.Models;
using System.Data;
using System.Data.SqlClient;
using KissanSarthi.Models;
using Dapper;

namespace KissanSarthiPro.Controllers
{
    public class HomeController : Controller
    {
        
        static IDbConnection db = new SqlConnection("Data Source=DESKTOP-MUFI4MA;Initial Catalog=Master;Integrated Security=True;MultipleActiveResultSets=True");
        private DbCtx Context { get; set; }


        public HomeController(DbCtx context)
        {
            this.Context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LoginAdmin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginAdmin(AdminLog admin)
        {
            if (ModelState.IsValid)
            {
                string query = "Select*from AdminLog where AdminName = @AdminName and Password = @Password";
                var log = db.Query<AdminLog>(query, admin).FirstOrDefault();
                if (log != null)
                {
                    return RedirectToAction("AdminDashboard");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Inavlid Username and Password");
                    return View(admin);
                }
            }
            return View(admin);

        }
        public IActionResult AdminDashboard()
        {
            return View();
        }
        public IActionResult AddData()
        {
            return View();
        }
       [HttpPost]
        public IActionResult AddData(UserInput Ui)
        {
            string query = "Insert into UserInput (Country,State,City,Pincode,Area_of_land,Type_of_Crops,Weather,SoilType,Temperature,Pesticide,Water,Seeds,Cost,Categories_of_Crops) values(@Country,@State,@City,@Pincode,@Area_of_land,@Type_of_Crops,@Weather,@SoilType,@Temperature,@Pesticide,@Water,@Seeds,@Cost,@Categories_of_Crops)";
            db.Execute(query, Ui);
            string query2 = "Update UserInput Set UserId = Id";
            db.Execute(query2, Ui);
            return RedirectToAction("Dashboard");
        }
        public IActionResult Feedback()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Feedback(AdminTicket At)
        {
            string query = "Insert into AdminTicket (AdminName,TicketId,DateofCreated,Message) values(@AdminName,@TicketId,GetDate(),@Message)";
            db.Execute(query, At);
            return View();
        }
   
        public IActionResult Delete(int id)
        {
            string query = "delete from Feedback where Id =@Id";
            var data = db.Query<Feedback>(query ,new { Id = id }).FirstOrDefault();
            return RedirectToAction("Grievance");

        }
        //public IActionResult Details(int id)
        //{
         //   string query = "select*from FeedId where Id =@Id";
//var data = db.Query<>
       //S }
        public IActionResult Grievance()
        {
            string query = "Select*from Feedback";
            var std = db.Query<Feedback>(query, null).ToList();
            return View(std);
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
