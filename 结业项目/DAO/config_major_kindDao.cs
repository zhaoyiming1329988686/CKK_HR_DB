using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDao;
using Model;
using DAO;
using System.Linq.Expressions;

namespace DAO
{
    /// <summary>
    /// 9.表
    /// 职位分类表
    /// </summary>
    public class config_major_kindDao : DaoBase<config_major_kind>, Iconfig_major_kindDao
    {


        /// <summary>
        /// 1.职位分类下拉框
        /// </summary>
        /// <returns></returns>
        public List<config_major_kind> Xialakuangchaxun()
        {
            return SelectAll();
        }

        /// <summary>
        /// 2.职位分类条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<config_major_kind> TiaojianChaXun(Expression<Func<config_major_kind, bool>> where)
        {
            return SelectWhere(where);
        }

    }
}
