using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBook.Models
{
    public class UnitOfWork : IDisposable
    {
        private PatientContext patientContext = new PatientContext();
        private PatientRepository patientRepository;

        public PatientRepository PatientRepository
        {
            get
            {
                if (patientRepository == null)
                    patientRepository = new PatientRepository(patientContext);

                return patientRepository;
            }
        }

        public void Save()
        {
            patientContext.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            {
                if (disposing)
                {
                    patientContext.Dispose();
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