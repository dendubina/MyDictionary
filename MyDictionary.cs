using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionary
{
    public class MyDictionary<TKey,TValue> where TKey : notnull
    {
        private struct DataItem
        {                    
            public TKey Key { get; set; }
            public TValue Value { get; set; }
        }
        private const int BucketsCount = 100;
        private readonly ICollection<DataItem>[] _items = new ICollection<DataItem>[BucketsCount];      

        public TValue this[TKey key]
        {
            get => GetDataItem(key).Value;
            
            set
            {
                DataItem item = GetDataItem(key);
                item.Value = value;
            }
        }

        public void Add(TKey key, TValue value)
        {
            var hash = GetHash(key);
            DataItem item = new DataItem { Key = key, Value = value };
            
            (_items[hash] ??= new List<DataItem>()).Add(item);
        }       

        private DataItem GetDataItem(TKey key)
        {
            var hash = GetHash(key);            

            DataItem? item = _items[hash].Where(x => x.Key.Equals(key)).FirstOrDefault();

            return item ?? throw new KeyNotFoundException();      
        }        

        private int GetHash(TKey key) => Math.Abs(key.GetHashCode() % _items.Length);       
    }
}
