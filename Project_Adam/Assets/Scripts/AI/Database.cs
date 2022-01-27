using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AI
{
    [System.Serializable]
    public class Database:MonoBehaviour
    {
        [SerializeField,DisplayOnly]
        private SerializableDictionary<string, System.Object> data;
        public Database()
        {
            data = new SerializableDictionary<string, object>();
        }
        public T GetData<T>(string key)
        {
            if (IsContain(key))
            {
                if(data[key] is T)
                {
                    return (T)data[key];
                }
                else
                {
                    Log.PrintError("����ת������");
                    return default(T);
                }
            }
            else
            {
                Log.PrintError("��ѯֵ������");
                return default(T);
            }
        }
        public bool IsContain(string key)
        {
            return data.ContainsKey(key);   
        }
        public void SetData(string key,System.Object value)
        {
            data[key]=value;
        }
    }
}
