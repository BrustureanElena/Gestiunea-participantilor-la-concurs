using System.Collections.Generic;

namespace CSharp.repository
{
    public interface ICrudRepository<Id,E>
    {
        void Add(E elem);
        List<E> FindAll();
    }
}