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
namespace UI.Controllers.人力资源档案管理
{
    /// <summary>
    /// 4.人力资源档案变更
    /// </summary>
    public class human_change_locateController : Controller
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
        //人力资源信息表
        Ihuman_fileBll hhff = IocCreate.CreateBLL<human_fileBll>("human_filejiaomama", "human_filemama");
        IUsersBll uu = IocCreate.CreateBLL<UsersBll>("Usersjiaomama", "Usersmama");

        //1.变更条件查询显示
        public ActionResult BianGengIndex()
        {
            ViewBag.yiji = cffkBll.Xialakuangchaxun();
            ViewBag.fenlei = cmkBll.Xialakuangchaxun();
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
        //2.变更显示人力资源表数据
        public ActionResult BianGengChaxun()
        {
            return View();
        }

        //3.变更显示人力资源表数据
        public ActionResult BianGengChaxun2()
        {
            int rows = 0;   //总记录数
            int pages = 0; //总页数
            int currentPage = Convert.ToInt32(Request["currentPage"]);//当前页数
            int pageSize = 3; //每页显示多少条
            List<human_file> list = hhff.human_fileFenYe(e => e.huf_id, e => e.check_status == 1, out rows, out pages, currentPage, pageSize);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["list"] = list;
            di["rows"] = rows;
            di["pages"] = pages;
            di["pageSize"] = pageSize;
            return Content(JsonConvert.SerializeObject(di));
        }

        //条件查询，变更显示
        public ActionResult BianGengDangexiugian()
        {
            int huf_id = Convert.ToInt32(Request["huf_id"]);
            ViewBag.Users = uu.user();//用户表
            List<human_file> list = hhff.human_fileWhere(e => e.huf_id == huf_id);
            return View(list);
        }

        //3.变更
        public ActionResult BianGeng(human_file hff)
        {
            int huf_id = Convert.ToInt32(Request["huf_idhaha"]);
            human_file hf = hhff.human_fileWhere(e => e.huf_id == huf_id).FirstOrDefault();
            hf.changer = hff.changer;//档案变更人
            hf.lastly_change_time = DateTime.Now;//档案最近更改时间
            hf.change_time= DateTime.Now;//变更时间
            hf.human_nationality = hff.human_nationality;//(选择性修改)1.国籍
            hf.human_race = hff.human_race;//(选择性修改)2.民族
            hf.human_religion = hff.human_religion;//(选择性修改)3.宗教信仰
            hf.human_party = hff.human_party;//(选择性修改)4.政治面貌
            hf.human_educated_degree = hff.human_educated_degree;//(选择性修改)5.国籍
            hf.human_educated_years = hff.human_educated_years;//(选择性修改)6.教育年限
            hf.human_educated_major = hff.human_educated_major;//(选择性修改)7.学历专业
            hf.human_speciality = hff.human_speciality;//(选择性修改)8.特长
            hf.human_hobby = hff.human_hobby;//(选择性修改)9.爱好
            if (hhff.human_fileUpdate(hf) > 0)
            {
                return Content("<script>alert('人力资源档案变更成功！');location.href='/human_change_locate/BianGengIndex';</script>");
            }
            else
            {
                return View(hf);
            }
        }
    }
}