using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDao;
using System.Linq.Expressions;

namespace DAO
{
    /// <summary>
    /// 27.表
    /// 面试表
    /// </summary>
    public class engage_interviewDao : DaoBase<engage_interview>, Iengage_interviewDao
    {


        /// <summary>
        /// 1.查询面试表
        /// </summary>
        /// <returns></returns>
        public List<engage_interview> engage_interviewSelect()
        {
            return SelectAll();
        }

        /// <summary>
        /// 2.条件查询面试表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<engage_interview> engage_interviewSelectWhere(Expression<Func<engage_interview, bool>> where)
        {
            return SelectWhere(where);
        }

        /// <summary>
        /// 3.添加面试表
        /// </summary>
        /// <param name="interview"></param>
        /// <returns></returns>
        public int engage_interviewAdd(engage_interview interview)
        {
            return Add(interview);
        }

        /// <summary>
        /// 4.分页
        /// </summary>
        /// <typeparam name="Int"></typeparam>
        /// <param name="order"></param>
        /// <param name="where"></param>
        /// <param name="rows"></param>
        /// <param name="pages"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<engage_interview> engage_interviewFenYe<Int>(Expression<Func<engage_interview, Int>> order, Expression<Func<engage_interview, bool>> where, out int rows, out int pages, int currentPage, int pageSize)
        {
            return FenYe3(order, where, out rows, out pages, currentPage, pageSize);
        }

        /// <summary>
        /// 5.修改
        /// </summary>
        /// <param name="interview"></param>
        /// <returns></returns>
        public int engage_interviewUpdate(engage_interview interview)
        {
            return Update(interview);
        }

        /// <summary>
        /// 6.删除
        /// </summary>
        /// <param name="interview"></param>
        /// <returns></returns>
        public int engage_interviewDelete(engage_interview interview)
        {
            return Delete(interview);
        }
    }
}
