using System.Collections.Generic;
using Crestron.SimplSharp;

namespace Amib.SSharpThreading.Internal
	{
	internal class SynchronizedDictionary<TKey, TValue>
		{
		private readonly Dictionary<TKey, TValue> _dictionary;
		private readonly object _lock;
#if SSHARP
		private int _pendingEntries;
#endif

		public SynchronizedDictionary ()
			{
			_lock = new object ();
			_dictionary = new Dictionary<TKey, TValue> ();
			}

		public int Count
			{
#if SSHARP
			get { return _dictionary.Count + _pendingEntries; }
#else
			get { return _dictionary.Count; }
#endif
			}

#if SSHARP
		public int RealCount
			{
			get { return _dictionary.Count; }
			}
#endif

		public bool Contains (TKey key)
			{
			lock (_lock)
				{
				return _dictionary.ContainsKey (key);
				}
			}

		public void Remove (TKey key)
			{
			lock (_lock)
				{
				_dictionary.Remove (key);
				}
			}

		public object SyncRoot
			{
			get { return _lock; }
			}

		public TValue this[TKey key]
			{
			get
				{
				lock (_lock)
					{
					return _dictionary[key];
					}
				}
			set
				{
				lock (_lock)
					{
					_dictionary[key] = value;
					}
				}
			}

		public Dictionary<TKey, TValue>.KeyCollection Keys
			{
			get
				{
				lock (_lock)
					{
					return _dictionary.Keys;
					}
				}
			}

		public Dictionary<TKey, TValue>.ValueCollection Values
			{
			get
				{
				lock (_lock)
					{
					return _dictionary.Values;
					}
				}
			}
		public void Clear ()
			{
			lock (_lock)
				{
				_dictionary.Clear ();
				_pendingEntries = 0;
				}
			}

#if SSHARP
		public void AddPendingEntry ()
			{
			Interlocked.Increment (ref _pendingEntries);
			}

		public void RemovePendingEntry ()
			{
			Interlocked.Decrement (ref _pendingEntries);
			}
#endif
		}
	}
