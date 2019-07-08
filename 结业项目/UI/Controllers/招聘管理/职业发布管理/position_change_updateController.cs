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
    /// 2.职位发布变更
    /// </summary>
    public class position_change_updateController : Controller
    {
        // GET: position_change_update
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
            List<engage_major_release> list = emrBll.engage_major_releaseSelectFenYe(e => e.regist_time, e => e.mre_id > 0, out rows, out pages, currentPage, pageSize);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["list"] = list;
            di["rows"] = rows;
            di["pages"] = pages;
            di["pageSize"] = pageSize;
            return Content(JsonConvert.SerializeObject(di));
        }

        //2.修改
        public ActionResult Update()
        {
           
            int mre_id = Convert.ToInt32(Request["mre_id"]);
            List<engage_major_release> list = emrBll.engage_major_releaseUpdateSelect(e=>e.mre_id== mre_id);
            return View(list);
        }

        public ActionResult Update2()
        {
            //不需要修改的： 一级机构编号 、一级机构名称 、二级机构编号 、二级机构名称、三级机构编号 、三级机构名称、
            //               职位分类编号 、职位分类名称 、职位编号 、职位名称  、登记人 、登记时间

            //需要修改：     招聘类型、招聘人数、截止日期、变更人、职位描述、招聘要求
            engage_major_release emr = new engage_major_release();

            emr.mre_id = short.Parse(Request["mre_idhaha"]);//职位发表登记表id
            //根据id查询没有的数据
            List<engage_major_release> list = emrBll.engage_major_releaseUpdateSelect(e => e.mre_id ==emr.mre_id );
            emr.first_kind_id = list[0].first_kind_id;  //一级机构编号
            emr.first_kind_name = list[0].first_kind_name;//一级机构名称
            emr.second_kind_id = list[0].second_kind_id;//二级机构编号
            emr.second_kind_name = list[0].second_kind_name;//二级机构名称
            emr.third_kind_id = list[0].third_kind_id;//三级机构编号   
            emr.third_kind_name = list[0].third_kind_name; //三级机构名称
            emr.major_kind_id = list[0].major_kind_id; ///职位分类编号
            emr.major_kind_name = list[0].major_kind_name;//职位分类名称   
            emr.major_id = list[0].major_id;//职位编号
            emr.major_name = list[0].major_name;//职位名称
            emr.register = list[0].register;//登记人
            emr.regist_time = Convert.ToDateTime(list[0].regist_time);//登记时间

            //更改数据
           
            emr.engage_type = Request["emajorRelease.engageType"];//招聘类型
            emr.human_amount = short.Parse(Request["emajorRelease.humanAmount"]);//招聘人数
            emr.deadline = Convert.ToDateTime(Request["emajorRelease.deadline"]);//截至日期
            emr.changer = Request["emajorRelease.changer"];//变更人
            emr.change_time= Convert.ToDateTime(Request["emajorRelease.changeTime"]);//变更时间
            emr.major_describe = Request["emajorRelease.majorDescribe"];//职位描述
            emr.engage_required = Request["emajorRelease.engageRequired"];//招聘要求
            int result = emrBll.engage_major_releaseUpdate(emr);
            if (result>0)
            {
                return Content("<script>alert('变更成功！');location.href='/position_change_update/Index'</script>");
            }
            else
            {
                return Content("<script>alert('变更失败！');location.href='/position_change_update/Index'</script>");
            }
        }


        //3.删除
        public ActionResult Delete(engage_major_release emr)
        {
            emr.mre_id = short.Parse(Request["mre_id"]);//职位发表登记表id
            int result = emrBll.engage_major_releaseDelete(emr);
            if (result>0)
            {
                return Content("<script>alert('删除成功！');location.href='/position_change_update/Index'</script>");
            }
            else
            {
                return Content("<script>alert('删除失败！');location.href='/position_change_update/Index'</script>");
            }
           
        }

    }
}