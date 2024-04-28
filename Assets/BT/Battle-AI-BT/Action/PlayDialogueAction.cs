using System;
using KLFramework.IOC;
//using KLGame.OP.Plot;
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
    [Name("���ŶԻ�")]
    [Category("_����/��Ϊ����")]
    [Description("���ŶԻ�")]
    public class PlayDialogueAction : PlayAction
    {
        [Name("������")]
        public BBParameter<BeanContext> BeanContext;
        [Name("�Ի�id")]
        public BBParameter<int> DialogueID;
        private bool _Running;
        protected override bool _OnExecute()
        {
            //_Running = true;
            //var dialogueService = BeanContext.value.FindObjectOfType<DialogueService>();
            //dialogueService.PlayDialogue(DialogueID.value, () => { _Running = false; });
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