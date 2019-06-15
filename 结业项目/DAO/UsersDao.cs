using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDao;
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
    }
}
