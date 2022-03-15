using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_management_Api.Data.Repository.Interface
{
    public interface IRepository<T>
    {
        Task<bool> InsertRecord(T model);
        Task<T> GetRecord(string id);
      //  IQueryable<T> GetRecord(string id, params Expression<Func<T, object>>[] includes);
        //Task<bool> DeleteRecord(string id);
        Task<bool> UpdateRecord(T model);
        public IQueryable<T> GetRecords(params Expression<Func<T, object>>[] includes);

    }
}
