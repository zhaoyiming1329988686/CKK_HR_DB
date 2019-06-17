using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBll;
using IDao;
using Model;
using IOC;
using System.Data;
using System.Linq.Expressions;
using DAO;
namespace BLL
{
    public class UsersBll:IUsersBll
    {
        IUsersDao uu = IocCreate.CreateDao<UsersDao>("Usersjiaobaba", "Usersbaba");

        public List<users> user()
        {
            return uu.user();
        }

        /// <summary>
        /// 1.登陆
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<users> Login(Expression<Func<users, bool>> where)
        {
            return uu.Login(where);
        }



    }
}
