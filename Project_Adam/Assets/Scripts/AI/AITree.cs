using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AI
{
    public abstract class AITree : MonoBehaviour
    {
        [HideInInspector]
        public Database database;
        [HideInInspector]
        public bool isRunning;
        protected BaseNode _root;
        private void Awake()
        {
            Init();
            _root.Init(database);
        }
        private void Update()
        {
            if (!isRunning) return;
            if (_root.Evaluate())
            {
                _root.Tick();
            }
        }
        protected virtual void Init()
        {
            if(!TryGetComponent<Database>(out Database database))
            {
                database=gameObject.AddComponent<Database>();
            }

        }
        protected void Reset()
        {
            _root?.Clear();
        }
        private void OnDestroy()
        {
            _root?.Clear();
        }
    }
    
   
}
