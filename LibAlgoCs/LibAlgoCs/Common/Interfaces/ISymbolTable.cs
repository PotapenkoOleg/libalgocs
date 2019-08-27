using System.Collections.Generic;

namespace LibAlgoCs.Common.Interfaces
{
    public interface ISymbolTable<TValue>
    {
        void Put(string key, TValue value);

        TValue Get(string key);

        void Delete(string key);

        bool Contains(string key);

        void Clear();

        bool IsEmpty();

        int GetSize();

        IEnumerable<string> GetAllKeys();

        IEnumerable<string> GetKeysWithPrefix(string prefix);

        string[] WildcardMatch(string key);

        string LongestPrefixOf(string prefix);
    }
}
