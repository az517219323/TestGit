using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace KLGame.OP.Battle.BTAI
{

    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: junhong.cai@kunlun-inc.com
    // @Date: 2021-09-29 10:45
    //******************************************
    [Category("KL/Action")]
    [Description("KLCustom - Unit Solider")]
    public class UnitSoliderAction : ActionTask
    {
        public BBParameter<BattleUnit> BattleUnit;
        public BBParameter<BattleUnit> Target;

        /*
        protected override void OnExecute()
        {
            var battleUnit = BattleUnit.value;
            var targetUnit = Target.value;
            var actionComponent = battleUnit.GetComponent<ActionComponent>();
            bool attacked = false;
            actionComponent.AddAction(
                (time, deltaTime) =>
                {
                          
                    return true;
                }
            );
            EndAction(true);
        }
        */
    }
}