using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace WebBook.Models
{
    public class PatientRepository : IRepository<Patient>
    {
        PatientContext patientContext;
        public PatientRepository(PatientContext context)
        {
            patientContext = context;
        }
        public void Create(Patient item)
        {
            patientContext.Patients.Add(item);
        }

        public void Delete(Patient item)
        {
            if (item != null)
                patientContext.Patients.Remove(item);
        }

        public IQueryable<Patient> Get()
        {
            return patientContext.Patients.Where(patient => patient.Patient_id > 0);
        }

        public IQueryable<Patient> Get(Expression<Func<Patient, bool>> predicate)
        {
            return patientContext.Patients.Where(predicate);
        }

        public void Save()
        {
            patientContext.SaveChanges();
        }

        public void Update(Patient item)
        {
            patientContext.Entry(item).State = EntityState.Modified;
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
                    patientContext.Dispose();
                }
            }
            disposed = true;
        }
    }
}