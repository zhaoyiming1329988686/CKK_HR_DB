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
    /// 一级机构
    /// </summary>
    public class config_file_first_kindBll :Iconfig_file_first_kindBll
    {
        Iconfig_file_first_kindDao cffbll = IocCreate.CreateDao<config_file_first_kindDao>("config_file_first_kindjiaobaba", "config_file_first_kindbaba");



        /// <summary>
        /// 1.一级下拉框查询(查询全部)
        /// </summary>
        /// <returns></returns>
        public List<config_file_first_kind> Xialakuangchaxun()
        {
            return cffbll.Xialakuangchaxun();
        }

        /// <summary>
        /// 2.条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<config_file_first_kind> TiaojianChaXun(Expression<Func<config_file_first_kind, bool>> where)
        {
            return cffbll.TiaojianChaXun(where);
        }

    }
}
