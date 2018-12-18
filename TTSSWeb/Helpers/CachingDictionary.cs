using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TTSSWeb.Helpers
{
    public class CachingDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> internalDictionary;
        private readonly HashSet<TKey> missingValues;
        private readonly Func<TKey, TValue> retrieveMethod;
        private readonly Func<IEnumerable<TKey>, IEnumerable<KeyValuePair<TKey, TValue>>> massRetrieveMethod;

        public CachingDictionary(Func<TKey, TValue> retrieveMethod, Func<IEnumerable<TKey>, IEnumerable<KeyValuePair<TKey, TValue>>> massRetrieveMethod = null)
        {
            this.retrieveMethod = retrieveMethod;
            this.massRetrieveMethod = massRetrieveMethod;
            internalDictionary = new Dictionary<TKey, TValue>();
            missingValues = new HashSet<TKey>();
        }

        public TValue this[TKey key]
        {
            get
            {
                if (!internalDictionary.ContainsKey(key))
                {
                    internalDictionary.Add(key, retrieveMethod(key));
                }

                return internalDictionary[key];
            }
            set => throw new InvalidOperationException();
        }

        public IEnumerable<TValue> this[IEnumerable<TKey> keys]
        {
            get
            {
                var aKeys = keys.Except(missingValues).ToArray();
                var uncachedKeys = aKeys.Where(k => !internalDictionary.ContainsKey(k)).ToArray();
                return RetrieveValues(aKeys, uncachedKeys);
            }
        }

        public ICollection<TKey> Keys => internalDictionary.Keys;

        public ICollection<TValue> Values => internalDictionary.Values;

        public int Count => internalDictionary.Count;

        public bool IsReadOnly => true;

        public void Add(TKey key, TValue value)
        {
            internalDictionary.Add(key, value);
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            internalDictionary.Add(item.Key, item.Value);
        }

        public void PreFill(IEnumerable<KeyValuePair<TKey, TValue>> items)
        {
            foreach (var kvp in items)
            {
                if (!internalDictionary.ContainsKey(kvp.Key))
                    Add(kvp.Key, kvp.Value);
            }
        }

        public void Clear()
        {
            throw new InvalidOperationException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return internalDictionary.Contains(item);
        }

        public bool ContainsKey(TKey key)
        {
            return internalDictionary.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new InvalidOperationException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return internalDictionary.GetEnumerator();
        }

        public bool Remove(TKey key)
        {
            throw new InvalidOperationException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new InvalidOperationException();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new InvalidOperationException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return internalDictionary.GetEnumerator();
        }

        private IEnumerable<TValue> RetrieveValues(TKey[] allKeys, TKey[] uncachedKeys)
        {
            if (massRetrieveMethod != null)
            {
                var mRetrieved = massRetrieveMethod(uncachedKeys);
                foreach (var uk in uncachedKeys.Except(mRetrieved.Select(k => k.Key)))
                {
                    missingValues.Add(uk);
                }

                PreFill(mRetrieved);
            }
            else
            {
                foreach (var uKey in uncachedKeys)
                {
                    Add(uKey, retrieveMethod(uKey));
                }
            }

            foreach (var key in allKeys)
            {
                if (missingValues.Contains(key))
                    continue;

                yield return internalDictionary[key];
            }
        }
    }
}