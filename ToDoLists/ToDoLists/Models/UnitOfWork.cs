using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoLists.Models
{
    public class UnitOfWork : IDisposable
    {
        private ListContext listContext = new ListContext();
        private ListRepository listRepository;

        public ListRepository ListRepository
        {
            get
            {
                if (listRepository == null)
                    listRepository = new ListRepository(listContext);

                return listRepository;
            }
        }

        public void Save()
        {
            listContext.SaveChanges();
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
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}