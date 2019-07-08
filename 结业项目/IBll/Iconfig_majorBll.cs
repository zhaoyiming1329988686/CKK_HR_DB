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
    /// 10.表
    /// </summary>
    public interface Iconfig_majorBll
    {
        /// <summary>
        /// 1.职位表下拉框查询
        /// </summary>
        /// <returns></returns>
        List<config_major> Xialakuangchaxun();

        /// <summary>
        /// 2.职位条件查询
        /// </summary>
        /// <returns></returns>
        List<config_major> TiaojianChaXun(Expression<Func<config_major, bool>> where);
    }
}
