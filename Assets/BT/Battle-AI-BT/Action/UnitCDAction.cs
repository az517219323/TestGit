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
    [Name("执行CD")]
    [Category("_昆仑/行为任务")]
    [Description("首次或者CD时间到，返回成功，否则返回失败")]
    public class UnitCDAction : ActionTask
    {
        [Name("战斗单位")]
        public BBParameter<BattleUnit> BattleUnit;
        [Name("执行CD")]
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