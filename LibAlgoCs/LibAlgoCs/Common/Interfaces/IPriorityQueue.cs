using System;

namespace LibAlgoCs.Common.Interfaces
{
    public interface IPriorityQueue<T>
        where T : IComparable<T>
    {

        void Insert(T item);

        T Delete();

        T Peek();

        bool IsEmpty();

        int GetSize();

        void Clear();
    }
}
