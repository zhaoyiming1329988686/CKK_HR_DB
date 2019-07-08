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
    /// 26.表
    /// 简历表
    /// </summary>
    public interface Iengage_resumeBll
    {
        /// <summary>
        /// 1.添加简历登记信息
        /// </summary>
        /// <param name="er"></param>
        /// <returns></returns>
        int engage_resumeAdd(engage_resume er);

        /// <summary>
        /// 2.查询
        /// </summary>
        /// <returns></returns>
        List<engage_resume> engage_resumeSelect();

        /// <summary>
        /// 3.条件查询
        /// </summary>
        /// <returns></returns>
        List<engage_resume> engage_resumeWhere(Expression<Func<engage_resume, bool>> where);

        /// <summary>
        ///  3.分页查询（简历表）
        /// </summary>
        /// <param name="order"></param>
        /// <param name="where">条件</param>
        /// <param name="rows">总记录数</param>
        /// <param name="currentPage">当前页数</param>
        /// <param name="pageSize">每页显示多少条</param>
        /// <returns></returns>
        List<engage_resume> engage_resumeFenYe<Int>(Expression<Func<engage_resume, Int>> order, Expression<Func<engage_resume, bool>> where, out int rows, out int pages, int currentPage, int pageSize);

        /// <summary>
        /// 4.修改（复核）
        /// </summary>
        /// <param name="er"></param>
        /// <returns></returns>
        int engage_resumeUpdate(engage_resume er);

        /// <summary>
        /// 5.删除
        /// </summary>
        /// <param name="er"></param>
        /// <returns></returns>
        int engage_resumeDelete(engage_resume er);
    }
}
