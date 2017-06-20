using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test0620_Controller.Models;

namespace test0620_Controller.Controllers
{
    public class LabController : Controller
    {
        // GET: Lab
        public ActionResult Index()
        {
            //ViewResult v = new ViewResult();

            return View();
        }

        [ActionName("AboutMe")] // 注意改新名字的Return View括號內 需要修改("about")
        public ActionResult About() { 
            return View("About");
        }

        // [ActionName ("Test")] // ---> 虛擬, 為了前後相容,舊名稱
        public ActionResult TestText() {
            ContentResult result = new ContentResult( );
            result.Content = "Hello! Test";
            result.ContentType = "text/plain";
            return result;
            //return Content("Hello World!");
        }

        public ActionResult TestXML() {
            ContentResult result = new ContentResult();
            result.Content = "<book><title>xxx</title><price>500</price></book>";
            result.ContentType = "text/xml";
            return result;
            //   ------------Test and get content result;
        }

        public ActionResult TestEmpty() {
            return null;  // post back content legth = 0
        }

        [NonAction] //停用
        public ActionResult TestNonAction() {
            return Content("testing");
        }

        public ActionResult TestRedirect() {
            //return Redirect("http://ww.hinet.net"); <---- return Redirect,是轉網址
            return RedirectToAction("TestText", "Lab"); //RedirectToAction,是轉另一個控制器
        }

        public ActionResult TestQueryString() {
            string s = string.Format("firstName={0} lastName={1}",
                Request.QueryString["firstName"],
                Request.QueryString["lastName"]
                );
            return Content(s);
        }

        public ActionResult ShowForm() {
            return View();
        }

        //public ActionResult TestInput(FormCollection frm) {
        //    string s = string.Format("firstName={0} lastName={1}",
        //        frm["firstName"],
        //        frm["lastName"]
        //        );
        //    return Content(s);
        //}

        //public ActionResult TestInput(FormCollection frm) {
        //    string s = string.Format("firstName={0} lastName={1}",
        //        Request["firstName"],
        //        Request["lastName"]
        //        );
        //    return Content(s);
        //}

        //public ActionResult TestInput(string LastName, string FirstName) {
        //    string s = string.Format("firstName={0} lastName={1}",
        //        LastName,
        //        FirstName
        //        );
        //    return Content(s);
        //}

        public ActionResult TestInput(Employee emp) {
            string s = string.Format("firstName={0} lastName={1}",
               emp.LastName,
               emp.FirstName
                );
            return Content(s);
        }

        [HttpGet]
        public ActionResult GetOrPost() {
            return Content("It's Get");
        }

        [HttpPost]
        public ActionResult GetOrPost( string test) {
            return Content("It's a Post");
        }

        [HttpGet]
        public ActionResult Hello() {
            return View();
        }

        [HttpPost]
        public ActionResult Hello(string userName) {
            if (userName == "" || userName == "Guest") {
                return RedirectToAction("Hello");
            }
            ViewData["userName"] = userName;
            return View("SayHello");
            //return Content ( "hello"+userName);
        }

        

  
  


    }
}