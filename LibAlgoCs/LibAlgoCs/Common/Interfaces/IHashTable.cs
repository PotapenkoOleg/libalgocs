namespace LibAlgoCs.Common.Interfaces
{
    public interface IHashTable<TKey, TValue>
    {
        void Add(TKey key, TValue value);

        TValue Get(TKey key);

        TValue Remove(TKey key);

        bool IsEmpty();

        int GetSize();

        void Clear();
    }
}
