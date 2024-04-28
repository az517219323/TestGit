using System;
using KLFramework.IOC;
//using KLGame.OP.Plot;
//using KLGame.OP.Sound;
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
    // @Date: 2021-09-17 00:07
    //******************************************
    [Name("���ž���")]
    [Category("_����/��Ϊ����")]
    [Description("���ž���")]
    public class PlayTimelineAction : PlayAction
    {
        [Name("������")]
        public BBParameter<BeanContext> BeanContext;
        [Name("��������")]
        public BBParameter<string> TimelineName;
        private bool _Running;
        
        protected override bool _OnExecute()
        {
            //var timelineService = BeanContext.value.FindObjectOfType<TimelineService>();
            //_Running = true;
            //timelineService.PlayTimeline(TimelineName.value, () => _Running = false);
            return true;
        }

        protected override ExeStatus _CheckRunningStatus()
        {
            if (_Running)
            {
                return ExeStatus.Running;
            }

            return ExeStatus.Succ;
        }
    }
}