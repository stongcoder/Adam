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
        public PreConditionNode preCondition;

        protected AITree tree;
        protected Database database{get=>tree.database;}
        [SerializeField]
        private float interval = 0f;

        private float lastUseTime;

        public BaseNode(PreConditionNode precondition=null)
        {
            this.preCondition = precondition;
            isInit = false;
        }
        public virtual void Init(AITree tree)
        {
            if (isInit) return;
            isInit = true;
            this.tree = tree;
            preCondition?.Init(tree);
            foreach(var child in children)
            {
                child.Init(tree);
            }
        }

        public TickResult Tick() 
        {
            lastUseTime = Time.time;
            return DoTick();   
        }
        protected virtual TickResult DoTick()
        {
            return TickResult.Ended;
        }
        public virtual void Clear() { }
        public virtual void AddChild(BaseNode node)
        {
            if (children == null)
            {
                children = new List<BaseNode>();
            }
            if (node == null)
            {
                Log.PrintError("child为空");
            }
            else if(children.Contains(node))
            {
                Log.PrintError("child已存在");
            }
            else
            {
                children.Add(node);
            }
        }
        public virtual void RemoveChild(BaseNode node)
        {
            if(children == null || !children.Contains(node))
            {
                Debug.LogError("未包含child");
            }
            else
            {
                children.Remove(node);
            }
        }
        public bool Evaluate()
        {
            bool isCoolDown = CheckTimer();
            return isInit&&isCoolDown&&(preCondition == null||preCondition.Check())&&DoEvaluate();
        }
        protected virtual bool DoEvaluate() { return true; }
        private bool CheckTimer()
        {
            if (Time.time - lastUseTime > interval)
            {
                return true;
            }
            return false; 
        }
    }
}
