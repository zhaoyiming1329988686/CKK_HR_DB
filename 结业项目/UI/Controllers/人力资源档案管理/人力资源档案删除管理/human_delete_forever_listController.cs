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
    /// 3.人力资源档案永久删除
    /// </summary>
    public class human_delete_forever_listController : Controller
    {
       
        //人力资源信息表
        Ihuman_fileBll hhff = IocCreate.CreateBLL<human_fileBll>("human_filejiaomama", "human_filemama");
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            int rows = 0;   //总记录数
            int pages = 0; //总页数
            int currentPage = Convert.ToInt32(Request["currentPage"]);//当前页数
            int pageSize = 3; //每页显示多少条
            List<human_file> list = hhff.human_fileFenYe(e => e.huf_id, e => e.check_status == 1, out rows, out pages, currentPage, pageSize);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["list"] = list;
            di["rows"] = rows;
            di["pages"] = pages;
            di["pageSize"] = pageSize;
            return Content(JsonConvert.SerializeObject(di));
        }

        //永久删除
        public ActionResult YongJiuDelete()
        {
            int huf_id = Convert.ToInt32(Request["huf_id"]);
            human_file hf = new human_file();
            hf.huf_id = short.Parse(huf_id.ToString());
            if (hhff.human_fileDelete(hf)>0)
            {
                return Content("<script>alert('档案已删除！！！！');location.href='/human_delete_forever_list/Index';</script>");
            }
            else
            {
                return View(hf);
            } 
        }
    }
}