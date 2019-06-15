using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IBll
{
    public interface IUsersBll
    {
        /// <summary>
        /// 1.登陆判断
        /// </summary>
        /// <param name="uu"></param>
        /// <returns></returns>
        List<users> user();
    }
}
