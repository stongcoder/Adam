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
        protected string _dataToCheck;
        public PreConditionUseDB(string dataToCheck)
        {
            this._dataToCheck= dataToCheck;
        }
        
    }

    public class PreConditionFloat:PreConditionUseDB
    {
        public float cmpVal;
        public NumCompare cmp;
        public PreConditionFloat(string dataToCheck,float cmpVal,NumCompare cmp) : base(dataToCheck) 
        {
            this.cmpVal= cmpVal;
            this.cmp = cmp;
        }
        public override bool Check()
        {
            var val=database.GetData<float>(_dataToCheck);
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
        public bool cmpVal;
        public EqualCompare cmp;
        public PreConditionBool(string dataToCheck,bool cmpVal,EqualCompare cmp) : base(dataToCheck)
        {
            this.cmpVal = cmpVal;
            this.cmp = cmp;
        }
        public override bool Check()
        {
            var val= database.GetData<bool>(_dataToCheck);
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
            System.Object val= database.GetData<System.Object>(_dataToCheck);
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
