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
    /// 12.表
    /// </summary>
    public class human_fileDao : DaoBase<human_file>, Ihuman_fileDao
    {
        public int human_fileAdd(human_file hf)
        {
            return Add(hf);
        }


        public List<human_file> human_fileSelect()
        {
            return SelectAll();
        }

        public int human_fileUpdate(human_file hf)
        {
            return Update(hf);
        }

        public List<human_file> human_fileWhere(Expression<Func<human_file, bool>> where)
        {
            return SelectWhere(where);
        }

        public List<human_file> human_fileFenYe<Int>(Expression<Func<human_file, Int>> order, Expression<Func<human_file, bool>> where, out int rows, out int pages, int currentPage, int pageSize)
        {
            return FenYe3(order, where, out rows, out pages, currentPage, pageSize);
        }

        public int human_fileDelete(human_file hf)
        {
            return Delete(hf);
        }
    }
}
