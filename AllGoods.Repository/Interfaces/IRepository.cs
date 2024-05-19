﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace AllGoods.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChangesAsync();
    }
}
