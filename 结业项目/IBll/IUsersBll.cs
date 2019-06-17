using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Linq.Expressions;

namespace IBll
{
    public interface IUsersBll
    {

        List<users> user();
        /// <summary>
        /// 1.登陆判断
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        List<users> Login(Expression<Func<users, bool>> where);
    }
}
