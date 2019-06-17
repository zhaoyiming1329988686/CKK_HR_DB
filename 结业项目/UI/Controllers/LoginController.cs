using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IBll;
using BLL;
using IOC;
using Model;
using System.Data;

namespace UI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        IUsersBll uuBll = IocCreate.CreateBLL<UsersBll>("Usersjiaomama", "Usersmama");
        /// <summary>
        /// 登陆控制器
        /// </summary>
        /// <returns></returns>
        /// 1.登陆

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login2()
        {
            string name = Request["name"];
            string pwd = Request["pwd"];
            List<users> list = uuBll.Login(e => e.u_name == name && e.u_password == pwd);
            if (list[0].u_name!=null && list[0].u_password!=null)
            {
                return Content("<script>alert('登陆成功！');window.location.href='/Login/ShouYeIndex'</script>"); 
            }
            else
            {
                return Content("<script>alert('登陆失败！');window.location.href='/Login/Login'</script>");

            }
                
             
        }

        // 2.首页
        public ActionResult ShouYeIndex()
        {
            return View();
        }
        // 3.左边选择页
        public ActionResult left()
        {
            return View();
        }
        // 4.头部页
        public ActionResult top()
        {
            return View();
        }

        // 5.中间
        public ActionResult main()
        {
            return View();
        }


    }
}
