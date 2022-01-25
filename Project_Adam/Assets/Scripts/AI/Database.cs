using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AI
{
    [System.Serializable]
    public class Database:MonoBehaviour
    {
        [SerializeField,DisplayOnly]
        private SerializableDictionary<string, System.Object> _data;
        public Database()
        {
            _data = new SerializableDictionary<string, object>();
        }
        public T GetData<T>(string key)
        {
            if (IsContain(key))
            {
                if(_data[key] is T)
                {
                    return (T)_data[key];
                }
                else
                {
                    Log.PrintError("类型转换错误");
                    return default(T);
                }
            }
            else
            {
                Log.PrintError("查询值不存在");
                return default(T);
            }
        }
        public bool IsContain(string key)
        {
            return _data.ContainsKey(key);   
        }
        public void SetData(string key,System.Object value)
        {
            _data[key]=value;
        }
    }
}
