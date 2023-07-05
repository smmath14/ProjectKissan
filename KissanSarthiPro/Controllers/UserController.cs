using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using KissanSarthi.Models;
using KissanSarthiPro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KissanSarthiPro.Controllers
{
    public class UserController : Controller
    {
       
            static IDbConnection db = new SqlConnection("Data Source=DESKTOP-MUFI4MA;Initial Catalog=Master;Integrated Security=True;MultipleActiveResultSets=True");
            private DbCtx Context { get; set; }


            public UserController(DbCtx context)
            {
                this.Context = context;
            }
            public IActionResult Index()
            {
                return View();
            }
            public IActionResult LoginUser()
            {
                return View();
            }
        [HttpPost]
        public IActionResult LoginUser(Userlog user)
        {
            if (ModelState.IsValid)
            {
                string query = "Select*from UserLog where UserName = @UserName and Password =@Password";
                var log = db.Query<Userlog>(query, user).FirstOrDefault();
                if (log != null)
                {
                    HttpContext.Session.SetInt32("ss", log.UserId);
                    return RedirectToAction("Dashboard", "User");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Inavlid Username and Password");
                    return View(user);
                }

            }
            return View(user);
        }
            public IActionResult Dashboard()
            {
                return View();
            }
            public IActionResult UserInput()

        {
                //List<Country> CountryList = new List<Country>();
                //CountryList = (from Country in this.Context.Country
                //               select Country).ToList();
                //CountryList.Insert(0, new Country { CountryId = 0, CountryName = "Select" });
                //ViewBag.listofcountry = CountryList;
                 Filter obj = new Filter();
                return View(new Agriindex { req = obj});       
            }
            public JsonResult GetState(int CountryId)
            {
                List<State> statelist = new List<State>();
                statelist = (from State in this.Context.State
                             where State.CountryId == CountryId
                             select State).ToList();
             statelist.Insert(0, new State { StateId = 0, StateName = "Select" });
            return Json(new SelectList(statelist, "StateId", "StateName"));
            }
            public JsonResult GetCity(int StateId)
            {
                List<City> citylist = new List<City>();
                citylist = (from City in this.Context.City
                            where City.StateId == StateId
                            select City).ToList();
            citylist.Insert(0, new City { CityId = 0, CityName = "Select" });
            return Json(new SelectList(citylist, "CityId", "CityName"));

            }


          //[HttpPost]
          //  public IActionResult UserInput(Filter req,UserInput pos /*,Country cc, IFormCollection fc*/)
          //  {
            //if(cc.CountryId == 0)
            //{
            // ModelState.AddModelError("", "Select Country");
            //}
            //if(cc.StateId == 0)
            //{
            // ModelState.AddModelError("", "Select State");
            //}
            //if(cc.CityId == 0)
            //{
            // ModelState.AddModelError("", "Select City");
            //}
            // var StateId = HttpContext.Request.Form["StateId"].ToString();
            //  var CityId = HttpContext.Request.Form["CityId"].ToString();
            // List<Country> CountryList = new List<Country>();
            // CountryList = (from Country in this.Context.Country
            //                select Country).ToList();
            // CountryList.Insert(0, new Country { CountryId = 0, CountryName = "Select" });
            // ViewBag.listofcountry = CountryList;
            //string query = "Insert into UserFilterShow (Id,UserId,Country ,State, City , Pincode ,Area_of_land ,Type_of_Crops,Categories_of_Crops,Weather,SoilType ,Temperature,Pesticide,Water,Seeds,Cost)  select Id,UserId,Country ,State, City , Pincode ,Area_of_land ,Type_of_Crops,Categories_of_Crops,Weather,SoilType ,Temperature,Pesticide,Water,Seeds,Cost  from UserFilter ";
            //string query = "Select*Into UserFilterShow from UserFilter(1)";
            //db.Execute(query,AgriShow);


            //string query1 = "truncate table UserFilterShow";
            //db.Execute(query1, null);
            //List<UserInput> AgriShow = this.Context.SearchAgri(req).ToList();
            //return RedirectToAction("UserFilterShow","User",new { AgriShow });
            //return View();
            //}
        [HttpPost]
            public IActionResult UserFilterShow(Filter req, UserInput pos)
            {
                     string query1 = "truncate table UserFilterShow";
                     db.Execute(query1, null);
                     List<UserInput> AgriShow = this.Context.SearchAgri(req).ToList();
                     return View(new Agriindex{ AgriShow = AgriShow, req =req});
            
            }


        
        public IActionResult NewUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewUser(NewUser Ul)
        {
            if (ModelState.IsValid)
            {
                if (Ul.ConfirmPassword == Ul.Password)
                {

                    string query = "Insert into UserLog (FirstName,LastName,UserName,Password,ConfirmPassword,PhoneNo) values(@FirstName,@LastName,@Username,@Password,@ConfirmPassword,@PhoneNo)";

                    string query2 = "Select* from UserLog where UserName =@UserName";
                    var log = db.Query<Userlog>(query2, Ul).FirstOrDefault();
                    if (log != null && log.UserName == Ul.UserName)
                    {
                        ModelState.AddModelError(string.Empty, "Username Already Used.. Please Try Another ");
                    }
                    else
                    {

                        db.Execute(query, Ul);
                        return RedirectToAction("LoginUser", "User");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Password and Confirm Password Not Matched");
                    return View("NewUser");
                }

            }

            return View(Ul);
        }
        public IActionResult FarmInfo(int id)
        {
            ViewBag.Id =  HttpContext.Session.GetInt32("ss");

            string query = "Select*from FarmInfo where UserId =@UserId";
            var std = db.Query<FarmInfo>(query, new { UserId = ViewBag.Id }).ToList();
            return View(std);
        }
        public IActionResult FarmCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FarmCreate(FarmInfo fi)
        {
            string query = "Insert into FarmInfo (FarmName,FirstName,LastName,UserName,Country,State,City,Pincode,FarmSize,Date_of_Created, Current_State) values(@FarmName,@FirstName,@LastName,@UserName,@Country,@State,@City,@Pincode,@FarmSize,@Date_of_Created,@Current_State)";
            db.Execute(query, new {fi.FarmName,fi.FirstName,fi.LastName,fi.UserName,fi.Country,fi.State,fi.City,fi.Pincode,fi.FarmSize,fi.Date_of_Created,fi.Current_State });
            string query2 = "Update FarmInfo Set FarmInfo.UserId = UserLog.UserId  from FarmInfo, UserLog where FarmInfo.UserName = UserLog.UserName ";
            db.Query(query2, null);
            return RedirectToAction("FarmInfo");
        }
        public IActionResult FarmEdit(int id)
        {
            string query = "Select *from FarmInfo where Id =@Id";
            var cc = db.Query<FarmInfo>(query, new { Id = id }).FirstOrDefault();
            return View(cc);
        }
        [HttpPost]
        public IActionResult FarmEdit(FarmInfo fi)
        {
            string query = "update FarmInfo set FarmName = @FarmName,FirstName=@FirstName,LastName=@LastName,UserName=@UserName,Country=@Country,State=@State,City=@City,Pincode=@Pincode,FarmSize=@FarmSize,Date_of_Created=@Date_of_Created,Current_State=@Current_State";
            db.Execute(query, fi);
            return RedirectToAction("FarmInfo");
        }
        public IActionResult FarmDelete(int id)
        {

            string query = "Delete from FarmInfo where Id = @Id";
            var data = db.Query<FarmInfo>(query, new { Id = id }).FirstOrDefault();
            return RedirectToAction("FarmInfo");

        }
        public IActionResult Feedback()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Feedback(Feedback fb)
        {
            string query = "Insert into Feedback(UserName,FirstName,LastName,DateofCreated,Message) values(@UserName,@FirstName,@LastName,GetDate(),@Message)";
            db.Execute(query, fb);
            return RedirectToAction("Dashboard");
        }
        public IActionResult AddData()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddData(UserInput ui)
        {
            string query = "Insert into UserInput (UserId, Country, State, City, Pincode,Area_of_land,Type_of_Crops,Weather,SoilType,Temperature,Pesticide,Water,Seeds,Cost,Categories_of_Crops) values(@UserId, @Country, @State, @City, @Pincode,@Area_of_land,@Type_of_Crops,@Weather,@SoilType,@Temperature,@Pesticide,@Water,@Seeds,@Cost,@Categories_of_Crops)";
            var log = db.Execute(query, ui);
            return View(ui);
        }
        //public IActionResult AddCity()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult AddCity(City cs)
        //{
        //    string query = "Insert into City (StateId,CityName) values(@StateId,@CityName)";
        //    var log = db.Execute(query, cs);
        //    return View(cs);
        //}
       
    }

}

