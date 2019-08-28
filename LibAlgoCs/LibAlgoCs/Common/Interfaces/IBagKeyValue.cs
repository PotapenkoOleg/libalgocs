using System.Collections.Generic;

namespace LibAlgoCs.Common.Interfaces
{
    public interface IBagKeyValue<TKey, TValue> : IEnumerable<TValue>
    {
        void Add(TKey key, TValue value);

        bool IsEmpty();

        int GetSize();
    }
}
