using System.Collections.Generic;

namespace LibAlgoCs.Common.Interfaces
{

    public interface IStack<T> : IEnumerable<T>
    {
        T Pop();

        void Push(T item);

        T Peek();

        void Clear();

        bool IsEmpty();

        int GetSize();
    }
}
