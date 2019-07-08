using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using IBll;
using Model;
using DAO;
using IOC;
using IDao;
namespace BLL
{
    /// <summary>
    /// 27.表
    /// </summary>
    public class engage_interviewBll : Iengage_interviewBll
    {
        Iengage_interviewDao eInvDao = IocCreate.CreateDao<engage_interviewDao>("engage_interviewjiaobaba", "engage_interviewbaba");



        /// <summary>
        /// 1.查询
        /// </summary>
        /// <returns></returns>
        public List<engage_interview> engage_interviewSelect()
        {
            return eInvDao.engage_interviewSelect();
        }
        /// <summary>
        /// 2.修改查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<engage_interview> engage_interviewSelectWhere(Expression<Func<engage_interview, bool>> where)
        {
            return eInvDao.engage_interviewSelectWhere(where);
        }

        /// <summary>
        /// 3.添加
        /// </summary>
        /// <param name="interview"></param>
        /// <returns></returns>
        public int engage_interviewAdd(engage_interview interview)
        {
            return eInvDao.engage_interviewAdd(interview);
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
            return eInvDao.engage_interviewFenYe<Int>(order, where, out rows, out pages, currentPage, pageSize);
        }


        /// <summary>
        /// 5.修改
        /// </summary>
        /// <param name="interview"></param>
        /// <returns></returns>
        public int engage_interviewUpdate(engage_interview interview)
        {
            return eInvDao.engage_interviewUpdate(interview);
        }

        public int engage_interviewDelete(engage_interview interview)
        {
            return eInvDao.engage_interviewDelete(interview);
        }
    }
}
