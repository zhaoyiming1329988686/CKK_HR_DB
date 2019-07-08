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
    /// 14.表
    /// 薪酬基本信息表
    /// </summary>
    public interface Isalary_standardDao
    {
        /// <summary>
        /// 1.查询
        /// </summary>
        /// <returns></returns>
        List<salary_standard> salary_standardSelect();

        /// <summary>
        /// 2.条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        List<salary_standard> salary_standardWhere(Expression<Func<salary_standard, bool>> where);
        
    }
}
