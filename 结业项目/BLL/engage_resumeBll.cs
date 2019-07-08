using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDao;
using Model;
using DAO;
using IOC;
using IBll;
using System.Linq.Expressions;
namespace BLL
{
    /// <summary>
    /// 26.简历表
    /// </summary>
    public class engage_resumeBll:Iengage_resumeBll
    {
        Iengage_resumeDao erDao = IocCreate.CreateDao<engage_resumeDao>("engage_resumejiaobaba", "engage_resumebaba");

        /// <summary>
        /// 1.添加
        /// </summary>
        /// <param name="er"></param>
        /// <returns></returns>
        public int engage_resumeAdd(engage_resume er)
        {
            return erDao.engage_resumeAdd(er);
        }

        /// <summary>
        /// 2.查询
        /// </summary>
        /// <returns></returns>
        public List<engage_resume> engage_resumeSelect()
        {
            return erDao.engage_resumeSelect();
        }
        /// <summary>
        /// 3.条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<engage_resume> engage_resumeWhere(Expression<Func<engage_resume, bool>> where)
        {
            return erDao.engage_resumeWhere(where);
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
            return erDao.engage_resumeFenYe<Int>(order, where, out rows, out pages, currentPage, pageSize);
        }

        /// <summary>
        /// 4.修改（复核）
        /// </summary>
        /// <param name="er"></param>
        /// <returns></returns>
        public int engage_resumeUpdate(engage_resume er)
        {
            return erDao.engage_resumeUpdate(er);
        }

        /// <summary>
        /// 5.删除
        /// </summary>
        /// <param name="er"></param>
        /// <returns></returns>
        public int engage_resumeDelete(engage_resume er)
        {
            return erDao.engage_resumeDelete(er);
        }
    }
}
