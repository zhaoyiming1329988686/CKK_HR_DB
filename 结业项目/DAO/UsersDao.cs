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
    /// 用户层
    /// </summary>
    public class UsersDao : DaoBase<users>, IUsersDao
    {


        public List<users> user()
        {
            return SelectAll();
        }

        /// <summary>
        /// 1.登陆
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<users> Login(Expression<Func<users, bool>> where)
        {
            return SelectWhere(where);
        }
    }
}
