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
    /// 27.表面试表
    /// 
    /// </summary>
    public interface Iengage_interviewBll
    {
        /// <summary>
        /// 1.查询面试面试表
        /// </summary>
        /// <returns></returns>
        List<engage_interview> engage_interviewSelect();


        /// <summary>
        /// 2.条件查询面试表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        List<engage_interview> engage_interviewSelectWhere(Expression<Func<engage_interview, bool>> where);

        /// <summary>
        /// 3.添加面试表
        /// </summary>
        /// <param name="ein"></param>
        /// <returns></returns>
        int engage_interviewAdd(engage_interview interview);

        /// <summary>
        ///  4.分页查询（面试表）
        /// </summary>
        /// <param name="order">排序</param>
        /// <param name="where">条件</param>
        /// <param name="rows">总记录数</param>
        /// <param name="currentPage">当前页数</param>
        /// <param name="pageSize">每页显示多少条</param>
        /// <returns></returns>
        List<engage_interview> engage_interviewFenYe<Int>(Expression<Func<engage_interview, Int>> order, Expression<Func<engage_interview, bool>> where, out int rows, out int pages, int currentPage, int pageSize);

        /// <summary>
        /// 5.修改
        /// </summary>
        /// <param name="interview"></param>
        /// <returns></returns>
        int engage_interviewUpdate(engage_interview interview);

        /// <summary>
        /// 6.删除
        /// </summary>
        /// <param name="interview"></param>
        /// <returns></returns>
        int engage_interviewDelete(engage_interview interview);
    }
}
