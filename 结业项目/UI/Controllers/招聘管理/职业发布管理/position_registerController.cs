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
    /// 1.职位发布登记
    /// </summary>
    public class position_registerController : Controller
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
        //职位发表登记表
        Iengage_major_releaseBll emrBll = IocCreate.CreateBLL<engage_major_releaseBll>("engage_major_releasejiaomama", "engage_major_releasemama");
        IUsersBll uuBll = IocCreate.CreateBLL<UsersBll>("Usersjiaomama", "Usersmama");
        //1.显示
        public ActionResult index()
        {
            //下拉框查询
            ViewBag.list1 = cffkBll.Xialakuangchaxun(); //一级机构表
            ViewBag.list4 = cmkBll.Xialakuangchaxun();//职位分类表
            ViewBag.Users = uuBll.user();
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
        
        //2.提交
        public ActionResult Add()
        {
            engage_major_release emr = new engage_major_release();

            emr.first_kind_id = Request["emajorRelease.firstKindId"];//一级机构编号
            List<config_file_first_kind> listfirst_kind_name = cffkBll.TiaojianChaXun(e=>e.first_kind_id==emr.first_kind_id);
            emr.first_kind_name= listfirst_kind_name[0].first_kind_name;//一级机构名称

            emr.second_kind_id = Request["emajorRelease.secondKindId"];//二级机构编号
            List<config_file_second_kind> listsecond_kind_name = cfskBll.TiaojianChaXun(e=>e.second_kind_id==emr.second_kind_id);
            emr.second_kind_name = listsecond_kind_name[0].second_kind_name;//二级机构名称

            emr.third_kind_id = Request["emajorRelease.thirdKindId"];//三级机构编号
            List<config_file_third_kind> listthird_kind_name = cftkBll.TiaojianChaXun(e =>e.third_kind_id == emr.third_kind_id);
            emr.third_kind_name = listthird_kind_name[0].third_kind_name;//三级机构名称

            emr.major_kind_id = Request["emajorRelease.majorKindId"];//职位分类编号
            List<config_major_kind> listmajor_kind_name = cmkBll.TiaojianChaXun(e=>e.major_kind_id==emr.major_kind_id);
            emr.major_kind_name = listmajor_kind_name[0].major_kind_name;//职位分类名称

            emr.major_id = Request["emajorRelease.majorId"];//职位编号
            List<config_major> listmajor_name = cmBll.TiaojianChaXun(e => e.major_id == emr.major_id);
            emr.major_name = listmajor_name[0].major_name;//职位名称
            
            emr.human_amount = short.Parse(Request["emajorRelease.humanAmount"]);//招聘人数  ***
            emr.engage_type = Request["emajorRelease.engageType"];//招聘类型
            emr.deadline = Convert.ToDateTime(Request["item.str_startTime"]);//截至日期
            emr.register = Request["emajorRelease.register"];//登记人
            //emr.changer = Request[""];//变更人
            emr.regist_time = Convert.ToDateTime(Request["emajorRelease.registTime"]);//登记时间
            //emr.change_time= Convert.ToDateTime(Request[""]);//变更时间
            emr.major_describe = Request["emajorRelease.majorDescribe"];//职位描述
            emr.engage_required = Request["emajorRelease.engageRequired"];//招聘要求

            
            //return RedirectToAction("/position_register/Index/");


            if (emrBll.Addengage_major_release(emr) > 0)
            {
                return Content("<script>alert('提交成功！');location.href='/position_register/Index'</script>");
            }
            else
            {
                return Content("<script>alert('提交失败！');location.href='/position_register/Index'</script>");

            }

        }
    }
}