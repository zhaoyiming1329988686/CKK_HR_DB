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

namespace UI.Controllers.招聘管理.面试管理
{
    /// <summary>
    /// 2.面试筛选
    /// </summary>
    public class interview_sift_listController : Controller
    {
        //简历表
        Iengage_resumeBll erBll = IocCreate.CreateBLL<engage_resumeBll>("engage_resumejiaomama", "engage_resumemama");
        //面试表
        Iengage_interviewBll eInvBll = IocCreate.CreateBLL<engage_interviewBll>("engage_interviewjiaomama", "engage_interviewmama");
        IUsersBll uuBll = IocCreate.CreateBLL<UsersBll>("Usersjiaomama", "Usersmama");

        //1.面试筛选显示
        public ActionResult IndexShaiXuan()
        {
            return View();
        }
        public ActionResult IndexShaiXuan2()
        {
            int rows = 0;   //总记录数
            int pages = 0; //总页数
            int currentPage = Convert.ToInt32(Request["currentPage"]);//当前页数
            int pageSize = 2; //每页显示多少条
            List<engage_interview> list = eInvBll.engage_interviewFenYe(e => e.ein_id, e => e.ein_id>0, out rows, out pages, currentPage, pageSize);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["list"] = list;
            di["rows"] = rows;
            di["pages"] = pages;
            di["pageSize"] = pageSize;
            return Content(JsonConvert.SerializeObject(di));
        }

        //2.面试筛选
        public ActionResult MianshiShaixuan() {

            int ein_id = Convert.ToInt32(Request["ein_id"]);//面试id
            if (Request["ein_id"]!=null)
            {
                List<engage_interview> list = eInvBll.engage_interviewSelectWhere(e => e.ein_id == ein_id);//面试表条件查询
                int aa = Convert.ToInt32(list[0].resume_id);
                ViewBag.listJianli = erBll.engage_resumeWhere(e => e.res_id == aa);//简历表条件查询
                ViewBag.listMianshi = eInvBll.engage_interviewSelectWhere(e => e.ein_id == ein_id);//面试表条件查询
                ViewBag.Users = uuBll.user();
                return View();
            }
            else
            {
                return Content("<script>alert('请从面试筛选页面进入！');location.href='/interview_sift_list/IndexShaiXuan'</script>");
            }
           
           
        }

        //3.筛选
        public ActionResult SX(engage_interview ev) {

            //获取录用审核意见
            string luyong = Request["pass_checkCommenthaha"];
            using (TransactionScope tr = new TransactionScope())
            {
              
                if (luyong == "建议面试")
                {
                    //简历表
                    int id = Convert.ToInt32(Request["res_idhaha"]);
                    engage_resume er= erBll.engage_resumeWhere(e => e.res_id == id).FirstOrDefault();

                    //List<engage_resume> list = erBll.engage_resumeWhere(e => e.res_id == id);
                    //er.res_id = short.Parse(id.ToString());     //简历表id
                    //er.check_status = list[0].check_status;                //1.复核状态
                    //er.register = list[0].register;                      //2.登记人
                    //er.regist_time = list[0].regist_time;               //3.登记时间
                    //er.checker = list[0].checker;                        //4.复核人
                    //er.check_time = list[0].check_time;                 //5.复核时间
                    //er.interview_status = 1;                            //6.面试状态(1 建议面试 2建议笔试 3建议录用)
                    //er.pass_check_status = list[0].pass_check_status;  //通过复核状态
                    //er.pass_register = list[0].pass_register;           //7.通过登记人姓名(简历登记姓名  例如 张帅)
                    //er.pass_check_status = list[0].pass_check_status;   //8.通过复核状态
                    er.pass_checkComment = luyong;                      //9.录用申请审核意见
                    er.interview_status = 1;        //简历表面试状态
                    int result = erBll.engage_resumeUpdate(er);
                    if (result > 0)
                    {
                        //面试表
                        int idms = Convert.ToInt32(Request["ein_idhaha"]);
                        List<engage_interview> list2 = eInvBll.engage_interviewSelectWhere(e => e.ein_id == idms);
                        ev.ein_id = short.Parse(idms.ToString());
                        ev.resume_id = list2[0].resume_id;                  //简历id
                        ev.result = list2[0].result;                    //面试结果
                        ev.interview_comment = list2[0].interview_comment;  //面试评价
                        ev.check_comment = luyong;           //筛选评价
                        ev.interview_status = 1;            //面试状态(1 建议面试 2建议笔试 3建议录用)
                        ev.check_status = 1;                //筛选状态(1 建议面试 2建议笔试 3建议录用)
                        int result2 = eInvBll.engage_interviewUpdate(ev);
                        if (result2 > 0)
                        {
                            tr.Complete();
                        }
                    }

                }
                if (luyong == "建议笔试")
                {
                    //简历表
                    int id = Convert.ToInt32(Request["res_idhaha"]);
                    engage_resume er = erBll.engage_resumeWhere(e => e.res_id == id).FirstOrDefault();
                    er.pass_checkComment = luyong;                      //10.录用申请审核意见
                    er.interview_status = 1;        //简历表面试状态
                    int result = erBll.engage_resumeUpdate(er);
                    if (result > 0)
                    {
                        //面试表
                        int idms = Convert.ToInt32(Request["ein_idhaha"]);
                        List<engage_interview> list2 = eInvBll.engage_interviewSelectWhere(e => e.ein_id == idms);
                        ev.ein_id = short.Parse(idms.ToString());
                        ev.resume_id = list2[0].resume_id;                  //简历id
                        ev.result = list2[0].result;                    //面试结果
                        ev.interview_comment = list2[0].interview_comment;  //面试评价
                        ev.check_comment = luyong;           //筛选评价
                        ev.interview_status = 2;            //面试状态(1 建议面试 2建议笔试 3建议录用)
                        ev.check_status = 2;                //筛选状态(1 建议面试 2建议笔试 3建议录用)
                        int result2 = eInvBll.engage_interviewUpdate(ev);
                        if (result2 > 0)
                        {
                            tr.Complete();

                        }
                    }
                }
                if (luyong == "建议录用")
                {
                    //简历表
                    int id = Convert.ToInt32(Request["res_idhaha"]);
                    engage_resume er = erBll.engage_resumeWhere(e => e.res_id == id).FirstOrDefault();
                    er.pass_checkComment = luyong;                      //9.录用申请审核意见
                    er.interview_status = 1;        //简历表面试状态
                    int result = erBll.engage_resumeUpdate(er);
                    if (result > 0)
                    {
                        //面试表
                        int idms = Convert.ToInt32(Request["ein_idhaha"]);
                        List<engage_interview> list2 = eInvBll.engage_interviewSelectWhere(e => e.ein_id == idms);
                        ev.ein_id = short.Parse(idms.ToString());
                        ev.resume_id = list2[0].resume_id;                  //简历id
                        ev.result = list2[0].result;                    //面试结果
                        ev.interview_comment = list2[0].interview_comment;  //面试评价
                        ev.check_comment = luyong;           //筛选评价
                        ev.interview_status = 3;            //面试状态(1 建议面试 2建议笔试 3建议录用)
                        ev.check_status = 3;                //筛选状态(1 建议面试 2建议笔试 3建议录用)
                        int result2 = eInvBll.engage_interviewUpdate(ev);
                        if (result2 > 0)
                        {
                            tr.Complete();
                        }
                    }
                }
                if (luyong == "删除简历")
                {
                        //简历表
                        int id = Convert.ToInt32(Request["res_idhaha"]);
                        //面试表
                        int idms = Convert.ToInt32(Request["ein_idhaha"]);
                        engage_resume er = new engage_resume();
                        er.res_id = short.Parse(id.ToString());
                        int result =erBll.engage_resumeDelete(er);
                        if (result>0)
                        {
                            ev.ein_id = short.Parse(idms.ToString());
                            int result2 =eInvBll.engage_interviewDelete(ev);
                            if (result2>0)
                            {
                                tr.Complete();
                                return Content("<script>alert('删除简历成功！');location.href='/position_release_search/Index'</script>");
                        }
                        }
                      
                
                }
                return Content("<script>alert('执行成功！');location.href='/employ_register_list/LuYongIndex'</script>");
            }
        }

    }
}