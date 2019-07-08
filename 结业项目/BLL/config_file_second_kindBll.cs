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
    /// 3 表 二级机构
    /// </summary>
    public class config_file_second_kindBll:Iconfig_file_second_kindBll
    {
        Iconfig_file_second_kindDao cfskbll = IocCreate.CreateDao<config_file_second_kindDao>("config_file_second_kindjiaobaba", "config_file_second_kindbaba");


        /// <summary>
        /// 1.二级下拉框查询
        /// </summary>
        /// <returns></returns>
        public List<config_file_second_kind> Xialakuangchaxun()
        {
            return cfskbll.Xialakuangchaxun();
        }

        /// <summary>
        /// 2.条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<config_file_second_kind> TiaojianChaXun(Expression<Func<config_file_second_kind, bool>> where)
        {
            return cfskbll.TiaojianChaXun(where);
        }
    }
}
