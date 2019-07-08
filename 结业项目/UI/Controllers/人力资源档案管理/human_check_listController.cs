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
using System.IO;
namespace UI.Controllers.人力资源档案管理
{
    /// <summary>
    /// 2.人力资源档案复核
    /// </summary>
    public class human_check_listController : Controller
    {
        //人力资源信息表
        Ihuman_fileBll hhff = IocCreate.CreateBLL<human_fileBll>("human_filejiaomama", "human_filemama");
        IUsersBll uu = IocCreate.CreateBLL<UsersBll>("Usersjiaomama", "Usersmama");
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
            List<human_file> list = hhff.human_fileFenYe(e => e.huf_id,e=>e.regist_time!=null&&e.check_status==0, out rows, out pages, currentPage, pageSize);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["list"] = list;
            di["rows"] = rows;
            di["pages"] = pages;
            di["pageSize"] = pageSize;
            return Content(JsonConvert.SerializeObject(di));
        }

        //复核
        public ActionResult FHIndex()
        {
            int huf_id = Convert.ToInt32(Request["huf_id"]);
            List<human_file> list = hhff.human_fileWhere(e=>e.huf_id==huf_id);
            ViewBag.Users = uu.user();//用户表
            return View(list);
        }
        //通过复核
        public ActionResult TongGuoFH(human_file hh)
        {
            int huf_id = Convert.ToInt32(Request["huf_idhaha"]);
            human_file hf = hhff.human_fileWhere(e=>e.huf_id==huf_id).FirstOrDefault();
            hf.lastly_change_time = DateTime.Now;//档案最近更改时间
            hf.check_time = hh.check_time;//复核时间
            hf.check_status = 1;//复核状态
            hf.checker = hh.checker;//复核人
            hf.human_file_status = true;//档案状态
            if (hhff.human_fileUpdate(hf)>0)
            {
                return Content("<script>alert('人力资源档案复核成功！');location.href='/human_query_locate/ChaXunIndex';</script>");
            }
            else
            {
                return Content("<script>alert('人力资源档案复核失败！');location.href='/human_register/TuPian';</script>");
            }
           
        }
    }
}