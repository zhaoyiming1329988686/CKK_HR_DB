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
    /// 9.表
    /// 职位分类表
    /// </summary>
    public interface Iconfig_major_kindDao
    {
        /// <summary>
        /// 1.职位分类下拉框查询
        /// </summary>
        /// <returns></returns>
        List<config_major_kind> Xialakuangchaxun();

        /// <summary>
        /// 2.职位分类条件查询
        /// </summary>
        /// <returns></returns>
        List<config_major_kind> TiaojianChaXun(Expression<Func<config_major_kind, bool>> where);
    }
}
