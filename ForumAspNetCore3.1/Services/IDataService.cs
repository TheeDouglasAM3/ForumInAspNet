using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAspNetCore3._1.Services
{
    public interface IDataService
    {
        void InicializaDB();
        Task InicializaDBAsync(IServiceProvider provider);
    }
}
