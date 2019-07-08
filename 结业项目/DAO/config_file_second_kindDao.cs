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
    /// 3表 二级机构
    /// </summary>
    public class config_file_second_kindDao : DaoBase<config_file_second_kind>, Iconfig_file_second_kindDao
    {


        /// <summary>
        /// 1.下拉框查询
        /// </summary>
        /// <returns></returns>
        public List<config_file_second_kind> Xialakuangchaxun()
        {
            return SelectAll();
        }

        /// <summary>
        /// 2.条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<config_file_second_kind> TiaojianChaXun(Expression<Func<config_file_second_kind, bool>> where)
        {
            return SelectWhere(where);
        }
    }
}
