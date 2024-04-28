using System.Collections.Generic;
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
    // @Date: 2021-09-29 00:11
    //******************************************
    [Name("ִ��CD")]
    [Category("_����/��Ϊ����")]
    [Description("�״λ���CDʱ�䵽�����سɹ������򷵻�ʧ��")]
    public class UnitCDAction : ActionTask
    {
        [Name("ս����λ")]
        public BBParameter<BattleUnit> BattleUnit;
        [Name("ִ��CD")]
        public BBParameter<float> CD;
        
        private Dictionary<BattleUnit, float> _CDs = new Dictionary<BattleUnit, float>();
        /*
        protected override void OnExecute()
        {
            if (_CDs.ContainsKey(BattleUnit.value))
            {
                if (Time.time >= _CDs[BattleUnit.value])
                {
                    _CDs[BattleUnit.value] = Time.time + CD.value;
                    EndAction(true);
                }
                else
                {
                    EndAction(false);
                }
            }
            else
            {
                
                _CDs.Add(BattleUnit.value, Time.time + CD.value);
                EndAction(true);
            }
        }
         */
    }
}