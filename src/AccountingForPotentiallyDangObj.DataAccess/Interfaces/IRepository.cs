using AccountingForPotentiallyDangObj.DataAccess.EF;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingForPotentiallyDangObj.DataAccess.Interfaces
{
    public interface IRepository<T> 
        where T : BaseModel
    {
        AfPdoDbContext AfPdoDbContext { get; set; }

        Task<T> AddAsync(T entity);
        Task DeleteAsync(T entity);
        IQueryable<T> GetAll();
        Task<IQueryable<T>> GetByIdAsync(int id);
        Task<T> UpdateAsync(T entity);
    }
}