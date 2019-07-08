using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBll;
using Model;
using IDao;
using IOC;
using DAO;
using System.Linq.Expressions;

namespace BLL
{
    /// <summary>
    /// 4表
    /// </summary>
    public class config_file_third_kindBll :Iconfig_file_third_kindBll
    {
        Iconfig_file_third_kindDao cftkbll = IocCreate.CreateDao<config_file_third_kindDao>("config_file_third_kindjiaobaba", "config_file_third_kindbaba");


        /// <summary>
        /// 1.二级下拉框查询
        /// </summary>
        /// <returns></returns>
        public List<config_file_third_kind> Xialakuangchaxun()
        {
            return cftkbll.Xialakuangchaxun();
        }

        /// <summary>
        /// 2.三级条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>

        public List<config_file_third_kind> TiaojianChaXun(Expression<Func<config_file_third_kind, bool>> where)
        {
            return cftkbll.TiaojianChaXun(where);
        }
    }
}
