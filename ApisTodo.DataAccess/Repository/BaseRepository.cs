using ApisTodo.ModelsF;
//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApisTodo.DataAccess.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ApisTodoEntity _todoEntity;

        public BaseRepository(ApisTodoEntity todoEntity)
        {
            this._todoEntity = todoEntity;
        }

        public void Add(T entity)
        {
            _todoEntity.TodoItems.
            _todoEntity.Set<T>().Add(entity);
            _todoEntity.SaveChanges();
        }

        public async Task<T> AddAsync(T entity)
        {
            _todoEntity.Set<T>().Add(entity);
            await _todoEntity.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> whereLamdba)
        {
            var list = _todoEntity.Set<T>().AsNoTracking().Where(whereLamdba);
            if (list != null)
            {
                _todoEntity.Set<T>().RemoveRange(list);
                return await _todoEntity.SaveChangesAsync() > 0;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> ExistAsync(Expression<Func<T, bool>> whereLamdba)
        {
            return await _todoEntity.Set<T>().AsNoTracking().AnyAsync(whereLamdba);
        }

        public async Task<T> FetchAsync(int id)
        {
            return await _todoEntity.Set<T>().FindAsync(id);
        }

        public async Task<T> FetchAsync(Expression<Func<T, bool>> whereLamdba)
        {
            return await _todoEntity.Set<T>().FirstOrDefaultAsync(whereLamdba);
        }

        public async Task<int> QueryCountAsync(Expression<Func<T, bool>> whereLamdba)
        {
            return await _todoEntity.Set<T>().CountAsync(whereLamdba);
        }

        public async Task<List<T>> SelectAsync<TKey>(Expression<Func<T, bool>> whereLamdba, Expression<Func<T, TKey>> orderbyLambda, bool isAsc = false)
        {
            if (isAsc)
            {
                return await _todoEntity.Set<T>().AsNoTracking().Where(whereLamdba).OrderBy(orderbyLambda).ToListAsync();
            }
            else
            {
                return await _todoEntity.Set<T>().AsNoTracking().Where(whereLamdba).OrderByDescending(orderbyLambda).ToListAsync();
            }
        }

        public async Task<List<T>> SelectAsync<TKey>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLamdba, Expression<Func<T, TKey>> orderbyLambda, bool isAsc = false)
        {
            var offset = (pageIndex - 1) * pageSize;

            if (isAsc)
            {
                return await _todoEntity.Set<T>().AsNoTracking().Where(whereLamdba).Skip(offset).Take(pageSize).OrderBy(orderbyLambda).ToListAsync();
            }
            else
            {
                return await _todoEntity.Set<T>().AsNoTracking().Where(whereLamdba).Skip(offset).Take(pageSize).OrderByDescending(orderbyLambda).ToListAsync();
            }
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _todoEntity.Update(entity);
            return await _todoEntity.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(T entity, params string[] propertyNames)
        {
            var entry = _todoEntity.Entry(entity);
            entry.State = EntityState.Unchanged;
            foreach (string proName in propertyNames)
            {
                entry.Property(proName).IsModified = true;
            }
            return await _todoEntity.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Expression<Func<T, bool>> whereLamdba, params string[] propertyNames)
        {
            var list = await _todoEntity.Set<T>().AsNoTracking().Where(whereLamdba).ToListAsync();
            foreach (var item in list)
            {
                var entry = _todoEntity.Entry(item);
                entry.State = EntityState.Unchanged;
                foreach (string proName in propertyNames)
                {
                    entry.Property(proName).IsModified = true;
                }
            }
            return await _todoEntity.SaveChangesAsync() > 0;
        }
    }
}
