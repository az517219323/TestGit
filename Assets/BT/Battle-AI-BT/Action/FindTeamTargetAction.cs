using KLFramework.IOC;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace KLGame.OP.Battle.BTAI
{

    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: junhong.cai@kunlun-inc.com
    // @Date: 2021-07-29 17:27
    //******************************************
    [Name("查找队伍里的目标")]
    [Category("_昆仑/行为任务")]
    [Description("根据上下文在队伍里查找目标对象")]
    public class FindTeamTargetAction : ActionTask
    {
        [Name("上下文")]
        public BBParameter<IBeanContext> BeanContext;
        [Name("目标对象")]
        public BBParameter<BattleUnit> SetToTarget;
        [Name("队伍查找key")]
        public BBParameter<string> TeamKey;
        
        /*
        protected override string info => "Find " + TeamKey.value + " to " + SetToTarget;

        protected override void OnExecute()
        {
            var teamAIService = BeanContext.value.FindObjectOfType<TeamAIService>();
            SetToTarget.value = teamAIService.Random(TeamKey.value);
            EndAction(true);            
        }
        */
    }
}