using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Linq.Expressions;

namespace IDao
{
    /// <summary>
    /// 2.一级机构设置
    /// </summary>
    public interface Iconfig_file_first_kindDao
    {
        /// <summary>
        /// 1.下拉框查询
        /// </summary>
        /// <returns></returns>
        List<config_file_first_kind> Xialakuangchaxun();

        /// <summary>
        /// 2.一级条件查询
        /// </summary>
        /// <returns></returns>
        List<config_file_first_kind> TiaojianChaXun(Expression<Func<config_file_first_kind, bool>> where);

    }
}
