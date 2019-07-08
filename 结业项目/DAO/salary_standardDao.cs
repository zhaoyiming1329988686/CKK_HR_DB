using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDao;
using Model;
using System.Linq.Expressions;
namespace DAO
{
    /// <summary>
    /// 14.表
    /// 
    /// </summary>
    public class salary_standardDao : DaoBase<salary_standard>, Isalary_standardDao
    {
        public List<salary_standard> salary_standardSelect()
        {
            return SelectAll();
        }

        public List<salary_standard> salary_standardWhere(Expression<Func<salary_standard, bool>> where)
        {
            return SelectWhere(where);
        }
    }
}
