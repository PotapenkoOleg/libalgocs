using System.Collections.Generic;

namespace LibAlgoCs.Common.Interfaces
{
    public interface IBag<T> : IEnumerable<T>
    {
        void Add(T item);

        bool IsEmpty();

        int GetSize();
    }
}
