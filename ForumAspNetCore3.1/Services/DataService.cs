using ForumAspNetCore3._1.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAspNetCore3._1.Services
{
    public class DataService : IDataService
    {
        private readonly ApplicationDbContext contexto;

        public DataService(ApplicationDbContext contexto)
        {
            this.contexto = contexto;
        }

        public void InicializaDB()
        {
            //chama as migrations do banco
            contexto.Database.Migrate();
        }

        public async Task InicializaDBAsync(IServiceProvider provider)
        {
            await contexto.Database.MigrateAsync();
        }
    }
}
