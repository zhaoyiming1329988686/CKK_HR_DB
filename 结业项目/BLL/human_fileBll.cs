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
    /// 12.表
    /// </summary>
    public class human_fileBll:Ihuman_fileBll
    {
        Ihuman_fileDao hhff = IocCreate.CreateDao<human_fileDao>("human_filejiaobaba", "human_filebaba");

        public int human_fileAdd(human_file hf)
        {
            return hhff.human_fileAdd(hf);
        }



        public List<human_file> human_fileSelect()
        {
            return hhff.human_fileSelect();
        }

        public int human_fileUpdate(human_file hf)
        {
            return hhff.human_fileUpdate(hf);
        }

        public List<human_file> human_fileWhere(Expression<Func<human_file, bool>> where)
        {
            return hhff.human_fileWhere(where);
        }

        public List<human_file> human_fileFenYe<Int>(Expression<Func<human_file, Int>> order, Expression<Func<human_file, bool>> where, out int rows, out int pages, int currentPage, int pageSize)
        {
            return hhff.human_fileFenYe<Int>(order, where, out rows, out pages, currentPage, pageSize);
        }

        public int human_fileDelete(human_file hf)
        {
            return hhff.human_fileDelete(hf);
        }
    }
}
