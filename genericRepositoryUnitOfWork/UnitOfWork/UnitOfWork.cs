using dataAccess_EF.EF;
using genericRepositoryUnitOfWork.Repository;
using System;

namespace genericRepositoryUnitOfWork.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        EmployeeManagementEntities _dbContext;
        bool _disposed = false;
        private GenericRepository<TBL_DEPARTMENT> departmentRepository;
        private GenericRepository<TBL_EMPLOYEE> employeeRepository;

        public GenericRepository<TBL_DEPARTMENT> DepartmentRepository
        {
            get
            {
                if (this.departmentRepository == null)
                {
                    this.departmentRepository = new GenericRepository<TBL_DEPARTMENT>(_dbContext);
                }
                return this.departmentRepository;
            }
        }

        public GenericRepository<TBL_EMPLOYEE> EmployeeRepository
        {
            get
            {
                if (this.employeeRepository == null)
                {
                    this.employeeRepository = new GenericRepository<TBL_EMPLOYEE>(_dbContext);
                }
                return this.employeeRepository;
            }
        }

        public UnitOfWork()
        {
            _dbContext = new EmployeeManagementEntities();
        }

        public void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                // logging
                throw;
            }
        }

        public void Dispose()
        {
            try
            {
                if (this._disposed == false)
                {
                    this._dbContext.Dispose();
                    GC.SuppressFinalize(this);
                    this._disposed = true;
                }                
            }
            catch (Exception ex)
            {
                // logging
                throw ex;
            }
        }
    }
}
