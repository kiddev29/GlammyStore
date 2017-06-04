using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlammyStore.Common.Services.Int64
{
    public interface IGetDataService<T> where T : class
    {
        T FindById(long id);
        IEnumerable<T> GetAll(string keyword = null);
    }
}
