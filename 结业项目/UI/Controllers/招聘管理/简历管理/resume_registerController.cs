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
    /// 1.简历登记
    /// </summary>
    public class resume_registerController : Controller
    {
        // GET: register
        //职位分类表
        Iconfig_major_kindBll cmkBll = IocCreate.CreateBLL<config_major_kindBll>("config_major_kindjiaomama", "config_major_kindmama");
        //职位表
        Iconfig_majorBll cmBll = IocCreate.CreateBLL<config_majorBll>("config_majorjiaomama", "config_majormama");
        //简历表
        Iengage_resumeBll erBll = IocCreate.CreateBLL<engage_resumeBll>("engage_resumejiaomama", "engage_resumemama");

        //用户表
        IUsersBll uuBll = IocCreate.CreateBLL<UsersBll>("Usersjiaomama", "Usersjiaomama");
        //简历登记页面
        public ActionResult IndexDengji()
        {
            //判断是不是从申请页面过来的
            if (Request["emajorRelease.register"] != null)
            {
                ViewBag.dengjiren = Request["emajorRelease.register"];//登记人
            }
            if (Request["emajorRelease.registTime"] != null)
            {
                ViewBag.dengjishijian = Request["emajorRelease.registTime"];//登记时间
            }
            if (Request["emajorRelease.majorKindName"] != null)
            {
                ViewBag.zhiweifenleiID = Request["emajorRelease.majorKindName"].ToString();//职位分类id
            }
            if (Request["emajorRelease.majorKindName2"] != null)
            {
                ViewBag.zhiweifenlei = Request["emajorRelease.majorKindName2"].ToString();//职位分类名称
            }
            if (Request["emajorRelease.majorName"] != null)
            {
                ViewBag.zhiweiID = Request["emajorRelease.majorName"].ToString();//职位id
            }
            if (Request["emajorRelease.majorName2"] != null)
            {
                ViewBag.zhiwei = Request["emajorRelease.majorName2"].ToString();//职位名称
            }

            //未申请职位过来的，从新查值
            if (Request["emajorRelease.majorKindName"] == null) //职位分类
            {
                ViewBag.nanshou = cmkBll.Xialakuangchaxun();
            }
            if (Request["emajorRelease.majorName2"] == null)//职位
            {
                ViewBag.xiangku = cmBll.Xialakuangchaxun();
            }

            return View();

        }

        //2.添加简历
        public ActionResult Add(engage_resume er)
        {
            //不是通过申请过来的，没有name 通过id查询
            if (er.human_major_kind_name==null&&er.human_major_name == null)
            {
               
                List<config_major_kind> listfenlei = cmkBll.TiaojianChaXun(e=>e.major_kind_id==er.human_major_kind_id);
                er.human_major_kind_name = listfenlei[0].major_kind_name;
                List<config_major> list = cmBll.TiaojianChaXun(e=>e.major_id==er.human_major_id);
                er.human_major_name = list[0].major_name;

            }
            //不是从申请页面进来的，无登记人，和登记时间。自动赋值
            if (er.register==null&&er.regist_time==null)
            {
                er.register = "赵逸铭";//登记人
                er.regist_time =DateTime.Now; //登记时间
            }
            er.pass_register = er.human_name;//通过登记人姓名
            er.check_status = 0;        //复核状态
            er.pass_check_status = 0;   //通过复核状态
            if (erBll.engage_resumeAdd(er) > 0)
            {
                return Content("<script>alert('简历添加成功！');location.href='/resume_choose/IndexSX'</script>");
            }
            else
            {
                return Content("<script>alert('简历添加失败！');location.href='/resume_choose/IndexSX'</script>");
            }

        }
    }
}