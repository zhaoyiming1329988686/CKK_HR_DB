using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBll;
using Model;
using IDao;
using IOC;
using DAO;
using System.Linq.Expressions;

namespace BLL
{
    /// <summary>
    /// 10.表
    /// 职位表
    /// </summary>
    public class config_majorBll:Iconfig_majorBll
    {
        Iconfig_majorDao cmbll = IocCreate.CreateDao<config_majorDao>("config_majorjiaobaba", "config_majorbaba");



        /// <summary>
        /// 1.职位表下拉框查询
        /// </summary>
        /// <returns></returns>
        public List<config_major> Xialakuangchaxun()
        {
            return cmbll.Xialakuangchaxun();
        }

        /// <summary>
        /// 2.职位表条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<config_major> TiaojianChaXun(Expression<Func<config_major, bool>> where)
        {
            return cmbll.TiaojianChaXun(where);
        }
    }
}
