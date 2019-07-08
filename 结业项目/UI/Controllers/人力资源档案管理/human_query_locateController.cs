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
namespace UI.Controllers.人力资源档案管理
{
    /// <summary>
    /// 3.人力资源档案查询
    /// </summary>
    public class human_query_locateController : Controller
    {
        //一级机构表
        Iconfig_file_first_kindBll cffkBll = IocCreate.CreateBLL<config_file_first_kindBll>("config_file_first_kindjiaomama", "config_file_first_kindmama");
        //二级机构表
        Iconfig_file_second_kindBll cfskBll = IocCreate.CreateBLL<config_file_second_kindBll>("config_file_second_kindjiaomama", "config_file_second_kindmama");
        //三级机构表
        Iconfig_file_third_kindBll cftkBll = IocCreate.CreateBLL<config_file_third_kindBll>("config_file_third_kindjiaomama", "config_file_third_kindmama");
        //职位分类表
        Iconfig_major_kindBll cmkBll = IocCreate.CreateBLL<config_major_kindBll>("config_major_kindjiaomama", "config_major_kindmama");
        //职位表
        Iconfig_majorBll cmBll = IocCreate.CreateBLL<config_majorBll>("config_majorjiaomama", "config_majormama");
        //人力资源信息表
        Ihuman_fileBll hhff = IocCreate.CreateBLL<human_fileBll>("human_filejiaomama", "human_filemama");
        /// <summary>
        /// 1.查询
        /// </summary>
        /// <returns></returns>
        public ActionResult ChaXunIndex()
        {
            ViewBag.yiji = cffkBll.Xialakuangchaxun();
            ViewBag.fenlei = cmkBll.Xialakuangchaxun();
            return View();
        }

        public ActionResult IndexCXMianshi()
        {
            return View();
        }
        //二级下拉框查询
        public ActionResult chaxun2()
        {
            string firstKindId = Request["firstKindId"];
            List<config_file_second_kind> list = cfskBll.TiaojianChaXun(e => e.first_kind_id == firstKindId).ToList();//二级机构表

            return Content(JsonConvert.SerializeObject(list));

        }
        //三级查询
        public ActionResult chaxun3()
        {
            string secondKindId = Request["secondKindId"];
            List<config_file_third_kind> list = cftkBll.TiaojianChaXun(e => e.second_kind_id == secondKindId).ToList();//三级机构表

            return Content(JsonConvert.SerializeObject(list));

        }

        //职位查询
        public ActionResult chaxun4()
        {
            string majorKindId = Request["majorKindId"];
            List<config_major> list = cmBll.TiaojianChaXun(e => e.major_kind_id == majorKindId).ToList();//三级机构表
            return Content(JsonConvert.SerializeObject(list));

        }







        //查询显示
        public ActionResult IndexCXMianshi2()
        {
            int rows = 0;   //总记录数
            int pages = 0; //总页数
            int currentPage = Convert.ToInt32(Request["currentPage"]);//当前页数
            int pageSize = 3; //每页显示多少条
            List<human_file> list = hhff.human_fileFenYe(e => e.huf_id, e => e.check_status==1 , out rows, out pages, currentPage, pageSize);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["list"] = list;
            di["rows"] = rows;
            di["pages"] = pages;
            di["pageSize"] = pageSize;
            return Content(JsonConvert.SerializeObject(di));
        }

        //面试信息显示
        public ActionResult MianshiChaxun()
        {
            int huf_id = Convert.ToInt32(Request["huf_id"]);
            List<human_file> list = hhff.human_fileWhere(e => e.huf_id == huf_id);
            return View(list);
        }
    }
}