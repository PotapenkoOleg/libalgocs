using LibAlgoCs.Common.Enums;
using System.Collections.Generic;

namespace LibAlgoCs.Common.Interfaces
{

    public interface IList<TKey, TValue> : IEnumerable<TValue>
    {
        void Add(TKey key, TValue value, InsertPosition position);

        void Add(TKey TKey, TValue value, TKey before);

        TValue Remove(RemovePosition position);

        TValue Remove(TKey key);

        TValue Get(TKey key);

        void Clear();

        bool IsEmpty();

        int GetSize();
    }
}
