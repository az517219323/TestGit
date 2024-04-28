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
    [Name("查找玩家")]
    [Category("_昆仑/行为任务/目标选择、过滤、排序")]
    [Description("将玩家控制角色设置为目标")]
    public class FindPlayerTargetAction : ActionTask
    {
        [Name("上下文")]
        public BBParameter<IBeanContext> BeanContext;
        [Name("目标对象")]
        public BBParameter<BattleUnit> SetToTarget;
        
        /*
        protected override string info => "Find Player to " + SetToTarget;

        protected override void OnExecute()
        {
            var mainPlayer = BeanContext.value.FindObjectOfType<UnitService>().MainPlayer;
            SetToTarget.value = mainPlayer;
            EndAction(true);            
        }
        */
    }
}