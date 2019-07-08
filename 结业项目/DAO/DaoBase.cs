using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Runtime.Remoting.Messaging;
using System.Linq.Expressions;
using System.Data.Entity;

namespace DAO
{
    /// <summary>
    /// 通用增删改方法
    /// </summary>
    /// HR_DB项目
    public class DaoBase<T> where T : class
    {
        HR_DBEntities mvc = CreateDBContent();
        public static HR_DBEntities CreateDBContent()
        {
            HR_DBEntities at = CallContext.GetData("s") as HR_DBEntities;
            if (at == null)
            {
                at = new HR_DBEntities();
                CallContext.SetData("s", at);
            }
            return at;
        }

        /// <summary>
        /// 1.查询
        /// </summary>
        /// <returns></returns>
        public List<T> SelectAll()
        {
            return mvc.Set<T>().Select(e => e).AsNoTracking().ToList();
        }

        /// <summary>
        /// 2.条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<T> SelectWhere(Expression<Func<T, bool>> where)
        {
            return mvc.Set<T>().Where(where).AsNoTracking()
                  .Select(e => e)
                  .ToList();
        }


        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <param name="order"></param>
        /// <param name="where"></param>
        /// <param name="rows"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<T> FenYe<K>(Expression<Func<T, K>> order, Expression<Func<T, bool>> where, out int rows, int currentPage, int pageSize)
        {
            var data = mvc.Set<T>().OrderBy(order).Where(where);
            rows = data.Count();
            return data.Skip((currentPage - 1) * pageSize)
                 .Take(pageSize)
                 .ToList();
        }

        /// <summary>
        /// 卞文嘉 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="order"></param>
        /// <param name="where"></param>
        /// <param name="pages"></param>
        /// <param name="rows"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<T> FenYe2<T, K>(Expression<Func<T, K>> order, Expression<Func<T, bool>> where, out int pages, out int rows, int currentPage, int pageSize) where T : class
        {
            var data = mvc.Set<T>().OrderBy(order).Where(where);
            rows = data.Count();
            pages = (data.Count() % pageSize) > 0 ? (data.Count() / pageSize) + 1 : (data.Count() / pageSize);
            return data.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 3.使用本分页****************************
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <param name="order">排序</param>
        /// <param name="where">条件</param>
        /// <param name="rows">总记录数</param>
        /// <param name="pages">总页数</param>
        /// <param name="currentPage">当前页</param>
        /// <param name="pageSize">每页显示多少条</param>
        /// <returns></returns>
        public List<T> FenYe3<K>(Expression<Func<T, K>> order, Expression<Func<T, bool>> where, out int rows, out int pages, int currentPage, int pageSize)
        {
            var data = mvc.Set<T>().OrderBy(order).Where(where);
            rows = data.Count();
            pages = (data.Count() % pageSize) > 0 ? (data.Count() / pageSize) + 1 : (data.Count() / pageSize);
            return data.Skip((currentPage - 1) * pageSize)
                 .Take(pageSize)
                 .ToList();
        }


        /// <summary>
        /// 4.添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(T t)
        {
            //System.Data.EntityState
            try
            {
                mvc.Entry<T>(t).State = System.Data.Entity.EntityState.Added;
                //mvc.Configuration.ValidateOnSaveEnabled = true;
                return mvc.SaveChanges();
            }
            catch (Exception e)
            {

                throw;
            }

        }


        /// <summary>
        /// 5.修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(T t)
        {
            mvc.Entry<T>(t).State = System.Data.Entity.EntityState.Modified;
            return mvc.SaveChanges();
        }

        /// <summary>
        /// 6.删除
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Delete(T t)
        {
            mvc.Entry<T>(t).State = System.Data.Entity.EntityState.Deleted;
            return mvc.SaveChanges();
        }


        /// <summary>
        /// 7.sql方法
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int AUD(string sql)
        {
            return mvc.Database.ExecuteSqlCommand(sql);
        }
    }
}
