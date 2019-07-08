using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using IBll;
using BLL;
using IOC;
using System.Data;
using Newtonsoft.Json;
using System.Transactions;
namespace UI.Controllers.招聘管理.录用管理
{
    /// <summary>
    /// 3.录用查询
    /// </summary>
    public class employ_listController : Controller
    {
        //简历表
        Iengage_resumeBll erBll = IocCreate.CreateBLL<engage_resumeBll>("engage_resumejiaomama", "engage_resumemama");
        //面试表
        Iengage_interviewBll eInvBll = IocCreate.CreateBLL<engage_interviewBll>("engage_interviewjiaomama", "engage_interviewmama");

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            int rows = 0;   //总记录数
            int pages = 0; //总页数
            int currentPage = Convert.ToInt32(Request["currentPage"]);//当前页数
            int pageSize = 2; //每页显示多少条
            List<engage_resume> list = erBll.engage_resumeFenYe(e => e.res_id, e => e.interview_status == 3, out rows, out pages, currentPage, pageSize);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["list"] = list;
            di["rows"] = rows;
            di["pages"] = pages;
            di["pageSize"] = pageSize;
            return Content(JsonConvert.SerializeObject(di));
        }

        //查询显示
        public ActionResult ChaxunIndex()
        {
            int res_id = Convert.ToInt32(Request["res_id"]);//简历id
            ViewBag.listJianli = erBll.engage_resumeWhere(e => e.res_id == res_id);//简历表条件查询
            ViewBag.listMianshi = eInvBll.engage_interviewSelectWhere(e => e.resume_id == res_id);//面试表条件查询
            ViewBag.jianlilushenheyijian = erBll.engage_resumeWhere(e => e.res_id == res_id);//简历表条件查询
            return View();
        }
    }
}