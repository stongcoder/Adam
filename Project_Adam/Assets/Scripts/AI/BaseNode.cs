using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AI
{
    public class BaseNode
    {   
        public List<BaseNode> children { get; private set; }
        public bool isInit { get; private set; }

        public Database database;
        public PreCondition preCondition;

        [SerializeField]
        private float _interval = 0f;

        private float lastUseTime;

        public BaseNode(PreCondition precondition=null)
        {
            this.preCondition = precondition;
            children = new List<BaseNode>();
            isInit = false;
        }
        public virtual void Init(Database database)
        {
            if (isInit) return;
            isInit = true;

            this.database = database;
            preCondition?.Init(database);
            foreach(var child in children)
            {
                child.Init(database);
            }
        }
        public bool Evaluate()
        {
            bool isCoolDown = CheckTimer();
            return isInit&&isCoolDown&&(preCondition != null||preCondition.Evaluate())&&DoEvaluate();
        }
        protected virtual bool DoEvaluate() { return true; }
        private bool CheckTimer()
        {
            if (Time.time - lastUseTime > _interval)
            {
                lastUseTime = Time.time;
                return true;
            }
            return false; 
        }
    }
}
