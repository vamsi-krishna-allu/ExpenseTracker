using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository
{
    public interface IRepository<T>
    {
        public void Add(T item);

        public void Remove(string id);

        public T Get(string? id);

        public List<T> GetAll();

        public bool Exists(string id);

        public T Update(T item);

        public List<T> Find(Expression<Func<T, bool>> expression);
    }
}
