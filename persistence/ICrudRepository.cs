using System.Collections.Generic;

namespace persistence
{
    public interface ICrudRepository<Id,E>
    {
        void Add(E elem);
        IEnumerable<E> FindAll();
    }
}