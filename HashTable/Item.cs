using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash_Table
{
    public class Item
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public Item(string key, string value)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(key));
            Key = key;
            Value = value;
        }
        public override string ToString()
        {
            return Key;
        }
    }
}
