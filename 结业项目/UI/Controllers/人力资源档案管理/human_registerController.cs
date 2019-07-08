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
    /// 1.人力资源档案登记
    /// </summary>
    public class human_registerController : Controller
    {
        //一级机构表
        Iconfig_file_first_kindBll cffkBll = IocCreate.CreateBLL<config_file_first_kindBll>("config_file_first_kindjiaomama", "config_file_first_kindmama");
        //二级机构表
        Iconfig_file_second_kindBll cfskBll = IocCreate.CreateBLL<config_file_second_kindBll>("config_file_second_kindjiaomama", "config_file_second_kindmama");
        //三级机构表
        Iconfig_file_third_kindBll cftkBll = IocCreate.CreateBLL<config_file_third_kindBll>("config_file_third_kindjiaomama", "config_file_third_kindmama");
        //简历表
        Iengage_resumeBll erBll = IocCreate.CreateBLL<engage_resumeBll>("engage_resumejiaomama", "engage_resumemama");
        //面试表
        Iengage_interviewBll eInvBll = IocCreate.CreateBLL<engage_interviewBll>("engage_interviewjiaomama", "engage_interviewmama");
        //薪酬信息表
        Isalary_standardBll ssdd = IocCreate.CreateBLL<salary_standardBll>("salary_standardjiaomama", "salary_standardmama");
        //人力资源信息表
        Ihuman_fileBll hhff = IocCreate.CreateBLL<human_fileBll>("human_filejiaomama", "human_filemama");
        //用户表
        IUsersBll uuBll = IocCreate.CreateBLL<UsersBll>("Usersjiaomama", "Usersjiaomama");
        //1.显示
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
            List<engage_resume> list = erBll.engage_resumeFenYe(e => e.res_id, e => e.interview_status == 3, out rows, out pages, currentPage, pageSize);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["list"] = list;
            di["rows"] = rows;
            di["pages"] = pages;
            di["pageSize"] = pageSize;
            return Content(JsonConvert.SerializeObject(di));
        }

        /// <summary>
        /// 2.人力资源登记显示
        /// </summary>
        /// <returns></returns>
        public ActionResult HumanIndex()
        {


            //1.下拉框查询
            ViewBag.list1 = cffkBll.Xialakuangchaxun(); //一级机构表
            ViewBag.XinChou = ssdd.salary_standardSelect();//薪酬标准
            ViewBag.Users = uuBll.user();//用户表
            //2.简历表条件查询赋值
            int res_id = Convert.ToInt32(Request["res_id"]);
            List<engage_resume> list = erBll.engage_resumeWhere(e=>e.res_id==res_id);
            return View(list);
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

        //提交
        public ActionResult Tijiao(human_file hf)
        {
            int resid = Convert.ToInt32(Request["residhahaha"]);
            List<engage_resume> list = erBll.engage_resumeWhere(e => e.res_id == resid);
            hf.checker = list[0].checker;//档案复核人(简历表复核人)
            hf.register = list[0].register;//登记人  本来是session值
            string humanID = "";//档案编号
            var sum = hhff.human_fileSelect();
            var flowNoStart = DateTime.Now.ToString("yyyyMMdd");
            //查询数据库里面有没有数据
            if (sum.Count>0)    
            {
                int Count = sum.Count;
                human_file huCount = sum[Count - 1];//从零开始，所以减一。
                int Number = Convert.ToInt32(huCount.human_id.Substring(huCount.human_id.Length-2, 2));
                Number++;
                humanID = Number.ToString();
                humanID = "bt" + flowNoStart + humanID;
                
            }
            else
            {
                humanID = "bt" + flowNoStart + "01";
            }
            hf.human_id = humanID;//档案编号
            List<config_file_first_kind> listfirst_kind_name = cffkBll.TiaojianChaXun(e => e.first_kind_id == hf.first_kind_id);
            hf.first_kind_name = listfirst_kind_name[0].first_kind_name;//一级机构名称
            List<config_file_second_kind> listsecond_kind_name = cfskBll.TiaojianChaXun(e => e.second_kind_id == hf.second_kind_id);
            hf.second_kind_name = listsecond_kind_name[0].second_kind_name;//二级机构名称
            List<config_file_third_kind> listthird_kind_name = cftkBll.TiaojianChaXun(e => e.third_kind_id == hf.third_kind_id);
            hf.third_kind_name = listthird_kind_name[0].third_kind_name;//三级机构名称
            List<salary_standard>  Listsalary_standfard_name = ssdd.salary_standardWhere(e=>e.standard_id==hf.salary_standard_id);
            hf.salary_standard_name = Listsalary_standfard_name[0].standard_name;//薪酬名称
            int result = hhff.human_fileAdd(hf);
            if (true)
            {
                return Content("<script>alert('人力资源档案提交成功！');location.href='/human_register/TuPian/?humanID=" + humanID + "';</script>");
            }
            //else
            //{
            //    return Content("<script>alert('人力资源档案提交失败！');location.href='/human_register/Index';</script>");
            //}
        
        }
        //图片上传
        public ActionResult TuPian(string humanID,string ttt)
        {
            if (humanID!=null)
            {
                ViewBag.humanID = humanID;
            }
            if (ttt!=null)
            {
                ViewBag.humanID = ttt;
            }
           
            
            return View();
        }

        //图片上传操作
        public ActionResult TuPianCZ(HttpPostedFileBase filett, string humanID)
        {
             //humanID = Request["humanID"];
            human_file list = hhff.human_fileWhere(e=>e.human_id== humanID).FirstOrDefault();
            if (filett != null)
            {
                var fileName = filett.FileName;
                var filePath = Server.MapPath(string.Format("~/{0}", "TuPian"));
                filett.SaveAs(Path.Combine(filePath,fileName));
                list.human_picture = fileName;
                list.human_file_status = true;
            }
            if (hhff.human_fileUpdate(list)>0)
            {
              
                return Content("<script>alert('上传成功！');location.href='/human_register/TuPianFJ/?humanIDfj=" + humanID + "'</script>");
            }
            else
            {
                return View(list);
            }
           
        }


        //图片上传附件
        public ActionResult TuPianFJ(string humanIDfj)
        {
            ViewBag.tupian = humanIDfj;
            return View();
        }



        //图片附件操作
        public ActionResult TuPianFJCZ(HttpPostedFileBase file, string humanFilehumanId)
        {
          
            human_file list = hhff.human_fileWhere(e => e.human_id == humanFilehumanId).FirstOrDefault();
            if (list != null)
            {
                var fileName = file.FileName;
                var filePath = Server.MapPath(string.Format("~/{0}", "TuPian2"));
                file.SaveAs(Path.Combine(filePath, fileName));
                list.attachment_name = fileName;
                list.human_file_status = true;
            }
            if (hhff.human_fileUpdate(list) > 0)
            {
                return Content("<script>alert('附件上传成功！');location.href='/human_register/TuPian/?humanID=" + humanFilehumanId + "'</script>");
            }
            else
            {
                return View(list);
            }

        }
    }
}