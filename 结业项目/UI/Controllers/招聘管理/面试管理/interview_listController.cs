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
namespace UI.Controllers.招聘管理.面试管理
{
    /// <summary>
    /// 1.面试结果登记
    /// </summary>
    public class interview_listController : Controller
    {

        //简历表
        Iengage_resumeBll erBll = IocCreate.CreateBLL<engage_resumeBll>("engage_resumejiaomama", "engage_resumemama");
        //面试表
        Iengage_interviewBll eInvBll = IocCreate.CreateBLL<engage_interviewBll>("engage_interviewjiaomama", "engage_interviewmama");

        IUsersBll uuBll = IocCreate.CreateBLL<IUsersBll>("Usersjiaomama", "Usersmama");

        //1.首页显示
        public ActionResult IndexMianShi()
        {
            return View();
        }
        public ActionResult IndexMianShi2()
        {
            int rows = 0;   //总记录数
            int pages = 0; //总页数
            int currentPage = Convert.ToInt32(Request["currentPage"]);//当前页数
            int pageSize = 2; //每页显示多少条
            List<engage_resume> list = erBll.engage_resumeFenYe(e => e.res_id, e => e.res_id >0, out rows, out pages, currentPage, pageSize);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["list"] = list;
            di["rows"] = rows;
            di["pages"] = pages;
            di["pageSize"] = pageSize;
            return Content(JsonConvert.SerializeObject(di));
        }

        //2.面试登记查询（条件查询）
        public ActionResult MianShiDengji()
        {
            //2-1.根据id查询简历
            int res_id = Convert.ToInt32(Request["res_id"]);
            List<engage_resume> list = erBll.engage_resumeWhere(e => e.res_id == res_id);

            //2-2.根据id查询面试表
            List<engage_interview>  mianshi= eInvBll.engage_interviewSelectWhere(e => e.resume_id == res_id);
            if (mianshi.Count==1)//2-2-1.面试表有这条数据
            {
                if (mianshi[0].interview_amount == null)//2-2-1-1判断有没有面试
                {
                    mianshi[0].interview_amount = 1;    //面试表没有面试
                    ViewBag.Mianshicishu = mianshi;
                }
                else//2-2-1-2面试了
                {
                    ////有这个用户，条件查询，再修改。
                    //engage_interview engage = eInvBll.engage_interviewSelectWhere(e => e.resume_id == res_id).FirstOrDefault();
                    //engage.interview_amount += engage.interview_amount;//修改  加1
                    //eInvBll.engage_interviewUpdate(engage);
                    ////再一次查询
                    //List<engage_interview> mianshi2 = eInvBll.engage_interviewSelectWhere(e => e.resume_id == res_id);
                    //ViewBag.Mianshicishu = mianshi2;
                    mianshi[0].interview_amount++;
                        ;
                    ViewBag.Mianshicishu = mianshi;
                }
            }
            else//2-2-2.没有数据
            {

            }
            return View(list);
        }


        //3.面试登记
        public ActionResult Dengji(engage_interview einter)
        {
            //简历表id
            int res_idhaha = Convert.ToInt32(Request["res_idhaha"]);
            //查询有没有数据
            List<engage_interview> list = eInvBll.engage_interviewSelectWhere(e=>e.resume_id== res_idhaha);


            if (list.Count>0)
            {
                einter.ein_id = list[0].ein_id; //面试id
                einter.resume_id = short.Parse(res_idhaha.ToString());          //简历编号
                //einter.interview_amount = einter.interview_amount++;//面试次数+1
                einter.result = einter.interview_comment;           //面试结果（等于面试评价）
                einter.interview_status = 0;                        //面试状态（待筛选）
                einter.check_status = 0;                            //筛选状态
                if (eInvBll.engage_interviewUpdate(einter)> 0)
                {
                    return Content("<script>alert('面试登记成功！');location.href='/interview_sift_list/IndexShaiXuan'</script>");
                }
                else
                {
                    return Content("<script>alert('面试登记失败！');location.href='/interview_list/IndexMianShi'</script>");
                }
            }
            else
            {
                einter.resume_id = short.Parse(res_idhaha.ToString());          //简历编号
                einter.result = einter.interview_comment;           //面试结果（等于面试评价）
                einter.interview_status = 0;                        //面试状态（待筛选）
                einter.check_status = 0;                            //筛选状态
                int result = eInvBll.engage_interviewAdd(einter);
                if (result > 0)
                {
                    return Content("<script>alert('面试登记成功！');location.href='/interview_sift_list/IndexShaiXuan'</script>");
                }
                else
                {
                    return Content("<script>alert('面试登记失败！');location.href='/interview_list/IndexMianShi'</script>");
                }
            }

        }

    }
}