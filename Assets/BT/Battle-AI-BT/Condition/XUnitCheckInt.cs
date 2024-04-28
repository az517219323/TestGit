using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;

namespace KLGame.OP.Battle.BTAI
{

    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: junhong.cai@kunlun-inc.com
    // @Date: 2021-10-13 17:40
    //******************************************
    [Name("判断目标对象的变量值")]
    [Category("_昆仑/条件任务")]
    [Description("取目标战斗单位的黑板变量进行比较，如果目标没有该值，当做0处理")]
    public class XUnitCheckInt : ConditionTask
    {

      [BlackboardOnly]
      [Name("战斗单位")]
      public BBParameter<BattleUnit> BattleUnit;
      [Name("目标变量名称")]
      public BBParameter<string> ValueKey;
      [Name("比较方式")]
      public CompareMethod checkType = CompareMethod.EqualTo;
      [Name("比较值")]
      public BBParameter<int> Value;

        /*
      protected override string info => BattleUnit + "'s " + ValueKey + OperationTools.GetCompareString(checkType) + Value;

      private int _GetValue()
      {
          if (BattleUnit == null || BattleUnit.value == null)
          {
              return 0;
          }

          var blackboardComponent = BattleUnit.value.GetComponent<BlackboardComponent>();
          if (blackboardComponent == null)
          {
              return 0;
          }

          int value = blackboardComponent.GetValue<int>(ValueKey.value);
          return value;
      }

      protected override bool OnCheck() {
          return OperationTools.Compare(_GetValue(), Value.value, checkType);
      }
        */
    }
}