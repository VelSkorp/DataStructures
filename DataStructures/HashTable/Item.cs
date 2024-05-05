namespace HashTable
{
	/// <summary>
	/// Represents an item with a key-value pair in a hash table.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TValue">The type of the value.</typeparam>
	public class Item<TKey, TValue>
		where TKey : notnull, IEqualityComparer<TKey>
	{
		/// <summary>
		/// Gets the value of the item.
		/// </summary>
		public TValue Value { get; private set; }

		/// <summary>
		/// The key of the item.
		/// </summary>
		private readonly TKey _key;

		/// <summary>
		/// Initializes a new instance of the Item class with the specified key and value.
		/// </summary>
		/// <param name="key">The key of the item.</param>
		/// <param name="value">The value of the item.</param>
		/// <exception cref="ArgumentNullException">Thrown when the key or value is null.</exception>
		public Item(TKey key, TValue value)
		{
			if (key is null)
			{
				throw new ArgumentNullException(nameof(key));
			}

			if (value is null)
			{
				throw new ArgumentNullException(nameof(value));
			}

			_key = key;
			Value = value;
		}

		/// <summary>
		/// Returns a string representation of the key.
		/// </summary>
		/// <returns>A string representing the key.</returns>
		public override string ToString()
		{
			return _key.ToString();
		}

		/// <summary>
		/// Computes the hash code for the key.
		/// </summary>
		/// <returns>The hash code of the key.</returns>
		public override int GetHashCode()
		{
			return _key.GetHashCode();
		}
	}
}