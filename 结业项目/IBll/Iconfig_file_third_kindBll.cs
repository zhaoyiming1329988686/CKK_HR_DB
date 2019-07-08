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
    /// 4表 三级机构
    /// </summary>
    public interface Iconfig_file_third_kindBll
    {
        /// <summary>
        /// 1.三级下拉框查询
        /// </summary>
        /// <returns></returns>
        List<config_file_third_kind> Xialakuangchaxun();

        /// <summary>
        /// 2.三级机构条件查询
        /// </summary>
        /// <returns></returns>
        List<config_file_third_kind> TiaojianChaXun(Expression<Func<config_file_third_kind, bool>> where);
    }
}
