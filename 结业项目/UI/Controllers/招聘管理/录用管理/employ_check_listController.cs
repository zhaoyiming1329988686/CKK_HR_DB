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
namespace UI.Controllers.招聘管理.录用管理
{
    /// <summary>
    /// 2.录用审批
    /// </summary>
    public class employ_check_listController : Controller
    {
        //简历表
        Iengage_resumeBll erBll = IocCreate.CreateBLL<engage_resumeBll>("engage_resumejiaomama", "engage_resumemama");
        //面试表
        Iengage_interviewBll eInvBll = IocCreate.CreateBLL<engage_interviewBll>("engage_interviewjiaomama", "engage_interviewmama");
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
            List<engage_resume> list = erBll.engage_resumeFenYe(e => e.res_id, e => e.interview_status == 2, out rows, out pages, currentPage, pageSize);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["list"] = list;
            di["rows"] = rows;
            di["pages"] = pages;
            di["pageSize"] = pageSize;
            return Content(JsonConvert.SerializeObject(di));
        }


        //审批显示
        public ActionResult ShenPiIndex()
        {
            int res_id = Convert.ToInt32(Request["res_id"]);//简历id
            ViewBag.listJianli = erBll.engage_resumeWhere(e => e.res_id == res_id);//简历表条件查询
            ViewBag.listMianshi = eInvBll.engage_interviewSelectWhere(e => e.resume_id == res_id);//面试表条件查询
            ViewBag.jianlilushenheyijian = erBll.engage_resumeWhere(e => e.res_id == res_id);//简历表条件查询
            return View();
        }

        public ActionResult ShenPi()
        {
            int res_id = Convert.ToInt32(Request["res_idhaha"]);//简历id
            string shenpi = Request["pass_passCommenthaha"];    //录用审核意见
            if (shenpi=="通过")
            {
                engage_resume er = erBll.engage_resumeWhere(e => e.res_id == res_id).FirstOrDefault();
                er.interview_status = 3;
                er.pass_passComment = shenpi;       //审批意见
                int result = erBll.engage_resumeUpdate(er);
                if (result > 0)
                {
                    return Content("<script>alert('审批成功！');location.href='/employ_list/Index'</script>");
                }
                else
                {
                    return Content("<script>alert('审批失败！');location.href='/employ_check_list/Index'</script>");
                }
            }
            else
            {
                using (TransactionScope tr = new TransactionScope())
                {
                    engage_resume er = new engage_resume();

                    er.res_id = short.Parse(res_id.ToString());
                    int result = erBll.engage_resumeDelete(er);
                    if (result > 0)
                    {
                        int idms = Convert.ToInt32(Request["ein_idhaha"]);
                        engage_interview ev = new engage_interview();
                        ev.ein_id = short.Parse(idms.ToString());
                        int result2 = eInvBll.engage_interviewDelete(ev);
                        if (result2 > 0)
                        {
                            tr.Complete();
                            return Content("<script>alert('删除简历成功！');location.href='/position_release_search/Index'</script>");
                            //删除成功，重新进入职业发布查询页面
                        }
                        else
                        {
                            return Content("<script>alert('删除简历失败！');location.href='/employ_check_list/Index'</script>");
                        }
                    }
                    else
                    {
                        return Content("<script>alert('删除简历失败！');location.href='/employ_check_list/Index'</script>");
                    }
                }
            }
        }
    }
}