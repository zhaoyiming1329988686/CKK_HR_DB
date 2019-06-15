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
        IUsersDao oo = IocCreate.CreateDao<UsersDao>("Usersjiaobaba", "Usersbaba");

        public List<users> user()
        {
            return oo.user();
        }

  
    }
}
