namespace HashTable
{
	/// <summary>
	/// Represents a hash table data structure with generic key-value pairs.
	/// </summary>
	/// <typeparam name="TKey">The type of the keys in the hash table.</typeparam>
	/// <typeparam name="TValue">The type of the values in the hash table.</typeparam>
	/// <remarks>
	/// The hash table uses separate chaining for collision resolution.
	/// </remarks>
	public class HashTable<TKey, TValue>
		where TKey : notnull, IEqualityComparer<TKey>
	{
		/// <summary>
		/// Gets the size of the hash table.
		/// </summary>
		/// <returns>The number of keys in the hash table.</returns>
		public int Count => _items.Count;

		/// <summary>
		/// Dictionary storing hash codes mapped to sets of values.
		/// </summary>
		private Dictionary<int, HashSet<TValue>> _items;

		/// <summary>
		/// Initializes a new instance of the HashTable class.
		/// </summary>
		public HashTable()
		{
			_items = new Dictionary<int, HashSet<TValue>>();
		}

		/// <summary>
		///     <para>
		///         Inserts an item into the hash table.
		///     </para>
		///     <para>
		///         Time Complexity: O(n), where n is the number of elements having the same hash.
		///     </para>
		///     <para>
		///         Space Complexity: O(1), doesn't create any new data structures.
		///     </para>
		/// </summary>
		/// <param name="item">The item to insert.</param>
		/// <returns>True if the item is successfully inserted; otherwise, false.</returns>
		public bool Insert(Item<TKey, TValue> item)
		{
			var hash = item.GetHashCode();

			if (_items.ContainsKey(hash))
			{
				return _items[hash].Add(item.Value);
			}

			_items.Add(hash, new HashSet<TValue> { item.Value });
			return true;
		}

		/// <summary>
		///     <para>
		///         Deletes an item from the hash table.
		///     </para>
		///     <para>
		///         Time Complexity: O(1), searching for an item in the hash table and removing it from the set have constant time complexity.
		///     </para>
		///     <para>
		///         Space Complexity: O(1), doesn't create any new data structures.
		///     </para>
		/// </summary>
		/// <param name="item">The item to delete.</param>
		/// <returns>True if the item is successfully deleted; otherwise, false.</returns>
		public bool Delete(Item<TKey, TValue> item)
		{
			var hash = item.GetHashCode();

			if (_items.TryGetValue(hash, out var hashTableItems))
			{
				return hashTableItems.Remove(item.Value);
			}

			return false;
		}

		/// <summary>
		///     <para>
		///         Searches for items with the specified key in the hash table.
		///     </para>
		///     <para>
		///         Time Complexity: O(1), searching for an item in the hash table have constant time complexity.
		///     </para>
		///     <para>
		///         Space Complexity: O(1), doesn't create any new data structures.
		///     </para>
		/// </summary>
		/// <param name="key">The key to search for.</param>
		/// <returns>A HashSet containing the values associated with the key, or null if no such key exists.</returns>
		public HashSet<TValue> Search(TKey key)
		{
			var hash = key.GetHashCode();

			if (_items.TryGetValue(hash, out var hashTableItems))
			{
				return hashTableItems;
			}

			return default;
		}

		/// <summary>
		///     <para>
		///         Checks if the hash table contains the specified item.
		///     </para>
		///     <para>
		///         Time Complexity: O(1), searching for an item in the hash table have constant time complexity.
		///     </para>
		///     <para>
		///         Space Complexity: O(1), doesn't create any new data structures.
		///     </para>
		/// </summary>
		/// <param name="item">The item to check.</param>
		/// <returns>True if the item is found in the hash table; otherwise, false.</returns>
		public bool Contains(Item<TKey, TValue> item)
		{
			var hash = item.GetHashCode();

			if (_items.TryGetValue(hash, out var hashTableItems))
			{
				return hashTableItems.Contains(item.Value);
			}

			return false;
		}
	}
}