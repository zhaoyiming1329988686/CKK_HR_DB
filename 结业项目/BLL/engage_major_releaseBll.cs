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
    /// 20.职业发布登记
    /// </summary>
    public class engage_major_releaseBll:Iengage_major_releaseBll
    {
        Iengage_major_releaseDao emrDao = IocCreate.CreateDao<engage_major_releaseDao>("engage_major_releasejiaobaba", "engage_major_releasebaba");

        /// <summary>
        /// 1.添加
        /// </summary>
        /// <param name="ee"></param>
        /// <returns></returns>
        public int Addengage_major_release(engage_major_release ee)
        {
            return emrDao.Addengage_major_release(ee);
        }

        /// <summary>
        /// 2.查询
        /// </summary>
        /// <returns></returns>
        public List<engage_major_release> engage_major_releaseSelect()
        {
            return emrDao.engage_major_releaseSelect();
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
            return emrDao.engage_major_releaseSelectFenYe<Int>(order, where, out  rows, out  pages,  currentPage,  pageSize);
        }


        /// <summary>
        /// 4.修改查询（条件查询）
        /// </summary>
        /// <param name="ee"></param>
        /// <returns></returns>
        public List<engage_major_release> engage_major_releaseUpdateSelect(Expression<Func<engage_major_release, bool>> where)
        {
            return emrDao.engage_major_releaseUpdateSelect(where);
        }


        /// <summary>
        /// 5.修改（职业发布登记表变更状态）
        /// </summary>
        /// <param name="ee"></param>
        /// <returns></returns>
        public int engage_major_releaseUpdate(engage_major_release ee)
        {
            return emrDao.engage_major_releaseUpdate(ee);
        }

        /// <summary>
        /// 6.删除
        /// </summary>
        /// <param name="ee"></param>
        /// <returns></returns>
        public int engage_major_releaseDelete(engage_major_release ee)
        {
            return emrDao.engage_major_releaseDelete(ee);
        }
    }
}
