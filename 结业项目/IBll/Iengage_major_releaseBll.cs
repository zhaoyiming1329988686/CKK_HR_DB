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
    /// 20.表
    /// 职位发布登记表
    /// </summary>
    public interface Iengage_major_releaseBll
    {
        /// <summary>
        /// 1.添加 （职业发布登记时提交做添加）
        /// </summary>
        /// <param name="ee"></param>
        /// <returns></returns>
        int Addengage_major_release(engage_major_release ee);

        /// <summary>
        /// 2.查询职业发布登记（职业发布变更显示）
        /// </summary>
        /// <returns></returns>
        List<engage_major_release> engage_major_releaseSelect();

        /// <summary>
        ///  3.分页查询（职业发布变更显示）
        /// </summary>
        /// <param name="order"></param>
        /// <param name="where">条件</param>
        /// <param name="pages">总页数</param>
        /// <param name="rows">总记录数</param>
        /// <param name="currentPage">当前页数</param>
        /// <param name="pageSize">每页显示多少条</param>
        /// <returns></returns>
        List<engage_major_release> engage_major_releaseSelectFenYe<Int>(Expression<Func<engage_major_release, Int>> order, Expression<Func<engage_major_release, bool>> where, out int rows, out int pages, int currentPage, int pageSize);


        /// <summary>
        /// 4.修改查询（条件查询）
        /// </summary>
        /// <param name="ee"></param>
        /// <returns></returns>
        List<engage_major_release> engage_major_releaseUpdateSelect(Expression<Func<engage_major_release, bool>> where);

        /// <summary>
        /// 5.修改（职业发布登记表变更状态）
        /// </summary>
        /// <param name="ee"></param>
        /// <returns></returns>
        int engage_major_releaseUpdate(engage_major_release ee);

        /// <summary>
        /// 6.删除
        /// </summary>
        /// <param name="ee"></param>
        /// <returns></returns>
        int engage_major_releaseDelete(engage_major_release ee);

    }
}
