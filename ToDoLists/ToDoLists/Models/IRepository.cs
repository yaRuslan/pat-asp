﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ToDoLists.Models
{
    interface IRepository<T> : IDisposable where T : class
    {
        void Create(T item);
        void Update(T item);
        void Save();
        void Delete(int id);
        T Get(int id);

        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<TodoList, bool>> predicate);
    }
}
