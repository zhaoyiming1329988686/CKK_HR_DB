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
    /// 4表 三级机构
    /// </summary>
    public class config_file_third_kindDao : DaoBase<config_file_third_kind>, Iconfig_file_third_kindDao
    {


        /// <summary>
        /// 1.三级下拉框查询
        /// </summary>
        /// <returns></returns>
        public List<config_file_third_kind> Xialakuangchaxun()
        {
            return SelectAll();
        }

        /// <summary>
        /// 2.三级条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<config_file_third_kind> TiaojianChaXun(Expression<Func<config_file_third_kind, bool>> where)
        {
            return SelectWhere(where);
        }


    }
}
