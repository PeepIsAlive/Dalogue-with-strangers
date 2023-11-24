using System;

namespace Services.Saves
{
    public interface ISaveService
    {
        public void Load<T>(string key, Action<T> callback);
        public void Save(string key, object data, Action<bool> callback = null);
    }
}
