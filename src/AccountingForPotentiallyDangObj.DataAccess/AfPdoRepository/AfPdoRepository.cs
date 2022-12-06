using AccountingForPotentiallyDangObj.DataAccess.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForPotentiallyDangObj.DataAccess.AfPdoRepository
{
    public class AfPdoRepository<T>
        where T : class
    {
        public AfPdoRepository() { }

        public AfPdoRepository(AfPdoDbContext afPdoDbContext)
        {
            AfPdoDbContext = afPdoDbContext;
        }

        public AfPdoDbContext AfPdoDbContext { get; set; }

        //метод для получения данных из БД
        public async Task<IQueryable<T>> GetAllAsync()
        {
            var entities = AfPdoDbContext.Set<T>().AsNoTracking();
            await AfPdoDbContext.SaveChangesAsync();
            return entities;
        }
    }
}
