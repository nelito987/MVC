﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WheelsShop.Data.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> All();

        T Find(object id);

        T Add(T entity);

        T Update(T entity);

        void Remove(T entity);

        T Remove(object id);

        IEnumerable<T> Where(Expression<Func<T, bool>> predicate);

        void SaveChanges();
    }
}
