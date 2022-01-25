using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AI
{
    public class SequenceNode : BaseNode
    {
        private int _activeIndex = -1;
        public SequenceNode(PreConditionNode precondition = null) : base(precondition) { }
        protected override bool DoEvaluate()
        {
            if(Help.IsCollectionEmpty(children))return false;
            if(_activeIndex == -1)
            {
                return children[0].Evaluate();
            }
            else
            {
                bool result=children[_activeIndex].Evaluate();
                if (!result)
                {
                    children[_activeIndex].Clear();
                    _activeIndex = -1;
                }
                return result;
            }
        }
        protected override TickResult DoTick()
        {
            if (_activeIndex == -1)
            {
                _activeIndex = 0;
            }
            var result =children[_activeIndex].Tick();
            if (result == TickResult.Ended)
            {
                children[_activeIndex].Clear();
                _activeIndex++;
                if (_activeIndex >= children.Count)
                {
                    _activeIndex = -1;
                }
                else
                {
                    result = TickResult.Running;
                }
            }
            return result;
        }
        public override void Clear()
        {
            base.Clear();
            _activeIndex = -1;
            foreach(var child in children)
            {
                child.Clear();
            }
        }
    }

}
