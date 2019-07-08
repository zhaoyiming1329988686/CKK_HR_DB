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
using Newtonsoft.Json;
namespace UI.Controllers.招聘管理.职业发布管理
{
    /// <summary>
    /// 3.职位发布查询
    /// </summary>
    public class position_release_searchController : Controller
    {

        // GET: position_release_search

        //职位发表登记表
        Iengage_major_releaseBll emrBll = IocCreate.CreateBLL<engage_major_releaseBll>("engage_major_releasejiaomama", "engage_major_releasemama");
        //申请该职位则跳转到简历登记功能点。
        //1.查询

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
            List<engage_major_release> list = emrBll.engage_major_releaseSelectFenYe(e => e.major_id, e => e.mre_id > 0, out rows, out pages, currentPage, pageSize);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["list"] = list;
            di["rows"] = rows;
            di["pages"] = pages;
            di["pageSize"] = pageSize;
            return Content(JsonConvert.SerializeObject(di));
        }


        public ActionResult ShenqingIndex(int mre_id)
        {
            List<engage_major_release> list = emrBll.engage_major_releaseUpdateSelect(e=>e.mre_id==mre_id);
            return View(list);
        }
    }
}