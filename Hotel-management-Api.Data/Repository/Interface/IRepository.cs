using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_management_Api.Data.Repository.Interface
{
    public interface IRepository<T>
    {
        Task<bool> InsertRecord(T model);
        Task<T> GetRecord(string id);
        Task<bool> DeleteRecord(string id);
        Task<bool> UpdateRecord(T model);
    }
}
