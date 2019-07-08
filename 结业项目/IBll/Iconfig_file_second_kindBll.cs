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
    /// 3表 二级机构
    /// </summary>
    public interface Iconfig_file_second_kindBll
    {
        /// <summary>
        /// 1.二级下拉框查询
        /// </summary>
        /// <returns></returns>
        List<config_file_second_kind> Xialakuangchaxun();

        /// <summary>
        /// 2.二级条件查询
        /// </summary>
        /// <returns></returns>
        List<config_file_second_kind> TiaojianChaXun(Expression<Func<config_file_second_kind, bool>> where);
    }
}
