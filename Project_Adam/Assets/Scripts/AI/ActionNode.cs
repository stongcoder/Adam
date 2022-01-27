using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AI
{
    public class ActionNode : BaseNode
    {
        private ActionStatus status;
        public ActionNode(PreConditionNode preCondition = null) : base(preCondition)
        {
            status = ActionStatus.Ready;
        }
        protected virtual void Enter()
        {
            LogAction("Enter");
        }
        protected virtual void Exit()
        {
            LogAction("Exit");
        }
        protected virtual TickResult Execute()
        {
            LogAction("Execute");
            return TickResult.Running;
        }
        public override void Clear()
        {
            base.Clear();
            if (status != ActionStatus.Ready)
            {
                Exit();
                status = ActionStatus.Ready;
            }
        }
        protected override TickResult DoTick()
        {
            TickResult result = TickResult.Ended;
            if (status == ActionStatus.Ready)
            {
                Enter();
                status = ActionStatus.Running;
            }
            if (status == ActionStatus.Running)
            {
                result = Execute();
                if (result != TickResult.Running)
                {
                    Exit();
                    status = ActionStatus.Ready;
                }
            }
            return result;

        }
        public override void AddChild(BaseNode node)
        {
            Log.PrintError("Action不能添加子节点");

        }
        public override void RemoveChild(BaseNode node)
        {
            Log.PrintError("Action不能删除子节点");
        }
        private void LogAction(string mes)
        {
            if (AIConfiguration.ENABLE_ACTION_LOG)
            {
                Log.Print($"{mes}[{this.GetType()}]");
            }
        }
    }
}
