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
    /// 1.录用申请
    /// </summary>
    public class employ_register_listController : Controller
    {
        //简历表
        Iengage_resumeBll erBll = IocCreate.CreateBLL<engage_resumeBll>("engage_resumejiaomama", "engage_resumemama");
        //面试表
        Iengage_interviewBll eInvBll = IocCreate.CreateBLL<engage_interviewBll>("engage_interviewjiaomama", "engage_interviewmama");
        public ActionResult LuYongIndex()
        {
            return View();
        }

        public ActionResult LuYongIndex2()
        {
            int rows = 0;   //总记录数
            int pages = 0; //总页数
            int currentPage = Convert.ToInt32(Request["currentPage"]);//当前页数
            int pageSize = 2; //每页显示多少条
            List<engage_resume> list = erBll.engage_resumeFenYe(e => e.res_id, e => e.interview_status == 1, out rows, out pages, currentPage, pageSize);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["list"] = list;
            di["rows"] = rows;
            di["pages"] = pages;
            di["pageSize"] = pageSize;
            return Content(JsonConvert.SerializeObject(di));
        }

        //申请页面
        public ActionResult IndexShenQing() {

            int res_id = Convert.ToInt32(Request["res_id"]);//简历id
            ViewBag.listJianli = erBll.engage_resumeWhere(e => e.res_id == res_id);//简历表条件查询
            ViewBag.listMianshi = eInvBll.engage_interviewSelectWhere(e => e.resume_id == res_id);//面试表条件查询
            return View();
        }

        //申请
        public ActionResult ShenQing() {
            
            int res_id = Convert.ToInt32(Request["res_idhaha"]);//简历id
            string yijian = Request["passCheckcommenthaha"];    //录用审核意见
            if (yijian == "通过")
            {
                engage_resume er = erBll.engage_resumeWhere(e => e.res_id == res_id).FirstOrDefault();
                er.interview_status = 2;
                int result = erBll.engage_resumeUpdate(er);
                if (result > 0)
                {
                    return Content("<script>alert('申请成功！');location.href='/employ_check_list/Index'</script>");
                }
                else
                {
                    return Content("<script>alert('申请失败！');location.href='/employ_register_list/LuYongIndex2'</script>");
                }
            }
            //不通过
            else
            {
                using (TransactionScope tr = new TransactionScope())
                {

                    //简历表
                    engage_resume er = erBll.engage_resumeWhere(e => e.res_id == res_id).FirstOrDefault();
                    er.interview_status = 0;   //面试状态还原成0
                    int result = erBll.engage_resumeUpdate(er);
                    if (result > 0)
                    {
                        //面试表
                        engage_interview ev = eInvBll.engage_interviewSelectWhere(e => e.resume_id == res_id).FirstOrDefault();
                        ev.interview_status = 0;//面试状态还原成0
                        ev.check_status = 0;//筛选状态还原成0
                        int result2 = eInvBll.engage_interviewUpdate(ev);
                        if (result2 > 0)
                        {
                            tr.Complete();
                            return Content("<script>alert('释放成功！');location.href='/employ_check_list/Index'</script>");
                        }
                        else
                        {
                            return Content("<script>alert('释放失败！');location.href='/employ_register_list/LuYongIndex2'</script>");
                        }

                    }
                    else
                    {
                        return Content("<script>alert('释放失败！');location.href='/employ_register_list/LuYongIndex2'</script>");
                    }


                }
            }

            
        }
    }
}