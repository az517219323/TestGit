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
    [Name("�������")]
    [Category("_����/��Ϊ����/Ŀ��ѡ�񡢹��ˡ�����")]
    [Description("����ҿ��ƽ�ɫ����ΪĿ��")]
    public class FindPlayerTargetAction : ActionTask
    {
        [Name("������")]
        public BBParameter<IBeanContext> BeanContext;
        [Name("Ŀ�����")]
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