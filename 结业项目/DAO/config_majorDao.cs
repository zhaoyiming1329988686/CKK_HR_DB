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
    /// 10.职位表
    /// </summary>
    public class config_majorDao : DaoBase<config_major>, Iconfig_majorDao
    {
       

        /// <summary>
        /// 1.职位表下拉框
        /// </summary>
        /// <returns></returns>
        public List<config_major> Xialakuangchaxun()
        {
            return SelectAll();
        }

        /// <summary>
        /// 2.职位表条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<config_major> TiaojianChaXun(Expression<Func<config_major, bool>> where)
        {
            return SelectWhere(where);
        }
    }
}
