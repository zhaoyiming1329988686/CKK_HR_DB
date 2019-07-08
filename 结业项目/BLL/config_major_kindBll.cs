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
    /// 9.表
    /// </summary>
    public class config_major_kindBll:Iconfig_major_kindBll
    {
        Iconfig_major_kindDao cmkbll = IocCreate.CreateDao<config_major_kindDao>("config_major_kindjiaobaba", "config_major_kindbaba");



        /// <summary>
        /// 1.职位分类下拉框查询
        /// </summary>
        /// <returns></returns>
        public List<config_major_kind> Xialakuangchaxun()
        {
            return cmkbll.Xialakuangchaxun();
        }

        /// <summary>
        /// 2.职位分类条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<config_major_kind> TiaojianChaXun(Expression<Func<config_major_kind, bool>> where)
        {
            return cmkbll.TiaojianChaXun(where);
        }
    }
}
