using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Task_6_1
{
    public class Cache : IDisposable
    {
        private const int PurgeInterval = 1000;
        private static readonly TimeSpan MaxAge = TimeSpan.FromSeconds(10);

        private readonly Dictionary<string, CacheEntry> _cache;
        private readonly Timer _timer;
        private bool _disposed;

        public int Capacity { get; }

        public int Count
        {
            get
            {
                lock (_cache)
                {
                    return _cache.Count;
                }
            }
        }

        public Cache(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("Cache capacity must be greater than zero.");
            }

            Capacity = capacity;
            _cache = new Dictionary<string, CacheEntry>(capacity);
            _timer = new Timer(Purge, null, PurgeInterval, PurgeInterval);
        }

        public void Set(string key, object obj)
        {
            CheckDisposed();
            CheckKey(key);

            if (obj is null)
            {
                throw new ArgumentNullException($"{nameof(obj)}");
            }

            lock (_cache)
            {
                if (_cache.ContainsKey(key))
                {
                    _cache[key] = new CacheEntry {Data = obj, LastAccess = DateTime.UtcNow};
                }
                else
                {
                    if (_cache.Count == Capacity)
                    {
                        var oldKey = _cache.OrderBy(pair => pair.Value.LastAccess).First().Key;
                        _cache.Remove(oldKey);
                    }

                    _cache.Add(key, new CacheEntry {Data = obj, LastAccess = DateTime.UtcNow});
                }
            }
        }

        public object Get(string key)
        {
            CheckDisposed();
            CheckKey(key);

            lock (_cache)
            {
                if (!_cache.TryGetValue(key, out var item))
                {
                    return null;
                }

                item.LastAccess = DateTime.UtcNow;
                return item.Data;
            }
        }

        public bool Remove(string key)
        {
            CheckDisposed();
            CheckKey(key);

            lock (_cache)
            {
                return _cache.Remove(key);
            }
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _timer.Dispose();
            _disposed = true;
        }

        private void Purge(object _)
        {
            lock (_cache)
            {
                if (_cache.Count == 0)
                {
                    return;
                }

                var now = DateTime.UtcNow;
                var oldKeys = _cache.Where(pair => now - pair.Value.LastAccess > MaxAge)
                    .Select(pair => pair.Key).ToArray();
                foreach (var key in oldKeys)
                {
                    _cache.Remove(key);
                }
            }
        }

        private void CheckDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(Cache));
            }
        }

        private static void CheckKey(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("The 'key' cannot be null or empty.");
            }
        }

        private class CacheEntry
        {
            public object Data { get; init; }
            public DateTime LastAccess { get; set; }
        }
    }
}