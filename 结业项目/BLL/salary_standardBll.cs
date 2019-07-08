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
    /// 14.
    /// </summary>
    public class salary_standardBll:Isalary_standardBll
    {
        Isalary_standardDao ssdd = IocCreate.CreateDao<salary_standardDao>("salary_standardjiaobaba", "salary_standardbaba");

        public List<salary_standard> salary_standardSelect()
        {
            return ssdd.salary_standardSelect();
        }

        public List<salary_standard> salary_standardWhere(Expression<Func<salary_standard, bool>> where)
        {
            return ssdd.salary_standardWhere(where);
        }
    }
}
