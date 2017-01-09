using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ToDoLists.Models
{
    public class ListRepository : IRepository<TodoList>
    {
        ListContext listContext;
        public ListRepository(ListContext context)
        {
            listContext = context;
        }
        public void Create(TodoList item)
        {
            listContext.TodoLists.Add(item);
        }

        public void Delete(TodoList item)
        {
            if (item != null)
                listContext.TodoLists.Remove(item);
        }

        public IQueryable<TodoList> Get() //-
        {
            return listContext.TodoLists.Where(list => list.List_id > 0);
        }

        public IQueryable<TodoList> Get(Expression<Func<TodoList, bool>> predicate)//-
        {
            return listContext.TodoLists.Where(predicate);
        }

        public void Save()
        {
            listContext.SaveChanges();
        }

        public void Update(TodoList item)
        {
            listContext.Entry(item).State = EntityState.Modified;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            {
                if (disposing)
                {
                    listContext.Dispose();
                }
            }
            disposed = true;
        }
    }
}