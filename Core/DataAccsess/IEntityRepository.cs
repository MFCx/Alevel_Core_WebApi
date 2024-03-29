﻿using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.DataAccsess
{
    /// <summary>
    /// Temel CURD işlemleri için oluşturulmuş BaseRepo interfacesi
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntityRepository<T> : IDisposable
        where T :IEntity
    {
        int Add(T entity);
        int Delete(T entity);
        int Update(T entity);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
    }
}

