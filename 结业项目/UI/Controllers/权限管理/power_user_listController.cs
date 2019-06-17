using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers.权限管理
{
    /// <summary>
    /// 1.用户管理
    /// </summary>
    public class power_user_listController : Controller
    {
        // GET: power_user_list
        public ActionResult Index()
        {
            return View();
        }
    }
}