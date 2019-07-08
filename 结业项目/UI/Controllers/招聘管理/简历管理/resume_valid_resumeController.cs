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
using System.Web.SessionState;
namespace UI.Controllers.招聘管理.简历管理
{
    /// <summary>
    /// 3.有效简历查询
    /// </summary>
    public class resume_valid_resumeController : Controller,IRequiresSessionState
    {
        //职位分类表（大表）
        Iconfig_major_kindBll cmkBll = IocCreate.CreateBLL<config_major_kindBll>("config_major_kindjiaomama", "config_major_kindmama");
        //职位表
        Iconfig_majorBll cmBll = IocCreate.CreateBLL<config_majorBll>("config_majorjiaomama", "config_majormama");
        //简历表
        Iengage_resumeBll erBll = IocCreate.CreateBLL<engage_resumeBll>("engage_resumejiaomama", "engage_resumemama");
        // GET: valid_resume

        //1.显示
        public ActionResult IndexYouxiao()
        {
            ViewBag.ZhiweiFL = cmkBll.Xialakuangchaxun();
            return View();
        }

        //职位查询（根据职位分类查询职位方法）
        public ActionResult chaxunFL()
        {
            string majorKindId = Request["majorKindId"];
            List<config_major> list = cmBll.TiaojianChaXun(e => e.major_kind_id == majorKindId).ToList();//三级机构表
            return Content(JsonConvert.SerializeObject(list));
        }

        //2.进入有效条件筛选列表后进入   --分页列表信息查询显示
        public ActionResult YouXiaoChaxun()
        {
            string major_kind_idhaha = Request["engageResumehumanMajorKindId"];//职位分类id
            string major_idhaha = Request["engageResumehumanMajorId"]; //职位id
            string guanjianzhihaha = Request["utilBeanprimarKey"];   //关键字
            string kaishiTimehaha = Request["utilBeanstartDate"];//开始时间
            string jieshuTimehaha = Request["utilBeanendDate"];  //结束时间

            Session["major_kind_idhaha"] = major_kind_idhaha;//职位分类id
            Session["major_idhaha"] = major_idhaha; //职位id
            Session["guanjianzhihaha"] = guanjianzhihaha;   //关键字
            Session["kaishiTimehaha"] = kaishiTimehaha;//开始时间
            Session["jieshuTimehaha"] = jieshuTimehaha;  //结束时间
            return View();
        }

        public ActionResult YouXiaoChaxun2()
        {
            if (Session["major_kind_idhaha"]!=null&& Session["major_idhaha"]!=null && Session["guanjianzhihaha"]!=null&& Session["kaishiTimehaha"] != null&& Session["jieshuTimehaha"] != null) 
            {
                string major_kind_id = Convert.ToString(Session["major_kind_idhaha"]); //职位分类id
                string major_id = Convert.ToString(Session["major_idhaha"]);      //职位id
                string guanjianzhi = Convert.ToString(Session["guanjianzhihaha"].ToString());       //关键字姓名，电话，身份证号码，个人履历字段中
                DateTime kaishiTime = Convert.ToDateTime(Session["kaishiTimehaha"].ToString());        //开始时间
                DateTime jieshuTime = Convert.ToDateTime(Session["jieshuTimehaha"].ToString());        //结束时间
                //有条件
                //--human_major_kind_id
                //--human_major_id
                //--human_name human_telephone  human_idcard human_history_records
                //--pass_regist_time
                // || e.pass_regist_time >= kaishiTime && e.pass_regist_time <= jieshuTime
                //复核状态为1
                int rows = 0;   //总记录数
                int pages = 0; //总页数
                int currentPage = Convert.ToInt32(Request["currentPage"]);//当前页数
                int pageSize = 2; //每页显示多少条
                List<engage_resume> list = erBll.engage_resumeFenYe(e => e.res_id, e => e.pass_check_status == 1 && e.human_major_kind_id == major_kind_id && e.human_major_id == major_id || e.human_name.Contains(guanjianzhi) || e.human_telephone.Contains(guanjianzhi) || e.human_idcard == guanjianzhi|| e.human_history_records == guanjianzhi || e.pass_regist_time >= kaishiTime && e.pass_regist_time <= jieshuTime, out rows, out pages, currentPage, pageSize);
                Dictionary<string, object> di = new Dictionary<string, object>();
                di["list"] = list;
                di["rows"] = rows;
                di["pages"] = pages;
                di["pageSize"] = pageSize;
                return Content(JsonConvert.SerializeObject(di));

            }
            else
            {
                //没有条件
                //复核状态为1
                int rows = 0;   //总记录数
                int pages = 0; //总页数
                int currentPage = Convert.ToInt32(Request["currentPage"]);//当前页数
                int pageSize = 2; //每页显示多少条
                List<engage_resume> list = erBll.engage_resumeFenYe(e => e.res_id, e => e.pass_check_status == 1, out rows, out pages, currentPage, pageSize);
                Dictionary<string, object> di = new Dictionary<string, object>();
                di["list"] = list;
                di["rows"] = rows;
                di["pages"] = pages;
                di["pageSize"] = pageSize;
                return Content(JsonConvert.SerializeObject(di));
            }
                    
        }
    }
}