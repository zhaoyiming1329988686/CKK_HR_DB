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
namespace UI.Controllers.招聘管理.简历管理
{
    /// <summary>
    /// 2.简历筛选
    /// </summary>
    public class resume_chooseController : Controller
    {
        //职位分类表（大表）
        Iconfig_major_kindBll cmkBll = IocCreate.CreateBLL<config_major_kindBll>("config_major_kindjiaomama", "config_major_kindmama");
        //职位表
        Iconfig_majorBll cmBll = IocCreate.CreateBLL<config_majorBll>("config_majorjiaomama", "config_majormama");
        //简历表
        Iengage_resumeBll erBll = IocCreate.CreateBLL<engage_resumeBll>("engage_resumejiaomama", "engage_resumemama");
        //1.显示
        public ActionResult IndexSX()
        {
            ViewBag.ZhiweiFL = cmkBll.Xialakuangchaxun();
            return View();
        }
        //职位查询
        public ActionResult chaxunFL()
        {
            string majorKindId = Request["majorKindId"];
            List<config_major> list = cmBll.TiaojianChaXun(e => e.major_kind_id == majorKindId).ToList();//三级机构表
            return Content(JsonConvert.SerializeObject(list));
         
        }

        //2.进行条件筛选后，进入筛选列表
        public ActionResult SXlieBiao() {

            return View();
        }

        public ActionResult SXlieBiao2() {

            int rows = 0;   //总记录数
            int pages = 0; //总页数
            int currentPage = Convert.ToInt32(Request["currentPage"]);//当前页数
            int pageSize = 2; //每页显示多少条
            List<engage_resume> list = erBll.engage_resumeFenYe(e => e.res_id, e => e.res_id > 0, out rows, out pages, currentPage, pageSize);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["list"] = list;
            di["rows"] = rows;
            di["pages"] = pages;
            di["pageSize"] = pageSize;
            return Content(JsonConvert.SerializeObject(di));
        }

        //3.复核查询

        public ActionResult FuHe() {
            int res_id = Convert.ToInt32(Request["res_id"]);
            List<engage_resume> list = erBll.engage_resumeWhere(e=>e.res_id==res_id);
            return View(list);
        }

        //4.复核修改

        public ActionResult UpdateJianLi(engage_resume er) {

            er.checker = er.pass_checker;       //复核人
            er.check_time = er.pass_check_time; //复核时间
            er.check_status = 1;                //复核状态
            er.pass_check_status = 1;           //通过复核状态
            er.pass_register =er.human_name;    //通过登记人姓名(简历登记姓名)
            er.interview_status = 0;            //面试状态
            if (erBll.engage_resumeUpdate(er)>0)
            {
                return Content("<script>alert('复核成功！');location.href='/resume_valid_resume/IndexYouxiao'</script>");
            }
            else
            {
                return Content("<script>alert('复核失败！');location.href='/resume_valid_resume/IndexYouxiao'</script>");
            }

          
        }





    }
}