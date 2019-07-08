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
namespace UI.Controllers.人力资源档案管理.人力资源档案删除管理
{
    /// <summary>
    /// 1.人力资源档案删除
    /// </summary>
    public class human_delete_locateController : Controller
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

        //1.条件查询
        public ActionResult Index()
        {
            ViewBag.yiji = cffkBll.Xialakuangchaxun();
            ViewBag.fenlei = cmkBll.Xialakuangchaxun();
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
        //2.显示
        public ActionResult IndexSelect()
        {
            return View();
        }

        public ActionResult IndexSelect2()
        {
            int rows = 0;   //总记录数
            int pages = 0; //总页数
            int currentPage = Convert.ToInt32(Request["currentPage"]);//当前页数
            int pageSize = 3; //每页显示多少条
            List<human_file> list = hhff.human_fileFenYe(e => e.huf_id, e => e.check_status == 1&&e.human_file_status == true, out rows, out pages, currentPage, pageSize);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["list"] = list;
            di["rows"] = rows;
            di["pages"] = pages;
            di["pageSize"] = pageSize;
            return Content(JsonConvert.SerializeObject(di));
        }

        //3.按编号单个详细显示
        public ActionResult DeleteIndex()
        {
            int huf_id = Convert.ToInt32(Request["huf_id"]);
            List<human_file> list = hhff.human_fileWhere(e => e.huf_id == huf_id);
            return View(list);
        }

        //修改简历信息状态
        public ActionResult Delete() {
            int huf_id = Convert.ToInt32(Request["huf_idhaha"]);
            human_file hf = hhff.human_fileWhere(e=>e.huf_id==huf_id).FirstOrDefault();
            hf.delete_time = DateTime.Now;//档案删除时间
            hf.human_file_status = false;//档案状态
            if (hhff.human_fileUpdate(hf) > 0)
            {
                return Content("<script>alert('人力资源档案删除成功！');location.href='/human_delete_locate/Index';</script>");
            }
            else
            {
                return View(hf);
            }
           
        }

    }
}