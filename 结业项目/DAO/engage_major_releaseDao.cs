using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using IDao;
using Model;
namespace DAO
{
    /// <summary>
    /// 20.职业发表登记表
    /// </summary>
    public class engage_major_releaseDao : DaoBase<engage_major_release>, Iengage_major_releaseDao
    {
        /// <summary>
        /// 1.添加 （职业发布登记时提交做添加）
        /// </summary>
        /// <param name="ee"></param>
        /// <returns></returns>
        public int Addengage_major_release(engage_major_release ee)
        {
            return Add(ee);
        }


        /// <summary>
        /// 2.查询
        /// </summary>
        /// <returns></returns>
        public List<engage_major_release> engage_major_releaseSelect()
        {
            return SelectAll();
        }



        /// <summary>
        ///  3.分页查询（职业发布变更显示）
        /// </summary>
        /// <param name="order"></param>
        /// <param name="where">条件</param>
        /// <param name="rows">总记录数</param>
        /// <param name="currentPage">当前页数</param>
        /// <param name="pageSize">每页显示多少条</param>
        /// <returns></returns>
        public List<engage_major_release> engage_major_releaseSelectFenYe<Int>(Expression<Func<engage_major_release, Int>> order, Expression<Func<engage_major_release, bool>> where, out int rows, out int pages, int currentPage, int pageSize)
        {
            return FenYe3(order, where, out  rows, out  pages,  currentPage,  pageSize);
        }



        /// <summary>
        /// 4.修改查询（条件查询）
        /// </summary>
        /// <param name="ee"></param>
        /// <returns></returns>
        public List<engage_major_release> engage_major_releaseUpdateSelect(Expression<Func<engage_major_release, bool>> where)
        {
            return SelectWhere(where);
        }


        /// <summary>
        /// 5.修改（职业发布登记表变更状态）
        /// </summary>
        /// <param name="ee"></param>
        /// <returns></returns>
        public int engage_major_releaseUpdate(engage_major_release ee)
        {
            return Update(ee);
        }

        /// <summary>
        /// 6.删除
        /// </summary>
        /// <param name="ee"></param>
        /// <returns></returns>
        public int engage_major_releaseDelete(engage_major_release ee)
        {
            return Delete(ee);
        }
    }
}
