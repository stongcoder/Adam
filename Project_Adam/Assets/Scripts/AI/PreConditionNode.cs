using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AI
{
    public abstract class PreConditionNode:BaseNode
    {
        public PreConditionNode() : base(null) { }
        public abstract bool Check();
        protected override TickResult DoTick()
        {
            bool success=Check();
            if (success)
            {
                return TickResult.Ended;
            }
            else
            {
                return TickResult.Running;
            }
        }
    }

    public abstract class PreConditionUseDB : PreConditionNode
    {
        protected string dataToCheck;
        public PreConditionUseDB(string dataToCheck)
        {
            this.dataToCheck= dataToCheck;
        }
        
    }

    public class PreConditionFloat:PreConditionUseDB
    {
        private float cmpVal;
        private NumCompare cmp;
        public PreConditionFloat(string dataToCheck,float cmpVal,NumCompare cmp) : base(dataToCheck) 
        {
            this.cmpVal= cmpVal;
            this.cmp = cmp;
        }
        public override bool Check()
        {
            var val=database.GetData<float>(dataToCheck);
            bool flag = false;
            switch (cmp)
            {
                case NumCompare.LessThan:
                    {
                        flag= val<cmpVal;
                        break;
                    }
                case NumCompare.LessEqualThan:
                    {
                        flag = val <= cmpVal;
                        break;
                    }
                case NumCompare.GreaterThan:
                    {
                        flag=val > cmpVal;
                        break;
                    }
                case NumCompare.GreaterEqualThan:
                    {
                        flag=val >= cmpVal;
                        break;
                    }
                case NumCompare.EqualTo:
                    {
                        flag=val == cmpVal;
                        break;
                    }
                case NumCompare.NotEqualTo:
                    {
                        flag= val != cmpVal;
                        break;
                    }
            }
            return flag;
        }
    }
    public class PreConditionBool : PreConditionUseDB
    {
        private bool cmpVal;
        private EqualCompare cmp;
        public PreConditionBool(string dataToCheck,bool cmpVal,EqualCompare cmp) : base(dataToCheck)
        {
            this.cmpVal = cmpVal;
            this.cmp = cmp;
        }
        public override bool Check()
        {
            var val= database.GetData<bool>(dataToCheck);
            var flag = false;
            switch (cmp)
            {
                case EqualCompare.Equal:
                    {
                        flag = val == cmpVal;
                        break;
                    }
                case EqualCompare.NotEqual:
                    {
                        flag=val != cmpVal;
                        break;
                    }
            }
            return flag;
        }
    }
    public class PreConditionNull : PreConditionUseDB
    {
        public NullCompare cmp;
        public PreConditionNull(string dataToCheck,NullCompare cmp):base(dataToCheck)
        {
            this.cmp = cmp;
        }
        public override bool Check()
        {
            System.Object val= database.GetData<System.Object>(dataToCheck);
            bool flag = false;
            switch (cmp)
            {
                case NullCompare.IsNull: 
                    {
                        flag = (val == null);
                        break;
                    }
                case NullCompare.NotNull:
                    {
                        flag=(val != null);
                        break;
                    }
            }
            return flag;
        }
    }
}
