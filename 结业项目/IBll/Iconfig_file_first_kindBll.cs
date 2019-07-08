using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Linq.Expressions;

namespace IBll
{
    /// <summary>
    /// 一级机构
    /// </summary>
    public interface Iconfig_file_first_kindBll
    {
        /// <summary>
        /// 1.一级下拉框查询
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
