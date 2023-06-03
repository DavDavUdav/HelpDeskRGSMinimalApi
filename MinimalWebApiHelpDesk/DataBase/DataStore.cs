﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MinimalWebApiHelpDesk.Interfaces;
using MinimalWebApiHelpDesk.Models;
using ServerAppHelpDesk.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServerAppHelpDesk.DataBase
{
    public class DataStore : IDataStore
    {
        private static DataStoreDbContext _dataStore;

        public DataStore()
        {
            _dataStore = new DataStoreDbContext();
        }

        public async Task AddAsync<T>(T entity) where T : Entity
        {
            _dataStore.Add<T>(entity);
            await Save();
        }

        public async Task<List<T>> GetAllAsync<T>() where T : Entity
        {
            var entitys = await _dataStore.Set<T>().ToListAsync();
            return entitys;
        }

        public async Task<IEnumerable<T>> GetAllFilteredAsync<T>(Expression<Func<T, bool>> filter) where T : Entity
        {
            var entitys = await _dataStore.Set<T>().Where(filter).ToArrayAsync();
            return entitys;
        }

        public async Task<T?> GetFirstAsync<T>() where T : Entity
        {
            var entity = await _dataStore.Set<T>().FirstOrDefaultAsync();
            return entity ?? null;
        }

        public async Task<T?> GetFirstFilteredAsync<T>(Expression<Func<T, bool>> filter) where T : Entity
        {
            var entity = await _dataStore.Set<T>().FirstOrDefaultAsync(filter);
            return entity ?? null;
        }

        public async Task UpdateAsync<T>(T entity) where T : Entity
        {
            _dataStore.Entry<T>(entity).State = EntityState.Modified;
            await Save();
            
        }

        public async Task DeleteAsync<T>(int id) where T : Entity
        {
            var person = await _dataStore.Set<T>().FindAsync(id);
            _dataStore.Set<T>().Remove(person);

            await Save();
        }

        public async Task Save()
        {
            await _dataStore.SaveChangesAsync();
        }
    }
}