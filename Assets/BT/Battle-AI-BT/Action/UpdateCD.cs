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
    // @Date: 2021-07-29 17:21
    //******************************************
    [Name("更新CD")]
    [Category("_昆仑/行为任务")]
    [Description("更新CD值，并返回成功")]
    public class UpdateCD: ActionTask
    {
        public BBParameter<float> CD;
        

        protected override string info {
            get { return CD + ""; }
        }
        
        protected override void OnExecute()
        {
            CD.value -= Time.deltaTime;
            EndAction(true);
        }
    }
}