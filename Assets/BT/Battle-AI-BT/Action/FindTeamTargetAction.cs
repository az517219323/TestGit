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
    [Name("���Ҷ������Ŀ��")]
    [Category("_����/��Ϊ����")]
    [Description("�����������ڶ��������Ŀ�����")]
    public class FindTeamTargetAction : ActionTask
    {
        [Name("������")]
        public BBParameter<IBeanContext> BeanContext;
        [Name("Ŀ�����")]
        public BBParameter<BattleUnit> SetToTarget;
        [Name("�������key")]
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