using System;
using System.Collections.Generic;


namespace Dictionary
{
    public class MyDictionary<TKey,TValue> where TKey : notnull
    {
        private struct DataItem
        {                    
            public TKey Key;
            public TValue Value;
        }

        private List<DataItem>[] items;
        private const int BucketsCount = 100;

        public MyDictionary()
        {
            items = new List<DataItem>[BucketsCount];

            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new List<DataItem>();
            }
        }

        public TValue this[TKey key]
        {
            get => GetValue(key);
            
            set
            {
                DataItem item = GetDataItem(key);
                item.Value = value;
            }
        }

        public void Add(TKey key, TValue value)
        {
            var hash = GetHash(key);

            /*foreach (var item in items[hash])
            {
                if (key.Equals(item.Key))
                    throw new ArgumentException($"An item with the same key has already been added. Key: {key}");
            }*/

            items[hash].Add(new DataItem
            {                
                Key = key,
                Value = value,
            });
        }

        public TValue GetValue(TKey key)
        {
            var hash = GetHash(key);                       

            foreach(var item in items[hash])
            {
                if (key.Equals(item.Key))
                    return item.Value;                
            }
            
            throw new KeyNotFoundException();
        }

        private DataItem GetDataItem(TKey key)
        {
            var hash = GetHash(key);

            foreach (var item in items[hash])
            {
                if (key.Equals(item.Key))
                    return item;
            }

            throw new KeyNotFoundException();
        }        

        private int GetHash(TKey key) => Math.Abs(key.GetHashCode() % items.Length);        
       
    }
}
