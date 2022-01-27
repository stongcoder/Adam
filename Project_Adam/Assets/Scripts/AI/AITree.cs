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
        public Transform trans;
        protected BaseNode root;
        private void Awake()
        {
            trans= transform;
            Init();
            root.Init(this);
        }
        private void Update()
        {
            if (root.Evaluate())
            {
                root.Tick();
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
            root?.Clear();
        }
        private void OnDestroy()
        {
            root?.Clear();
        }
    }
    
   
}
