using System.Collections.Generic;

namespace LibAlgoCs.Common.Interfaces
{
    public interface IQueue<T> : IEnumerable<T>
    {
        void Enqueue(T item);

        T Dequeue();

        T Peek();

        void Clear();

        bool IsEmpty();

        int getSize();
    }
}
