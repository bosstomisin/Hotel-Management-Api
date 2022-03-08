using Hotel_management_Api.Data.Dto;
using Hotel_management_Api.Data.Repository.Interface;
using Hotel_management_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_management_Api.Data.Repository.Implementation
{
    public class GenericRepo<T> : IRepository<T>where T : class
    {
        private readonly DataContext _ctx;
        public GenericRepo(DataContext ctx)
        {
            _ctx = ctx;
        } 

        public async Task<bool> InsertRecord(T model)
        {
           await _ctx.Set<T>().AddAsync(model);
            return  await _ctx.SaveChangesAsync() >= 1;
        }

        public async Task<T> GetRecord(string id)
        {
            return await _ctx.Set<T>().FindAsync(id);
        }

        public async Task<bool> DeleteRecord(string id)
        {
            var getRecord = GetRecord(id).Result;
            _ctx.Set<T>().Remove(getRecord);
            return await _ctx.SaveChangesAsync() >=1;
            
        }

        public async Task<bool> UpdateRecord(T model)
        {
            _ctx.Set<T>().Update(model);
            return await _ctx.SaveChangesAsync() >= 1;
        }
    }
}
