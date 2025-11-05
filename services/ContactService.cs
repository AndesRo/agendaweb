using AgendaWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;

namespace AgendaWeb.Services
{
    public class ContactService
    {
        private readonly string _file;
        private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
        private List<Contact> _cache = new List<Contact>();

        public ContactService()
        {
            _file = Path.Combine(AppContext.BaseDirectory, "contacts.json");
            Load();
        }

        private void Load()
        {
            _lock.EnterWriteLock();
            try
            {
                if (File.Exists(_file))
                {
                    var json = File.ReadAllText(_file);
                    _cache = JsonSerializer.Deserialize<List<Contact>>(json) ?? new List<Contact>();
                }
                else
                {
                    _cache = new List<Contact>();
                }
            }
            finally { _lock.ExitWriteLock(); }
        }

        private void Save()
        {
            _lock.EnterWriteLock();
            try
            {
                var opciones = new JsonSerializerOptions { WriteIndented = true };
                File.WriteAllText(_file, JsonSerializer.Serialize(_cache, opciones));
            }
            finally { _lock.ExitWriteLock(); }
        }

        public IEnumerable<Contact> GetAll() => _cache.OrderByDescending(c => c.CreatedAt);

        public Contact? Get(Guid id) => _cache.FirstOrDefault(c => c.Id == id);

        public void Add(Contact c)
        {
            _cache.Add(c);
            Save();
        }

        public void Update(Contact c)
        {
            var idx = _cache.FindIndex(x => x.Id == c.Id);
            if (idx >= 0)
            {
                _cache[idx] = c;
                Save();
            }
        }

        public void Delete(Guid id)
        {
            _cache.RemoveAll(x => x.Id == id);
            Save();
        }
    }
}

