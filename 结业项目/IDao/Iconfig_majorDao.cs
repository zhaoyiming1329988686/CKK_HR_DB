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
    /// 10.表
    /// 职位表
    /// </summary>
    public interface Iconfig_majorDao
    {
        /// <summary>
        /// 1.职位表下拉框查询
        /// </summary>
        /// <returns></returns>
        List<config_major> Xialakuangchaxun();


        /// <summary>
        /// 2.职位表条件查询
        /// </summary>
        /// <returns></returns>
        List<config_major> TiaojianChaXun(Expression<Func<config_major, bool>> where);

    }
}
