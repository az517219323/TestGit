using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;

namespace KLGame.OP.Battle.BTAI
{

    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: junhong.cai@kunlun-inc.com
    // @Date: 2021-07-23 18:52
    //******************************************
    [Name("属性判断")]
    [Category("_昆仑/条件任务")]
    [Description("判断战斗单位的属性值，比较方式可以选择按值比较或按百分比比较。")]
    public class PropertyCondition : ConditionTask
    {
        [Name("战斗单位")]
        public BBParameter<BattleUnit> BattleUnit;
        [Name("属性类型")]
        public BBParameter<PropertyType> PropType;
        [Name("比较值")]
        public BBParameter<float> Value;
        [Name("比较类型")]
        public ValueType ValueAs;
        [Name("比较方式")]
        public CompareMethod CheckType;

        public enum PropertyType
        {
            HP,
            Attack,
        }

        public enum ValueType
        {
            Value,
            Ratio
        }
        /*
        protected override string info
        {
            get { return "当前" + (PropertyType.value == null ? "?" : PropertyType.value.Desc) + "的" + (ValueAs == ValueType.Value ? "值" : "百分比") + OperationTools.GetCompareString(CheckType) + Value; }
        }

        protected override bool OnCheck()
        {
            float v1 = 0;
            switch (ValueAs)
            {
                case ValueType.Value:
                    v1 = PropertyType.value.ValueGetter(BattleUnit.value);
                    break;
                case ValueType.Ratio:
                    if (PropertyType.value.MaxValueGetter != null)
                    {
                        v1 = PropertyType.value.ValueGetter(BattleUnit.value) * 1f / PropertyType.value.MaxValueGetter(BattleUnit.value);
                    }
                    else
                    {
                        v1 = 1;
                    }
                    break;
                default:
                    Debug.LogError("Unknow value type `" + ValueAs + "`");
                    break;
            }

            float v2 = Value.value;
            return OperationTools.Compare(v1, v2, CheckType, 0);
        }
        */
    }
}