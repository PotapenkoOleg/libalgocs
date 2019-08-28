using LibAlgoCs.Common.Enums;
using LibAlgoCs.Common.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace LibAlgoCs.Lists.DoubleLinkedList
{
    public class DoubleLinkedList<TKey, TValue> : IList<TKey, TValue>, IBagKeyValue<TKey, TValue>
    {
        public void Add(TKey key, TValue value, InsertPosition position)
        {
            throw new NotImplementedException();
        }

        public void Add(TKey TKey, TValue value, TKey before)
        {
            throw new NotImplementedException();
        }

        public void Add(TKey key, TValue value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public TValue Get(TKey key)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<TValue> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int GetSize()
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public TValue Remove(RemovePosition position)
        {
            throw new NotImplementedException();
        }

        public TValue Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
