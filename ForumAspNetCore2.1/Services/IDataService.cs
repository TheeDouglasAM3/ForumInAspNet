using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Services
{
    public interface IDataService
    {
        void InicializaDB();
        Task InicializaDBAsync(IServiceProvider provider);
    }
}
