using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDao;
using Model;
using System.Linq.Expressions;

namespace DAO
{
    /// <summary>
    /// 26.表
    /// 简历表
    /// </summary>
    public class engage_resumeDao : DaoBase<engage_resume>, Iengage_resumeDao
    {
        /// <summary>
        /// 1.添加简历信息
        /// </summary>
        /// <param name="er"></param>
        /// <returns></returns>
        public int engage_resumeAdd(engage_resume er)
        {
            return Add(er);
        }



        /// <summary>
        /// 2.查询
        /// </summary>
        /// <returns></returns>
        public List<engage_resume> engage_resumeSelect()
        {
            return SelectAll();
        }

        /// <summary>
        /// 3.条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<engage_resume> engage_resumeWhere(Expression<Func<engage_resume, bool>> where)
        {
            return SelectWhere(where);
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
        public List<engage_resume> engage_resumeFenYe<Int>(Expression<Func<engage_resume, Int>> order, Expression<Func<engage_resume, bool>> where, out int rows, out int pages, int currentPage, int pageSize)
        {
            return FenYe3(order, where, out  rows, out  pages,  currentPage,  pageSize );
        }
        /// <summary>
        /// 4.修改（复核）
        /// </summary>
        /// <param name="er"></param>
        /// <returns></returns>
        public int engage_resumeUpdate(engage_resume er)
        {
            return Update(er);
        }

        /// <summary>
        /// 5.删除
        /// </summary>
        /// <param name="er"></param>
        /// <returns></returns>
        public int engage_resumeDelete(engage_resume er)
        {
            return Delete(er);
        }
    }
}
