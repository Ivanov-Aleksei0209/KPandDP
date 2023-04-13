using AccountingForPotentiallyDangObj.DataAccess.EF;
using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForPotentiallyDangObj.DataAccess.AfPdoRepository
{
    public class AfPdoRepository<T> : IRepository<T>
        where T : BaseModel
    {
        public AfPdoRepository() { }

        // Способ взаимодействия между классами - агрегация
        public AfPdoRepository(AfPdoDbContext afPdoDbContext)
        {
            AfPdoDbContext = afPdoDbContext;
        }

        public AfPdoDbContext AfPdoDbContext { get; set; }

        //метод для получения данных из БД
        public IQueryable<T> GetAll()
        {
            var entities = AfPdoDbContext.Set<T>(); //ToListAsync();
            return entities;
        }
        //метод для создания записи данных в конкретную таблицу БД
        public async Task<T> AddAsync(T entity)
        {
            var entit = await AfPdoDbContext.Set<T>().AddAsync(entity);
            await AfPdoDbContext.SaveChangesAsync();
            return entit.Entity;
        }
        // метод для получения записи из таблицы БД по заданному id
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await AfPdoDbContext.Set<T>().FindAsync(id);
        }

        // метод для обновления записи в стоке таблицы БД
        public async Task<T> UpdateAsync(T entity)
        {
            AfPdoDbContext.Set<T>().Update(entity);
            await AfPdoDbContext.SaveChangesAsync();
            var result = await AfPdoDbContext.FindAsync<T>(entity.Id);
            return result;
        }
        // метод для удаления строки из таблицы БД
        public async Task DeleteAsync(T entity)
        {
            AfPdoDbContext.Set<T>().Remove(entity);
            await AfPdoDbContext.SaveChangesAsync();
        }
    }
}
