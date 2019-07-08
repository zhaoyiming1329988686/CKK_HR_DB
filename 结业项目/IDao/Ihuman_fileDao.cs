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
    /// 12.表
    /// 12.人力资源档案表
    /// </summary>
    public interface Ihuman_fileDao
    {
        /// <summary>
        /// 1.添加
        /// </summary>
        /// <param name="hf"></param>
        /// <returns></returns>
        int human_fileAdd(human_file hf);

        /// <summary>
        /// 2.查询
        /// </summary>
        /// <returns></returns>
        List<human_file> human_fileSelect();

        /// <summary>
        /// 3.条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        List<human_file> human_fileWhere(Expression<Func<human_file, bool>> where);

        /// <summary>
        /// 4.修改
        /// </summary>
        /// <param name="hf"></param>
        /// <returns></returns>
        int human_fileUpdate(human_file hf);

        /// <summary>
        ///  5.分页查询（简历表）
        /// </summary>
        /// <param name="order"></param>
        /// <param name="where">条件</param>
        /// <param name="rows">总记录数</param>
        /// <param name="currentPage">当前页数</param>
        /// <param name="pageSize">每页显示多少条</param>
        /// <returns></returns>
        List<human_file> human_fileFenYe<Int>(Expression<Func<human_file, Int>> order, Expression<Func<human_file, bool>> where, out int rows, out int pages, int currentPage, int pageSize);

        /// <summary>
        /// 6.删除
        /// </summary>
        /// <param name="hf"></param>
        /// <returns></returns>
        int human_fileDelete(human_file hf);
    }
}
