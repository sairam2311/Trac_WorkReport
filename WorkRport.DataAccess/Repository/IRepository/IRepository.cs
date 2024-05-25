using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WorkRport.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T:class
    {
        //T - Designation 
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);
        //void update(T entity);
        //void delete(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);  
        
        //void removeAll();

    }
}
