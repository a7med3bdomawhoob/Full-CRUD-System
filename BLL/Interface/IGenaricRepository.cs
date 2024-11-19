using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace BLL.Interface
{
    public interface IGenaricRepository<T> where T : class 
    {
        Task<IReadOnlyList<T>> GetAll();
        Task<T> GetById(int? id);
        Task<int> Add(T entity);
        public void Delete(T entity);
        void Update(T entity);
        Task<IReadOnlyList<T>> getall();

        Task<int> DeleteById(int id);




    }
}
